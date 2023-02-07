using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaLogistica.Domain.DTO;
using SistemaLogistica.Domain.IServices;
using SistemaLogistica.Web.Models;

namespace SistemaLogistica.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _service;
        private readonly IPersonService _personService;
        public FornecedorController(IFornecedorService service, IPersonService personService)
        {
            _service = service;
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.FindAll());
        }
        public IActionResult Create(int id)
        {
            ViewData["personId"] = new SelectList(_personService.FindAll(), "id", "name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, personId")]FornecedorDTO fornecedor)
        {
            if (ModelState.IsValid)
            {
                if(await _service.Save(fornecedor) > 0) 
                    return RedirectToAction(nameof(Index));
            }
            ViewData["personId"] = new SelectList(_personService.FindAll(), "id", "name");
            return View(fornecedor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewData["personId"] = new SelectList(_personService.FindAll(), "id", "name");
            return View(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, name")] FornecedorDTO fornecedor)
        {
            if(!(id == fornecedor.id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _service.Save(fornecedor) > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
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
                if(await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDel
                    {
                        status = "Error",
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
            }
            return Json(retDel);
        }
    }
}
