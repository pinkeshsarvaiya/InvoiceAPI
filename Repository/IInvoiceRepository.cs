using Invoice.Model;

namespace Invoice.Repository
{
    public interface IInvoiceRepository
    {
        public Task<List<InvoiceModel>> Getinvoice();
        public Task<InvoiceModel> GetinvoiceById(int InvoiceID);
        public Task<GeneralModel> AddUpdateInvoice(InvoiceModel model);
        public Task<bool> DeleteInvoice(int InvoiceID);


    }
}
