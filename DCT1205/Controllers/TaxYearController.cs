using DCT1205.Models;
using DCT1205.Services;
using Microsoft.AspNetCore.Mvc;

namespace DCT1205.Controllers
{
    public class TaxYearController : Controller
    {
        private ITaxYearService _taxyear;

        public TaxYearController(ITaxYearService taxyear)
        {
            _taxyear = taxyear;
        }
        public IActionResult Index()
        {
            var model = _taxyear.GetAll().Select(taxyear => new IndexTaxYearViewModel
            {
                Id = taxyear.Id,
            }).ToList();
            return View(model);
        }
    }
}
