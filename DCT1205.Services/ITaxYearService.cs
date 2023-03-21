using DCT1205.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT1205.Services
{
    public interface ITaxYearService
    {
        IEnumerable<TaxYear> GetAll();
        TaxYear GetById(int id);
        Task CreateAsSync(TaxYear taxYear);
        Task UpdateAsSync(TaxYear taxYear);
        Task UpdateAsSync(int id);
        Task DeleteById(int id);
    }
}
