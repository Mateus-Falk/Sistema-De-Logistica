using Microsoft.AspNetCore.Mvc;
using SistemaLogistica.Domain.DTO;
using SistemaLogistica.Domain.IServices;
using SistemaLogistica.Web.Models;

namespace SistemaLogistica.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, name, cep, country, uf, city, neighbourhood, street, number")] PersonDTO person)
        {
            if (ModelState.IsValid)
            {
                if (await _service.Save(person) > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return View(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, name, cep, country, uf, city, neighbourhood, street, number")]PersonDTO person)
        {
            if (!(id == person.id)) 
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                if(await _service.Save(person) > 0) 
                    return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Success",
                code = "200"
            };

            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDel
                    {
                        status = "Error",
                        code = "400"
                    };
                }
            }
            catch(Exception ex)
            {
                retDel = new ReturnJsonDel
                {
                    status = ex.Message,
                    code = "500"
                };
            }
            return Json(retDel);
        }
    }
}
