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
using Microsoft.CodeAnalysis.Options;
using System.Linq;
using System.Collections.Generic;

namespace HomeAssignmentOD.Controllers
{
    public class FileController : Controller
    {
        
        private FileService fileService;
        private aclModelService aclModelService;
        private IWebHostEnvironment host;
        public FileController(FileService _fileService, aclModelService _aclModelService, IWebHostEnvironment _host)
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
        public IActionResult Create(CreateTextFileModelViewModel datas, IFormFile file)
        {
            fileService.Create(datas);

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

            return View(datas);
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

        [HttpGet]
        public IActionResult Share(int fileId)
        {
            var users = aclModelService.GetAclModels();
            var model = new ShareViewModel
            {
                FileId = fileId,
                Users = users
             };
            return View(model);

            
        }

        [HttpPost]
        public IActionResult Share(int fileId, string recipient)
        {
            try
            {
                fileService.Share(fileId, recipient);
                ViewBag.Message = "File shared successfully with " + recipient;
            }
            catch (Exception ex)
            {
                if (ex.Message == "File not found")
                {
                    ViewBag.Error = "File not found. Sharing operation couldn't be completed";
                }
                else
                {
                    ViewBag.Error = "An error occurred while sharing the file";
                }
            }

            var users = aclModelService.GetAclModels();
            var model = new ShareViewModel 
            { 
                FileId = fileId, 
                Users = users 
            };
            return View(model);
           
        }

        //Share.cshtml
        //    <div class="text-danger">@ViewData["Error"]</div>
        //<div>
        //    <label for="Recipient">Recipient:</label>
        //    <select id = "Recipient" name="Recipient">
        //        <option value = "" > Please select a recipient</option>
        //        @foreach(var user in Model.Users)
        //    {
        //            < option value = "@user.Email" > @user.Email </ option >
        //        }
        //    </select>
        //</div>
        //<span class="text-danger">@ViewData.ModelState["Recipient"].Errors[0].ErrorMessage</span>


        [Authorize]
        public IActionResult Edit(string fileName, int id)
        {
            var originalTextFile = fileService.GetTextFileModels();
            var aclModels = aclModelService.GetAclModels();

            CreateTextFileModelViewModel model = new CreateTextFileModelViewModel();
            model.AclModelViewModels = aclModels.ToList();
            model.FileName = originalTextFile.FileName;
            model.UploadedOn = originalTextFile.UploadedOn;
            model.Data = originalTextFile.Data;
            model.Author = originalTextFile.Author;
            model.LastEditedBy = originalTextFile.LastEditedBy;
            model.LastUpdated = originalTextFile.LastUpdated;


            var currentUser = User.Identity.Name;
            var user = aclModelService.Users.FirstOrDefault(u => u.Username == currentUser);
            if (user.SharedFiles.Contains(fileName))
            {
                return View(model);
            }
            else
            {
                return Forbid(); //This means that the client has authenticated successfully but does not have access to the requested resource.
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(string fileName, string newContent)
        {
            var currentUser = User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.Username == currentUser);
            if (user.SharedFiles.Contains(fileName))
            {
                fileService.Edit(fileName, newContent);
                
            }
            else
            {
                return Forbid();
            }
        }


    }
}

