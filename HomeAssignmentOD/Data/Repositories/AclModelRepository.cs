using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class AclModelRepository: ITextFileRepository
    {
        private FileSharingContext context { get; set; }

        public AclModelRepository(FileSharingContext _context)
        {
            context = _context;
        }

        

        public IQueryable<AclModel> GetAclModels()
        {
            return context.AclModels;
        }

       

        IQueryable<AclModel> ITextFileRepository.GetAclModels()
        {
            throw new NotImplementedException();
        }

        
    }

   
}
