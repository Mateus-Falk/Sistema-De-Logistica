using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaLogistica.Domain.DTO;
using SistemaLogistica.Domain.IServices;
using SistemaLogistica.Web.Models;

namespace SistemaLogistica.Web.Controllers
{
    public class InOutController : Controller
    {
        private readonly IInOutService _service;
        private readonly IProductService _productService;
        private readonly IClientService _clientService;
        public InOutController(IInOutService service, IProductService productService, IClientService clientService)
        {
            _service = service;
            _productService = productService;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.FindAll());
        }

        public IActionResult Create()
        {
            ViewData["productId"] = new SelectList(_productService.FindAll(), "id", "name");
            ViewData["clientId"] = new SelectList(_clientService.FindAll(), "id", "person.name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, inOrOut, time, productId, quantity, userName, clientId")] InOutDTO inOut)
        {
            if(ModelState.IsValid)
            {
                if(await _service.Save(inOut) > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(inOut);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_productService.FindAll(), "id", "name");
            ViewData["clientId"] = new SelectList(_clientService.FindAll(), "id", "person.name");
            return View(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,[Bind("id, inOrOut, time, productId, quantity, userName, clientId")] InOutDTO inOut)
        {
            if(!(id == inOut.id)) 
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (await _service.Save(inOut) > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(inOut);
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
