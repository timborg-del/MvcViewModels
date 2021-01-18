using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcViewModels.Model.Data;
using MvcViewModels.Model.Data.Database;
using MvcViewModels.Model;
using MvcViewModels.Model.Services;
using Microsoft.AspNetCore.Http;

namespace MvcViewModels.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly RegistryDbContext _context;
        private readonly IPeopleService _peopleService;
        private readonly ILanguageService _languageService;
        public LanguagesController(IPeopleService peopleService, ILanguageService languageService)
        {
            _languageService = languageService; 
            _peopleService = peopleService;
        }

        // GET: Languages
        public ActionResult Index()
        {
            LanguageViewModel languageList = _languageService.All();
            return View(languageList.LanguagesList);
        }

        // GET: Languages/Details/5
        public ActionResult Details(int id)
        {
            Language language = _languageService.FindBy(id);

            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Languages/Create
        public IActionResult Create()
        {
            CreateLanguageViewModel createLanguageViewModel = new CreateLanguageViewModel();
            createLanguageViewModel.Languages = _languageService.All().LanguagesList;
            return View(createLanguageViewModel);
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateLanguageViewModel createLanguageViewModel)
        {
            if (ModelState.IsValid)
            {
               
                _languageService.Add(createLanguageViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(createLanguageViewModel);
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(int id)
        {
            Language language = _languageService.FindBy(id);

            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Language language)
        {
            CreateLanguageViewModel createLanguage = new CreateLanguageViewModel();
            createLanguage.Name = language.Name;
            //createLanguage.Languages = language.Languages;


            Language editLangue = _languageService.Edit(language.Id, createLanguage);

            return RedirectToAction(nameof(Index));

        }

        // GET: Languages/Delete/5
        public ActionResult Delete(int id)
        {

            if (_languageService.Remove(id))
            {
                ViewBag.msg = "Language Was Removed.";
            }
            else
            {
                ViewBag.msg = "Unable to remove language with id: " + id;
            }

            return RedirectToAction(nameof(Index));


        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
