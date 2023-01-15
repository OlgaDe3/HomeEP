using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    // It represents an access control list for a file and should contain a FileName foreign key property and a Username property.
    public class AclModel
    { 
             [Key]
            public int Id { get; set; }
            public Guid FileName { get; set; }

            [ForeignKey("FileName")]
            public int AclId { get; set; }
            public TextFileModel TextFile { get; set; }
            public string Username { get; set; }
        

    }
}
