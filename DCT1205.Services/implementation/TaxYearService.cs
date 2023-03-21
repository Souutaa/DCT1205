using DCT1205.Entity;
using DCT1205.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT1205.Services.implementation
{
    internal class TaxYearService : ITaxYearService
    {
        private ApplicationDbContext _context;

        public TaxYearService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsSync(TaxYear taxYear)
        {
            _context.Add(taxYear);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var tax = GetById(id);
            if (tax != null)
            {
                _context.TaxYear.Remove(tax);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<TaxYear> GetAll()
        {
            return _context.TaxYear.ToList();
        }

        public TaxYear GetById(int id)
        {
            return _context.TaxYear.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(TaxYear taxYear)
        {
            _context.TaxYear.Update(taxYear);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSync(int id)
        {
            var taxyear = GetById(id);
            _context.TaxYear.Add(taxyear);
            await _context.SaveChangesAsync();
        }
    }
}
