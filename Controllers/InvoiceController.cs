using Azure;
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

        [HttpGet("GetInvoiceById")]
        public async Task<ActionResult<InvoiceModel>> GetInvoicesById(int InvoiceID)
        {
            var invoices = await _invoiceRepository.GetinvoiceById(InvoiceID);
            return Ok(invoices);
        }
        [HttpPost("AddUpdateInvoice")]
        public async Task<ActionResult> AddUpdateInvoice([FromBody] InvoiceModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invoice model is null.");
                }

                var invoices = await _invoiceRepository.AddUpdateInvoice(model);

                if (invoices == null)
                {
                    return BadRequest("Invoice could not be processed.");
                }

                return Ok(invoices);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteInvoice")]
        public async Task<ActionResult<GeneralModel>> DeleteInvoice(int InvoiceID)
        {
            try
            {
                var result = await _invoiceRepository.DeleteInvoice(InvoiceID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
