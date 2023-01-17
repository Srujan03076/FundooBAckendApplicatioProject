using Microsoft.EntityFrameworkCore;
using Repolayer.Entities;
using System;
using System.Collections.Generic;

using System.Text;

namespace Repolayer.Context
{
    public class FundooContext : DbContext
    {


        public FundooContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> UserTable { get; set; }
        public DbSet<Notes> NoteTable { get; set; }
        public DbSet<Collaborator> CollaborationTable { get; set; }
        public DbSet<Label> LabelTable { get; set; }
    }
}

  