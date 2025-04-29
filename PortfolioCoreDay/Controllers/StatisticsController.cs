using Microsoft.AspNetCore.Mvc;
using PortfolioCoreDay.Context;

namespace PortfolioCoreDay.Controllers
{
    public class StatisticsController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = context.Skills.Count();
            ViewBag.v2 = context.Skills.Sum(x => x.SkillValue);
            ViewBag.v3 = context.Skills.Average(x => x.SkillValue);
            ViewBag.v4 = context.Skills.Where(x => x.SkillValue>80).Count();
            ViewBag.v5=context.Messages.Count();
            ViewBag.v6=context.Messages.Where(x=>x.IsRead==true).Count();
            ViewBag.v7=context.Messages.Where(x=>x.IsRead==false).Count();
            ViewBag.v8=context.Messages.Where(x=>x.NameSurname=="Salih Dilmen").Count();
            ViewBag.v9 =context.Portfolios.Count();
            ViewBag.v10=context.Testimonials.Count();

            return View();
        }
    }
}
