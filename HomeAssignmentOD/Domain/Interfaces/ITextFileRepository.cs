using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ITextFileRepository
    {
        TextFileModel GetTextFileModels(int id);
        void Edit(TextFileModel textFile);
    }
}
