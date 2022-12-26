using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class AclModel
    {
        
            public Guid FileName { get; set; }

            [ForeignKey("FileName")]
            public TextFileModel TextFile { get; set; }

            public string Username { get; set; }
        

    }
}
