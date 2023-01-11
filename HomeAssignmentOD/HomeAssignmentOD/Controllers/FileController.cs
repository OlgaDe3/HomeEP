using Application.Services;
using Application.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HomeAssignmentOD.Controllers
{
    public class FileController : Controller
    {

        private  FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }



        public IActionResult Share(int fileId)
        {
            var users = _fileService.GetUsers(); // method to get a list of all users from the database
            var model = new CreateTextFileModelViewModel { FileId = fileId, Users = users };
            return View(model);
        }

        [HttpPost]
        public IActionResult Share(CreateTextFileModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                _fileService.Share(model.FileId, model.SelectedUsername);
                return RedirectToAction("Index");
            }
            else
            {
                model.Users = _fileService.GetUsers();
                return View(model);
            }
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTextFileModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                _fileService.Create(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }



        //a method to open the page, then the user starts typing 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        // a method to handle the submission of the form
        [HttpPost]
        public IActionResult Create(CreateTextFileModelViewModel text)
        {
            fileService.AddItem(text);
            return View();

        }



    }

}

