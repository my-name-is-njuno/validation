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
    public class CrudUser : ICrudUser
    {
        private readonly ProjectDbContextOptionFactory _context;

        public CrudUser(ProjectDbContextOptionFactory context)
        {
            _context = context;
        }

        public async Task<User> Create(User entity)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var newEntity = await context.Set<User>().AddAsync(entity);
                context.Entry(entity.Provider).State = EntityState.Unchanged;
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var deleteEntity = await context.Set<User>().FirstOrDefaultAsync(a => a.Id == id);
                if (deleteEntity != null)
                {
                    context.Set<User>().Remove(deleteEntity);
                    return true;
                }
                return false;
            }
        }

        public async Task<User> Get(int id)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var getEntity = await context.Set<User>().FirstOrDefaultAsync(a => a.Id == id);
                return getEntity;
            }
        }

        public async Task<List<User>> GetAll()
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var allEntity = await context.Set<User>().ToListAsync();
                return allEntity;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var getEntity = await context.Set<User>().Where(a => a.Email == email).Include(a => a.Provider).Include(a => a.Deliverys).FirstOrDefaultAsync();
                return getEntity;
            }
        }

        public async Task<User> GetByUserName(string name)
        {
            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var getEntity = await context.Set<User>().Where(a => a.Name == name).Include(a => a.Provider).Include(a => a.Deliverys).FirstOrDefaultAsync();
                return getEntity;
            }
        }

        public async Task<User> Update(int id, User entity)
        {
            entity.Id = id;

            using (ProjectDbContext context = _context.CreateDbContext())
            {
                var updateEntity = context.Set<User>().Update(entity);
                await context.SaveChangesAsync();
                return updateEntity.Entity;
            }
        }
    }
}
