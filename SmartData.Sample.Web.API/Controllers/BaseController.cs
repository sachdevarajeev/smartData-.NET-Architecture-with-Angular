using Microsoft.AspNetCore.Mvc;
using SmartData.Sample.ServiceContract;

namespace SmartData.Sample.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        IBaseService _baseService;

        public IBaseService BaseService
        {
            get { return _baseService; }
        }

        public BaseController(IBaseService baseService)
        {
            _baseService = baseService;
        }
    }
}