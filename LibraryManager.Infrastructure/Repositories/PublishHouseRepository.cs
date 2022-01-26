using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    public class PublishHouseRepository : IPublishHouseRepository
    {
        public Task AddSync(PublishHouse p)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PublishHouse>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PublishHouse p)
        {
            throw new NotImplementedException();
        }

        public Task<PublishHouse> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PublishHouse p)
        {
            throw new NotImplementedException();
        }
    }
}
