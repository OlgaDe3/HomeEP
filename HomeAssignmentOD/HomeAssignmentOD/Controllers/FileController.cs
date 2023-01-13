using Application.Services;
using Application.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace HomeAssignmentOD.Controllers
{
    public class FileController : Controller
    {
        
        private FileService fileService;
        private AclModelService aclModelService;
        private IWebHostEnvironment host;
        public FileController(FileService _fileService, AclModelService _aclModelService, IWebHostEnvironment _host)
        {
            fileService = _fileService;
            aclModelService = _aclModelService;
            host = _host;
            
        }



        // a method to handle the submission of the form
        [HttpGet]
        // Action to handle the Create view
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTextFileModelViewModel data, IFormFile file)
        {
            fileService.Create(data);

            // Check if file is not null
            if (file == null || file.Length == 0)
                return Content("file not selected");

            // Get the absolute path to the Data folder in the website
            var path = Path.Combine(host.WebRootPath, "Data");

            // Generate a unique file name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Create the file in the Data folder
            using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return View(data);
        }



        // Action to handle the Share view
        //[HttpGet]
        //public IActionResult Share()
        //{
        //    var aclModels = fileService.GetAclModels();
        //    CreateTextFileModelViewModel myModel = new CreateTextFileModelViewModel();
        //    myModel.AclModelViewModels = aclModels.ToList();

        //    return View(myModel);
        //    //    var users = context.Users.Select(u => new { u.Id, u.Username });
        //    //    ViewBag.Users = new SelectList(users, "Id", "Username");
        //    //    return View();
        //}



        //[HttpPost]
        //public IActionResult Share(int userId, string fileName)
        //{
        //    // Implement code to share the file with the selected user
        //    var user = context.Users.GetAclModels(userId);
        //    // Add the file to the user's shared files list
        //    user.SharedFiles.Add(fileName);
        //    context.SaveChanges();
        //}




        // Action to handle the Edit view
        //[Authorize]
        //public IActionResult Edit(string fileName, int id)
        //{

        //    var originalTextFile = fileService.GetTextFileModels(id);
        //    var aclModels = aclModelService.GetAclModels();

        //    CreateTextFileModelViewModel model = new CreateTextFileModelViewModel();
        //    model.Categories = categories.ToList();
        //    model.FileName = originalTextFile.FileName();
        //    model.UploadedOn = originalTextFile.Name;
        //    model.Data = originalTextFile.Data;
        //    model.Author = originalTextFile.Author;
        //    model.LastEditedBy = originalTextFile.PhotoPath;
        //    model.LastUpdated = originalTextFile.LastUpdated;
         

        //    return View(model);


        //    var currentUser = User.Identity.Name;
        //    var user = _context.Users.FirstOrDefault(u => u.Username == currentUser);
        //    if (user.SharedFiles.Contains(fileName))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return Forbid(); //This means that the client has authenticated successfully but does not have access to the requested resource.
        //    }
        //}

        //[HttpPost]
        //[Authorize]
        //public IActionResult Edit(string fileName, string newContent)
        //{
        //    // Implement code to edit the file
        //    var currentUser = User.Identity.Name;
        //    var user = _context.Users.FirstOrDefault(u => u.Username == currentUser);
        //    if (user.SharedFiles.Contains(fileName))
        //    {
        //        // Code to update the file content
        //        return View();
        //    }
        //    else
        //    {
        //        return Forbid();
        //    }
    }   //}
}

