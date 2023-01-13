using Application.ViewModel;
using Domain.Interfaces;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class AclModelService
    {
        private IAclModelRepository ar;
        public AclModelService(IAclModelRepository _aclModelRepository)
        {
            ar = _aclModelRepository;

        }

        public IQueryable<AclModelViewModel>GetAclModels()
        { //AutoMapper -- still to be implemented to replace the following code:
            var list = from a in ar.GetAclModels()
                       select new AclModelViewModel()
                       {
                           Id = a.Id,
                           FileName = a.FileName,
                           TextFile = a.TextFile,
                           Username = a.Username,
                       };
            return list;
        }
    }
}

