using Data.Context;
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
    public class TextFileDBRepository
    {


        private FileSharingContext context { get; set; }

        public TextFileDBRepository(FileSharingContext _context)
        {
            context = _context;
        }
        public IQueryable<TextFileModel> GetTextFileModel()
        {
            return context.TextFileModels;
        }
        public void Share(Guid fileId, string recipient)
        {
            var file = context.TextFileModels.Find(fileId);
            if (file == null)
            {
                throw new Exception("File not found");
            }

            var acl = new AclModel
            {
                FileName = fileId,
                Username = recipient
            };
            context.AclModels.Add(acl);
            context.SaveChanges();
        }

        public void Edit(Guid fileId, string changes)
        {
            var file = context.TextFileModels.Find(fileId);
            if (file == null)
            {
                throw new Exception("File not found");
            }

            file.Data = changes;
            file.LastUpdated = DateTime.UtcNow;
            context.TextFileModels.Update(file);
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
    }
}

       // public List<TextFileModel> GetFileEntries()
        

            