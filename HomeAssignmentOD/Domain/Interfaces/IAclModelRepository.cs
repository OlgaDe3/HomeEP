﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Domain.Interfaces
{
    public interface ITextFileRepository
    {
       
        IQueryable<AclModel> GetAclModels();
    }
}
