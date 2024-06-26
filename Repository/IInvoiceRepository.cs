using Invoice.Model;

namespace Invoice.Repository
{
    public interface IInvoiceRepository
    {
        public Task<List<InvoiceModel>> Getinvoice();

    }
}
