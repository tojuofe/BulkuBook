﻿using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            SP_CAll = new SP_CALL(_context);
        }

        public ICategoryRepository Category { get; private set; }

        public ISP_CALL SP_CAll { get; private set; }

        public void Dispose() => _context.Dispose();

        public void Save() => _context.SaveChanges();
       
    }
}