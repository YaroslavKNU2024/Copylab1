using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabaOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {

        private readonly DBFinalContext _context;
        public ChartController(DBFinalContext context)
        {
            _context = context;
        }
        [HttpGet("JsonDataVirusVariants")]
        public JsonResult JsonDataVirusVariants()
        {
            var viruses = _context.Viruses.ToList();
            List<object> variant = new List<object>();
            variant.Add(new[] { "Вірус", "Кількість штамів" });
            foreach(var v in viruses)
            {
                variant.Add(new object[] { v.VirusName, _context.Variants
                    .Count(c => c.VirusId == v.Id)});
            }
            return new JsonResult(variant);
        }


    }
}
