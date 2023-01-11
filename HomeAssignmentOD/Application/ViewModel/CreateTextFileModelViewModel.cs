using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Application.ViewModel
{
    public class CreateTextFileModelViewModel
    {
        public List<AclModelViewModel> AclModelViewModels { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be blank")]
        public Guid FileName { get; set; }

        [Display(Name = "FileName")]
        public int AclModelId { get; set; }

        public DateTime UploadedOn { get; set; }

        public string Data { get; set; }

        public string Author { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastUpdated { get; set; }

       






       
       
        
        
    }
}
