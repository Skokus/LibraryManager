using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public interface IPublishHouseService
    {
        public Task<IEnumerable<PublishHouseDTO>> BrowseAll();
        public Task DeleteAsync(int id);
        public Task AddAsync(PublishHouseDTO publishHouse);
        public Task<PublishHouseDTO> GetAsync(int id);
        public Task UpdateAsync(PublishHouseDTO publishHouse);
    }
}
