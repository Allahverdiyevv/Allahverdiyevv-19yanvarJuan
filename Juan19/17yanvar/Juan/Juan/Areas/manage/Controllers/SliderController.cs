using Juan.Helpers;
using Juan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace Juan.Areas.manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly DataContext _dataContext;

        public SliderController(DataContext dataContext, IWebHostEnvironment env)
        {
            _env = env;
            _dataContext= dataContext;
        }
        public IActionResult Index()
        {
            List<Slider> sliderList = _dataContext.Sliders.ToList();
            return View(sliderList);
        }
        [HttpGet]
        public IActionResult Create()
        {
         

            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider.imagefile.ContentType != "image/png" && slider.imagefile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Jpeg and Png");
                return View();
            }

            if (slider.imagefile.Length > 3145728)
            {
                ModelState.AddModelError("ImageFile", "max 3 mb");
                return View();
            }


            slider.Image = FileManage.SaveFile(_env.WebRootPath, "Upload\\Slider", slider.imagefile);

            _dataContext.Sliders.Add(slider);
            _dataContext.SaveChanges();


            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            Slider slider = _dataContext.Sliders.Find(id);
            if (slider == null) return View("error");

            return View(slider);
       
        }

        [HttpPost]
        public IActionResult Update(Slider slider)
        {

            Slider exslider = _dataContext.Sliders.Find(slider.Id);
            if (exslider == null) return View("error");

            if (slider.imagefile !=null)
            {

            string name = FileManage.SaveFile(_env.WebRootPath , "Upload\\Slider" , slider.imagefile);

            FileManage.DeletFile(_env.WebRootPath, "Upload\\Slider", exslider.Image);

                exslider.Image = name;
            }


            

            exslider.Title1=slider.Title2;
            exslider.Title2 = slider.Title2;
            exslider.Desc = slider.Desc;

            _dataContext.SaveChanges();
            return RedirectToAction("index");


        }


    }
}
