using Invoice.Model;
using Invoice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        [HttpGet("GetInvoice")]
        public async Task<ActionResult<List<InvoiceModel>>> GetInvoices()
        {
            var invoices = await _invoiceRepository.Getinvoice();
            return Ok(invoices);
        }
    }
}
