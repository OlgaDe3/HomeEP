using Data.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class TextFileDBRepository
    {

        
        private FileSharingContext context { get; set; }

        public TextFileDBRepository(FileSharingContext _context)
        {
             context = _context;
        }
        

        

        public void Share(int fileId, string recipient)
        {
            
        }


        public void Edit(int fileId, string changes)
        {

        }


        public void Create(TextFileModel f)
        {

        }

        public IEnumerable<string> GetPermissions(int fileId)
        {
            // Retrieve the text file from the database
            var textFile = context.TextFiles.FirstOrDefault(f => f.Id == fileId);
            if (textFile == null)
            {
                throw new Exception($"Text file with ID {fileId} was not found.");
                
            }

            // Return a list of recipients that have been granted access to the text file
            return context.TextFileAccesses
                .Where(a => a.TextFile == textFile)
                .Select(a => a.Recipient)
                .ToList();
        }

        public IEnumerable<TextFileModel> GetFileEntries()
        {
            // Retrieve a list of all text files from the database
            return context.TextFiles.ToList();
        }



    }


}
        


