using Data.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
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

    }
}
