using Data.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    //It should contain methods for performing business logic related to the file sharing application,
    //such as validating input, interacting with the repository, and interacting with the view models.
    public class FileService
    {
        private TextFileDBRepository tr;
        public FileService(TextFileDBRepository _textFileDBRepository)
        {
            tr = _textFileDBRepository;
        }

       
       



        //public void Share(int fileId, string recipient)
        //{
        //    tr.Share(fileId, recipient);

        //}

        //public void Edit(int fileId, string changes)
        //{
        //    // Check if the user has permission to edit the file
        //    if (!HasEditPermission(user, fileName))
        //    {
        //        throw new UnauthorizedAccessException("User does not have permission to edit this file.");
        //    }




        //}

        //private bool HasEditPermission(object user, object fileName)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Create(TextFileModel f)
        //{
        //    tr.Create(f);
        //}
    }
}



