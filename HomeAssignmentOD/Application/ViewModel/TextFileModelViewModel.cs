using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel
{
    public class TextFileModelViewModel
    {
        public int Id { get; set; }
        public Guid FileName { get; set; }
        public DateTime UploadedOn { get; set; }
        public string Data { get; set; }
        public string Author { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
