﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Context
{
    public class FileSharingContext
    {
        internal IQueryable<TextFileModel> TextFileModels;
    }
}