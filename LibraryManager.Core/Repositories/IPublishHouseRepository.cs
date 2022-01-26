using LibraryManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Repositories
{
    public interface IPublishHouseRepository
    {
        Task AddAsync(PublishHouse p);
        Task UpdateAsync(PublishHouse p);
        Task DeleteAsync(PublishHouse p);
        Task<PublishHouse> GetAsync(int id);
        Task<IEnumerable<PublishHouse>> BrowseAllAsync();
    }
}
