using Microsoft.AspNetCore.Mvc;
using PortfolioCoreDay.Context;
using PortfolioCoreDay.Entities;

namespace PortfolioCoreDay.Controllers
{
    public class ContactController : Controller
    {
        PortfolioContext context = new PortfolioContext();

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View(); 
        }

        [HttpPost]

        public IActionResult SendMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            var values = context.Messages.Add(message);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderilmiştir!";
            return RedirectToAction("Index","Default");
        }


        public IActionResult Index() 
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        [HttpGet]

        public IActionResult EditContact(int id) 
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]

        public IActionResult EditContact(Contact contact) 
        {
            context.Contacts.Update(contact);
            context.SaveChanges();  
            return RedirectToAction("Index");
        }

    }
}
