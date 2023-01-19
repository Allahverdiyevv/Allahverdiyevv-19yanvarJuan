using Juan.Helpers;
using Juan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Juan.Areas.manage.Controllers
{
    [Area("Manage")]
    public class ShoeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly DataContext _dataContext;

        public ShoeController(DataContext dataContext , IWebHostEnvironment env)
        {
            _env=env;
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            List<Shoe> shoes = _dataContext.SlidersShoe.ToList();

            return View(shoes);
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(Shoe shoe)
        {
            if (shoe.imagefile.ContentType != "image/png" && shoe.imagefile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Jpeg and Png");
                return View();
            }

            if (shoe.imagefile.Length > 3145728)
            {
                ModelState.AddModelError("ImageFile", "max 3 mb");
                return View();
            }


            shoe.Image = FileManage.SaveFile(_env.WebRootPath, "Upload\\Shoe", shoe.imagefile);

            _dataContext.SlidersShoe.Add(shoe);
            _dataContext.SaveChanges();


            return RedirectToAction("index");
        }
    }
}
