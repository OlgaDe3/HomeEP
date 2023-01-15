using Application.ViewModel;
using Data.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Services
{
    //It should contain methods for performing business logic related to the file sharing application,
    //such as validating input, interacting with the repository, and interacting with the view models.
    public class FileService
    {
        private TextFileDBRepository tr;
        private AclModelRepository ar;
        public FileService(TextFileDBRepository _textFileDBRepository, AclModelRepository _aclModelRepository)
        {
            tr = _textFileDBRepository;
            ar = _aclModelRepository;
        }

        public TextFileModel GetTextFileModel(int id)
        {
            return tr.GetTextFileModel(id);
        }

        public IQueryable<TextFileModelViewModel> GetTextFileModels()
        {

            var list = from t in tr.GetTextFileModels() //flatten this into 1 line using AutoMapper
                       select new TextFileModelViewModel()
                       {
                           Id = t.Id,
                           FileName = t.FileName,
                           UploadedOn = t.UploadedOn,
                           Data = t.Data,
                           Author = t.Author,
                           LastEditedBy = t.LastEditedBy,
                           LastUpdated = t.LastUpdated,
                       };
            return list;

        }
        public TextFileModelViewModel TextFileModel(int id)
        {
            return GetTextFileModels().SingleOrDefault(x => x.Id == id);
        }

        public void Create(CreateTextFileModelViewModel file)
        {
            if (tr.GetTextFileModels().Any(myFile => myFile.FileName == file.FileName))
                throw new Exception("Item with the same name already exists");
            else
            {
                tr.Create(new Domain.Models.TextFileModel()
                {
                    FileName = file.FileName, //AutoMapper
                    UploadedOn = file.UploadedOn,
                    Data = file.Data,
                    Author = file.Author,
                    LastEditedBy = file.LastEditedBy,
                    LastUpdated = file.LastUpdated
                });
            }
        }
        

        public void Share(int fileId, string recipient)
        {
            try
            {
                tr.Share(fileId, recipient);
            }
            catch (Exception ex)
            {
                if (ex.Message == "File not found")
                {
                    throw new Exception("File not found. Sharing operation couldn't be completed", ex);
                }
                throw;
            }
        }

        public void Edit(int id, CreateTextFileModelViewModel updatedTextFile)
        {
            //check if user has permission to edit the file
            if (!HasEditPermission.CanEdit(updatedTextFile.LastEditedBy, id))
            {
                throw new Exception("User does not have permission to edit this file");
            }
            tr.Edit(
                new Domain.Models.TextFileModel()
                {
                    Id = id,
                    FileName = updatedTextFile.FileName, //AutoMapper
                    UploadedOn = updatedTextFile.UploadedOn,
                    Data = updatedTextFile.Data,
                    Author = updatedTextFile.Author,
                    LastEditedBy = updatedTextFile.LastEditedBy,
                    LastUpdated = updatedTextFile.LastUpdated
                }
                );

        }

        public bool HasEditPermission(string user, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}





