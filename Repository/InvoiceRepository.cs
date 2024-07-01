using Dapper;
using Invoice.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace Invoice.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {

        private readonly AppDBContext _context;
        public InvoiceRepository(AppDBContext context)
        {
            _context = context;
        }

       

        public async Task<List<InvoiceModel>> Getinvoice()
        {
            var param = new DynamicParameters();
            param.Add("@Mode", "GetInvoice");
            using (var connection = _context.Database.GetDbConnection())

            {
                var data = await connection.QueryAsync<InvoiceModel>("SP_Invoice", param, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
        }

        public async Task<InvoiceModel> GetinvoiceById(int InvoiceID)
        {
            var param = new DynamicParameters();
            param.Add("@Mode", "GetInvoiceById");
            param.Add("@InvoiceID", InvoiceID);
            using (var connection = _context.Database.GetDbConnection())

            {
                var data = await connection.QueryFirstOrDefaultAsync<InvoiceModel>("SP_Invoice", param, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
        public async Task<GeneralModel> AddUpdateInvoice(InvoiceModel model)
        {
            try
            {
                var param = new DynamicParameters();
                if (model.InvoiceID == 0)
                {
                    param.Add("@Mode", "AddInvoice");
                }
                else
                {
                    param.Add("@Mode", "UpdateInvoice");
                    param.Add("@InvoiceID", model.InvoiceID);

                }
                param.Add("@InvoiceID", model.InvoiceID);
                param.Add("@InvoiceNumber", model.InvoiceNumber);
                param.Add("@To_Name", model.To_Name);
                param.Add("@To_MobileNumber", model.To_MobileNumber);
                param.Add("@To_GSTIN_UIN", model.To_GSTIN_UIN);
                param.Add("@To_PAN_IT", model.To_PAN_IT);
                param.Add("@To_MSME_NO", model.To_MSME_NO);
                param.Add("@To_Email", model.To_Email);
                param.Add("@To_Address", model.To_Address);
                param.Add("@Item", model.Item);
                param.Add("@HSN_SAC", model.HSN_SAC);
                param.Add("@Qty", model.Qty);
                param.Add("@Price", model.Price);
                param.Add("@Total", model.Total);
                param.Add("@CGST_Per", model.CGST_Per);
                param.Add("@CGST_Amount", model.CGST_Amount);
                param.Add("@SGST_Per", model.SGST_Per);
                param.Add("@SGST_Amount", model.SGST_Amount);
                param.Add("@Description", model.Description);
                param.Add("@TaxableAmount", model.TaxableAmount);
                param.Add("@InvoiceDate", model.InvoiceDate.UtcDateTime);
                var result = await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<GeneralModel>("SP_Invoice", param, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralModel> DeleteInvoice(int InvoiceID)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Mode", "DeleteInvoice");
                param.Add("@InvoiceID", InvoiceID );
                var result = await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<GeneralModel>("SP_Invoice", param, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
