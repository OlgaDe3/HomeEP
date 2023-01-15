using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.ViewModel
{
    public class AclModelViewModel
    {
        public int Id { get; set; }
        public Guid FileName { get; set; }
        public TextFileModel TextFile { get; set; }
        public string Username { get; set; }
    }
}
