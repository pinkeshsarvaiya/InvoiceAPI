using Invoice.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Invoice
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<InvoiceModel> UserSubscriptionPlans { get; set; }
    }
}
