using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MekashronWeb.ViewModels;
using Microsoft.AspNetCore.Diagnostics;

namespace MekashronWeb.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            var pathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return View(new ErrorViewModel
            {
                ErrorMessage = pathFeature.Error?.InnerException?.Message ??
                               pathFeature.Error?.Message
            });
        }
    }
}
