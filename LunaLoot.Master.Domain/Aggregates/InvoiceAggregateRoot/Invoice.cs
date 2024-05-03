using LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot.Entities;
using LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot.Enums;
using LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

namespace LunaLoot.Master.Domain.InvoiceAggregateRoot;

public class Invoice: AggregateRoot<InvoiceId, string>
{
    
    #pragma warning disable CS8618
    public Invoice() {}
    #pragma warning restore CS8618

    public Invoice(
        InvoiceId id, TransactionIdRef transactionId,
        string receiptName, string receiptTitle,
        TaxAdministration receiptTaxAdministration,
        AddressIdRef receiptAddressRef,string issuerName,
        string issuerTitle, AddressIdRef issuerAddressRef,
        TaxAdministration issuerTaxAdministration,
        InvoiceType? invoiceType, List<InvoiceItem>? invoiceItems) : base(id)
    {
        TransactionId = transactionId;
        
        ReceiptName = receiptName;
        ReceiptTitle = receiptTitle;
        ReceiptAddressRef = receiptAddressRef;
        ReceiptTaxAdministration = receiptTaxAdministration;

        IssuerName = issuerName;
        IssuerTitle = issuerTitle;
        IssuerAddressRef = issuerAddressRef;
        IssuerTaxAdministration = issuerTaxAdministration;

        InvoiceType = invoiceType ?? InvoiceType.EArsiv;
        _invoiceItems = invoiceItems ?? [];

    }
    
    public required TransactionIdRef TransactionId { get; init; }
    public required string ReceiptName { get; init; }
    public required string ReceiptTitle { get; init; }
    
    
    
    public  TaxAdministration ReceiptTaxAdministration { get; init; }
    public AddressIdRef ReceiptAddressRef { get; init; }
    
    
    
    public required string IssuerName { get; init; }
    public required string IssuerTitle { get; init; }
    public required TaxAdministration IssuerTaxAdministration { get; init; }
    public required AddressIdRef IssuerAddressRef { get; init; }



    public InvoiceType InvoiceType { get; init; }


    // ReSharper disable once InconsistentNaming
    private List<InvoiceItem> _invoiceItems { get; init; } = [];
    public IReadOnlyList<InvoiceItem> InvoiceItems => _invoiceItems.AsReadOnly();

    public void AddInvoiceItem(InvoiceItem item)
    {
        _invoiceItems.Add(item);
    }
}