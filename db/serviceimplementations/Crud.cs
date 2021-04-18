using db.dbmodels;
using db.services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.serviceimplementations
{
    public class Crud<T> : ICrud<T> where T : BaseDbModel
    {
        private readonly ProjectDbContextOptionFactory _context;

        public Crud(ProjectDbContextOptionFactory context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var newEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var deleteEntity = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
                if (deleteEntity != null)
                {
                    context.Set<T>().Remove(deleteEntity);
                    return true;
                }
                return false;
            }
        }

        public async Task<T> Get(int id)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var getEntity = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
                return getEntity;
            }
        }

        public async Task<List<T>> GetAll()
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var allEntity = await context.Set<T>().ToListAsync();
                return allEntity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;

            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var updateEntity = context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return updateEntity.Entity;
            }
        }
    }
}
