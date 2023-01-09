using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Context
{
    //This class should go in the Data layer. It should represent the database context,
    //which is responsible for interacting with the database and performing operations such
    //as querying and saving data.


    public class FileSharingContext : IdentityDbContext
    {
        public FileSharingContext(DbContextOptions<FileSharingContext> options)
               : base(options)
        {
        }

        public DbSet<TextFileModel> TextFileModels { get; set; } //an abstraction of the tables therefore plural name

        public DbSet<AclModel> AclModels { get; set; }
    }
}
