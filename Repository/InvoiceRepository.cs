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
            param.Add("Mode", "GetInvoice");
            using (var connection = _context.Database.GetDbConnection())

            {
                var data = await connection.QueryAsync<InvoiceModel>("SP_Invoice", param, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
        }
    }
}
