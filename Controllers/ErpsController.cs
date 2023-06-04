using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ErpsController : ControllerBase
    {

        IErpService _erpService;

        public ErpsController(IErpService erpService)
        { 
            _erpService = erpService;   
        }

        [HttpGet("getall")]
        public IActionResult Index()
        {
            var result = _erpService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Erp erp)
        {
            var result = _erpService.Add(erp);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getFilters")]
        public IActionResult Filters(string? invoceNo, string? customerNo, DateTime? startDate, DateTime? endDate)
        {
            var result = _erpService.GetFilter(invoceNo, customerNo, startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
