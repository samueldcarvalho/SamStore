﻿using Microsoft.EntityFrameworkCore;
using SamStore.Catalogo.API.Data.Contexts;
using SamStore.Catalogo.API.Domain.Interfaces;
using SamStore.Catalogo.API.Domain.Products;
using SamStore.Core.Infrastructure.Data;

namespace SamStore.Catalogo.API.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
        }
        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
