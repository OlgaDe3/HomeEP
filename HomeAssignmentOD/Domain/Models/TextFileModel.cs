﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    //It represents a text file and should contain properties such as FileName, UploadedOn, Data, Author, LastEditedBy, and LastUpdated.
    public class TextFileModel
    {
        [Key]
        public int Id { get; set; }
        public Guid FileName { get; set; }
        public DateTime UploadedOn { get; set; }
        public string Data { get; set; }
        public string Author { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
