﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.DataAccess.Data;

namespace CIF_DABLEU.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Product { get; private set; }
        public IUserRepository User { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public ISaleInvoiceRepository SaleInvoice { get; private set; }
        public ISaleInvoiceDetailRepository SaleInvoiceDetail { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
            // Aquí instanciaremos los otros repositorios
            User = new UserRepository(_context);
            Customer = new CustomerRepository(_context);
            SaleInvoice = new SaleInvoiceRepository(_context);
            SaleInvoiceDetail = new SaleInvoiceDetailRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
