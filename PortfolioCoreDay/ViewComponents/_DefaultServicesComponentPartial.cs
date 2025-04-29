using Microsoft.AspNetCore.Mvc;
using PortfolioCoreDay.Context;

namespace PortfolioCoreDay.ViewComponents
{
    public class _DefaultServicesComponentPartial:ViewComponent
    {
        PortfolioContext context = new PortfolioContext();  
        public IViewComponentResult Invoke()
        {
            var values = context.Services.ToList();

            return View(values);  
        }
    }
}
