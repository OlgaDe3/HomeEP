using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Context
{
    public class FileSharingContext
    {
        public int TextFiles;
        public IQueryable<TextFileModel> TextFileModels;

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
