using System.ComponentModel.DataAnnotations;

namespace Invoice.Model
{
    public class InvoiceModel
    {
        [Key]
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }

        public string To_Name { get; set;}
        public string To_MobileNumber { get; set;}
        public string To_MSME_NO { get; set;}
        public string To_GSTIN_UIN { get; set;}
        public string To_PAN_IT { get; set;}
        public string To_Email { get; set;}
        public string To_Address { get; set;}
        public string Description { get; set;}
        public string Item { get; set;}
        public string HSN_SAC { get; set;}
        public int Qty { get; set;}
        public int Price { get; set;}
        public decimal Total { get; set;}
        public decimal CGST_Per { get; set; }
        public decimal CGST_Amount { get; set;}
        public decimal SGST_Per { get; set; }
        public decimal SGST_Amount { get; set;}
        public decimal TaxableAmount { get; set;}
        public decimal TDS_Per { get; set; }
        public decimal TDS_Amount { get; set; }
        public bool PaidByCustomer { get; set;}
        public DateTime InvoiceDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
