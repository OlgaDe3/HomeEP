using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.ViewModel
{
    public class ShareViewModel
    {
     
        
            public int FileId { get; set; }
            // List<AclModelViewModel> Users { get; set; }
            public IQueryable<AclModelViewModel> Users { get; set; }
            //public string SelectedUsername { get; set; }

       

        

    }
}
