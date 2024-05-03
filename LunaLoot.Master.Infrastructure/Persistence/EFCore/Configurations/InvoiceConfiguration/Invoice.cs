using LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceId = LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot.ValueObjects.InvoiceId;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.InvoiceConfiguration;

public class Invoice: IEntityTypeConfiguration<Domain.InvoiceAggregateRoot.Invoice>
{
    public void Configure(EntityTypeBuilder<Domain.InvoiceAggregateRoot.Invoice> builder)
    {
        builder.ToTable($"{nameof(Domain.InvoiceAggregateRoot.Invoice)}s");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                value => new InvoiceId(value)
            );


        builder.Property(x => x.IssuerAddressRef)
            .HasConversion(
                x => x.Value,
                value => new AddressIdRef(value)
            );

        builder.Property(x => x.ReceiptAddressRef)
            .HasConversion(
                x => x.Value,
                value => new AddressIdRef(value));

        // @todo transaction module
        builder.Ignore(x => x.TransactionId);


        builder.Property(x => x.IssuerTaxAdministration)
            .HasConversion(
                x => SerializeTaxAdministration(x),
                x => ParseTaxOffice(x));

        builder.Property(x => x.ReceiptTaxAdministration)
            .HasConversion(
                x => SerializeTaxAdministration(x),
                x => ParseTaxOffice(x));

        builder.HasMany(x => x.InvoiceItems).WithOne(x => x.Invoice).HasForeignKey(x => x.InvoiceId);

    }

    private string SerializeTaxAdministration(TaxAdministration administration)
    {
        return string.Join(',', [administration.TaxAdministrationOffice, administration.TaxId]);
    }

    private TaxAdministration ParseTaxOffice(string value)
    {
        var parsed = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
        return new TaxAdministration(parsed[0], parsed[2]);
    }
    
}