using Microsoft.AspNetCore.Mvc;
using PortfolioCoreDay.Context;

namespace PortfolioCoreDay.ViewComponents
{
    public class _DefaultSliderComponentPartial:ViewComponent
    { 
        PortfolioContext context = new PortfolioContext();  
        public IViewComponentResult Invoke()
        {
            var values = context.MyWorks.ToList();
            return View(values);
        }
    }
}
