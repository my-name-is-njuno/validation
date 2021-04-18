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
    public class CrudProvider : ICrudProvider
    {
        private readonly ProjectDbContextOptionFactory _context;

        public CrudProvider(ProjectDbContextOptionFactory context)
        {
            _context = context;
        }

        public async Task<Provider> Create(Provider entity)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var newEntity = await context.Set<Provider>().AddAsync(entity);
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var deleteEntity = await context.Set<Provider>().FirstOrDefaultAsync(a => a.Id == id);
                if (deleteEntity != null)
                {
                    context.Set<Provider>().Remove(deleteEntity);
                    return true;
                }
                return false;
            }
        }

        public async Task<Provider> Get(int id)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var getEntity = await context.Set<Provider>().FirstOrDefaultAsync(a => a.Id == id);
                return getEntity;
            }
        }

        public async Task<List<Provider>> GetAll()
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var allEntity = await context.Set<Provider>().ToListAsync();
                return allEntity;
            }
        }

        public async Task<Provider> GetByCode(string code)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var pr = await context.Providers.Include(a => a.Deliveries).Include(a => a.Users).Where(a => a.Code == code).FirstOrDefaultAsync();
                return pr;
            }
        }

        public async Task<Provider> GetByName(string name)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var pr = await context.Providers.Include(a => a.Deliveries).Include(a=>a.Users).Where(a => a.Name == name).FirstOrDefaultAsync();
                return pr;
            }
        }

        public async Task<List<Provider>> GetHospitals()
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var providers = await context.Providers.Where(a => a.Code.Contains("PRO")).ToListAsync();
                return providers;
            }
        }

        public async Task<Provider> Update(int id, Provider entity)
        {
            entity.Id = id;

            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var updateEntity = context.Set<Provider>().Update(entity);
                await context.SaveChangesAsync();
                return updateEntity.Entity;
            }
        }
    }
}
