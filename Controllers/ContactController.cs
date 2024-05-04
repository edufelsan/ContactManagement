using ContactManagementNew.Data;
using ContactManagementNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementNew.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.contactModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.contactModel.Add(model);
                _dbContext.SaveChanges();

                TempData["SuccessMessage"] = "Contact created successfully.";

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult Details(int id)
        {
            var contact = _dbContext.contactModel.FirstOrDefault(c => c.Id == id);
            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _dbContext.contactModel.FirstOrDefault(c => c.Id == id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var contact = _dbContext.contactModel.FirstOrDefault(c => c.Id == model.Id);

            if (contact != null)
            {
                contact.Name = model.Name;
                contact.Contact = model.Contact;
                contact.Email = model.Email;

                _dbContext.SaveChanges();
            }

            TempData["SuccessMessage"] = "Contact edited successfully.";

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var contact = _dbContext.contactModel.FirstOrDefault(c => c.Id == id);
            return View(contact);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = _dbContext.contactModel.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            _dbContext.contactModel.Remove(contact);
            _dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Contact deleted successfully.";

            return RedirectToAction("Index");
        }

    }
}
