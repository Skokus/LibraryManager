using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    public class PublishHouseRepository : IPublishHouseRepository
    {
        private AppDbContext _appDbContext;
        public PublishHouseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(PublishHouse p)
        {
            try
            {
                _appDbContext.PublishHouse.Add(p);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<PublishHouse>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.PublishHouse);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task DeleteAsync(PublishHouse p)
        {
            try
            {
                _appDbContext.RemoveRange(_appDbContext.Book.Where(x => x.PublishHouse.Id == p.Id));
                _appDbContext.Remove(_appDbContext.PublishHouse.FirstOrDefault(x => x.Id == p.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<PublishHouse> GetAsync(int id)
        {
            try
            {
                return _appDbContext.PublishHouse.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(PublishHouse p)
        {
            try
            {
                var z = _appDbContext.PublishHouse.FirstOrDefault(x => x.Id == p.Id);

                z.Name = p.Name;
                z.Country = p.Country;
                z.EstablishDay = p.EstablishDay;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
