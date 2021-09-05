using Lottery.Entities.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lottery.Api.Controllers
{
    public class TestController : Controller
    {
        private readonly TestUseCase uc;

        public TestController(TestUseCase uc)
        {
            this.uc = uc;
        }
        public IActionResult Index()
        {
            uc.AddData();
            return View();
        }
    }
}
