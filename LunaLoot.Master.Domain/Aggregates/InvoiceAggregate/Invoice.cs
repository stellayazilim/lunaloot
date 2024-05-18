using LunaLoot.Master.Domain.Aggregates.InvoiceAggregate.Entities;
using LunaLoot.Master.Domain.Aggregates.InvoiceAggregate.Enums;
using LunaLoot.Master.Domain.Aggregates.InvoiceAggregate.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

namespace LunaLoot.Master.Domain.Aggregates.InvoiceAggregate;

public class Invoice: AggregateRoot<InvoiceId, string>
{
    
    #pragma warning disable CS8618
    // ReSharper disable once UnusedMember.Local
    private Invoice() {}
    #pragma warning restore CS8618

    private Invoice(
        InvoiceId id, 
        TransactionIdRef transactionId,
        string receiptName, 
        string receiptTitle,
        TaxAdministration receiptTaxAdministration,
        AddressIdRef receiptAddressRef,
        string issuerName,
        string issuerTitle, 
        AddressIdRef issuerAddressRef,
        TaxAdministration issuerTaxAdministration,
        InvoiceType? invoiceType, 
        List<InvoiceItem>? invoiceItems) : base(id)
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
        InvoiceItems = invoiceItems ?? [];

    }

    public static Invoice Create( 
        InvoiceId id, 
        TransactionIdRef transactionId,
        string receiptName, 
        string receiptTitle,
        TaxAdministration receiptTaxAdministration,
        AddressIdRef receiptAddressRef,
        string issuerName,
        string issuerTitle, 
        AddressIdRef issuerAddressRef,
        TaxAdministration issuerTaxAdministration,
        InvoiceType? invoiceType, 
        List<InvoiceItem>? invoiceItems
        ) => new(
            id, 
            transactionId, 
            receiptName, 
            receiptTitle, 
            receiptTaxAdministration, 
            receiptAddressRef, 
            issuerName, 
            issuerTitle, 
            issuerAddressRef, 
            issuerTaxAdministration, 
            invoiceType, 
            invoiceItems
        );

    public TransactionIdRef TransactionId { get; init; }
    public string ReceiptName { get; init; }
    public string ReceiptTitle { get; init; }
    
    
    
    public  TaxAdministration ReceiptTaxAdministration { get; init; }
    public AddressIdRef ReceiptAddressRef { get; init; }
    
    
    
    public  string IssuerName { get; init; }
    public  string IssuerTitle { get; init; }
    public  TaxAdministration IssuerTaxAdministration { get; init; }
    public  AddressIdRef IssuerAddressRef { get; init; }



    public InvoiceType InvoiceType { get; init; }


    public List<InvoiceItem> InvoiceItems { get; init; }

 
}