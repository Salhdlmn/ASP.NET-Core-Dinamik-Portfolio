using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioCoreDay.Context;
using PortfolioCoreDay.Entities;

namespace PortfolioCoreDay.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult ProjectList()
        {
            var values = context.Portfolios.Include(x=>x.Category).ToList();
            return View(values);
        }

        [HttpGet]

        public IActionResult CreatePortfolio()
        {
            var values = new SelectList(context.Categories.ToList(),"CategoryID","CategoryName");
            ViewBag.v=values;
            return View();
        }

        [HttpPost]

        public IActionResult CreatePortfolio(Portfolio portfolio)
        {

            context.Portfolios.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }


        public IActionResult DeleteProject(int id)
        {
            var values = context.Portfolios.Find(id);
            context.Portfolios.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ProjectList");            

        }

        [HttpGet]

        public IActionResult UpdateProject(int id)
        {
            var value = context.Portfolios.Find(id);
                return View (value);

        }

        [HttpPost]  

        public IActionResult UpdateProject(Portfolio portfolio)
        {
            context.Portfolios.Update(portfolio);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateProject(Portfolio portfolio)
        {
            var value = context.Portfolios.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }


    }
}
