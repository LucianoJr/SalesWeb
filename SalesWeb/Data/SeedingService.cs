using SalesWeb.Models;
using SalesWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Data
{
    public class SeedingService
    {
        private SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any())
            {
                return; // DB já populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Books");

            Seller s1 = new Seller(1, "Fabia", "fabia@gmail.com", new DateTime(1990, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Jose", "jose@gmail.com", new DateTime(1990, 4, 21), 2000.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2022, 10,10), 10000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2022, 10, 10), 1000.0, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1,s2);
            _context.SalesRecords.AddRange(r1, r2);
            _context.SaveChanges();

        }
    }
}
