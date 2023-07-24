﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CompanyDbContext _context;
        public void CreateDbContextInstance(DbContext context)
        {
            _context =(CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync()
        {
           int count= await _context.SaveChangesAsync();
            return count;
        }
    }
}
