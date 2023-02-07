using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaLogistica.Domain.DTO;
using SistemaLogistica.Domain.IServices;
using SistemaLogistica.Web.Models;
using SistemaLogistica.Web.Models.DTO;

namespace SistemaLogistica.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly IFornecedorService _fornecedorService;
        public ProductController(IProductService service, ICategoryService categoryService, IFornecedorService fornecedorService)
        {
            _service = service;
            _categoryService = categoryService;
            _fornecedorService = fornecedorService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.FindAll());
        }

        public IActionResult Create()
        {
            ViewData["fornecedorId"] = new SelectList(_fornecedorService.FindAll(), "id", "person.name");
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, name, fornecedorId, quantityStock, quantityMinimun, image, categoryId")] ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                if (await _service.Save(product) > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["fornecedorId"] = new SelectList(_fornecedorService.FindAll(), "id", "person.name");
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name");
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["fornecedorId"] = new SelectList(_fornecedorService.FindAll(), "id", "person.name");
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name");
            return View(await _service.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, name, fornecedorId, quantityStock, quantityMinimun, image, categoryId")] ProductDTO product)
        {
            if (!(id == product.id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _service.Save(product) > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["fornecedorId"] = new SelectList(_fornecedorService.FindAll(), "id", "person.name");
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name");
            return View(product);
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

        public IActionResult ImagePost(int id)
        {
            ImageFieldProduct productModel = new ImageFieldProduct();
            if(id != null)
            {
                productModel.idProduct = id;
            }
            return View(productModel);
        }
        [HttpPost]
        public async Task<IActionResult> ImagePost(int idProduct, List<IFormFile> imageProduct)
        {
            try
            {
                if(idProduct == null)
                {
                    ViewBag.Message = $"O Id é null";
                    return View(new ImageFieldProduct() { idProduct = idProduct });
                }

                var file = imageProduct.FirstOrDefault();
                var fileName = $"{idProduct}_{file.FileName}";
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot//Uploads",fileName);
            
                if (await _service.SaveFile(idProduct,fileName) > 0)
                {
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = $"Não foi possível salvar o arquivo: {path}";
                return View(new ImageFieldProduct() { idProduct = idProduct , imageProduct = fileName});
            }
            catch (Exception ex)
            {

                ViewBag.Message = $"Error: {ex.Message}";
            }
            return View();
        }
    }
}
