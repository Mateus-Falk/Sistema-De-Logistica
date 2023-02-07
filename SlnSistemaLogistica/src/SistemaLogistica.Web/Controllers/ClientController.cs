using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaLogistica.Domain.DTO;
using SistemaLogistica.Domain.IServices;
using SistemaLogistica.Web.Models;

namespace SistemaLogistica.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _service;
        private readonly IPersonService _personService;
        public ClientController(IClientService service, IPersonService personService)
        {
            _service = service;
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.FindAll());
        }

        public IActionResult Create()
        {
            ViewData["personId"] = new SelectList(_personService.FindAll(), "id","name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, personId")] ClientDTO client)
        {
            if (ModelState.IsValid)
            {
                if(await _service.Save(client)>0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["personId"] = new SelectList(_personService.FindAll(), "id","name");
            return View(client);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound(); 
            }
            ViewData["personId"] = new SelectList(_personService.FindAll(), "id","name");
            return View(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, personId")] ClientDTO client)
        {
            if (!(id == client.id)) 
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if(await _service.Save(client)>0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["personId"] = new SelectList(_personService.FindAll(), "id","name");
            return View(client);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "success",
                code = "200"
            };

            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDel
                    {
                        status = "error",
                        code = "400"
                    };
                }
            }
            catch (Exception ex)
            {
                retDel = new ReturnJsonDel
                {
                    status = ex.Message,
                    code = "500"
                };
                throw;
            }
            return Json(retDel);
        }
    }
}
