using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.InvoiceAggregate.ValueObjects;

public class TaxAdministration
    (
        string taxAdministrationOffice,
        string taxId
        ): ValueObject
{
    public string TaxAdministrationOffice { get; private init; } = taxAdministrationOffice;
    public string TaxId { get; private init; } = taxId;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return TaxAdministrationOffice;
        yield return TaxId;
    }
}