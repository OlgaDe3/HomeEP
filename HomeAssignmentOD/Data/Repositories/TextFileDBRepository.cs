using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    //It should contain methods for interacting with the TextFile data in the database, such as Edit, Create, Share, and GetFile(s).
    public class TextFileDBRepository : ITextFileRepository
    {
        public readonly IEnumerable<object> Users;

        private FileSharingContext context { get; set; }

        public TextFileDBRepository(FileSharingContext _context)
        {
            context = _context;
        }

        public IQueryable<TextFileModel> GetTextFileModels()
        {
            return context.TextFileModels;
        }
    
        public void Share(int fileId, string recipient)
        {
            var file = context.TextFileModels.Find(fileId);
            if (file == null)
            {
                throw new Exception("File not found");
            }

            if (!context.Users.Any(u => u.UserName == recipient))
            {
                throw new Exception("Recipient does not exist or does not have access to the file");
            }

            if (file.SharedUsers.Any(u => u == recipient))
            {
                throw new Exception("Recipient already has access to this file");
            }
            file.SharedUsers.Add(recipient);
            context.TextFileModels.Update(file);
            context.SaveChanges();
        }


        public TextFileModel GetTextFileModel(int id)
        {
            return context.TextFileModels.SingleOrDefault(x => x.Id == id);
        }

        public void Edit(int fileId, TextFileModel updatedTextFile)
        {
            var file = context.TextFileModels.Find(fileId);
            if (file == null)
            {
                throw new Exception("File not found");
            }

            //1. get the original item from the db

            var originaTextFile = GetTextFileModel(updatedTextFile.Id); //the Id should never be allowed to change

            //2. update the details which were supposed to be updated one by one


            originaTextFile.FileName = updatedTextFile.FileName; //AutoMapper
            originaTextFile.UploadedOn = updatedTextFile.UploadedOn;
            originaTextFile.Data = updatedTextFile.Data;
            originaTextFile.Author = updatedTextFile.Author;
            originaTextFile.LastEditedBy = updatedTextFile.LastEditedBy;
            originaTextFile.LastUpdated = updatedTextFile.LastUpdated;
            context.SaveChanges();

        }

        public void Create(TextFileModel f)
        {
            context.TextFileModels.Add(f);
            context.SaveChanges();
        }

        public List<AclModel> GetPermissions(Guid fileId)
        {
            return context.AclModels.Where(a => a.FileName == fileId).ToList();
        }

        public IEnumerable<object> GetUsers()
        {
            throw new NotImplementedException();
        }

        public TextFileModel GetTextFileModels(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AclModel> GetAclModels()
        {
            throw new NotImplementedException();
        }

        public void Edit(TextFileModel textFile)
        {
            throw new NotImplementedException();
        }
    }
}

       // public List<TextFileModel> GetFileEntries()
        

            