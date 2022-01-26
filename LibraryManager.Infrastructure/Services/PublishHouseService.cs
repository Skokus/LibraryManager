using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public class PublishHouseService : IPublishHouseService
    {
        private readonly IPublishHouseRepository _publishHouseRepository;
        public PublishHouseService(IPublishHouseRepository publishHouseRepository)
        {
            _publishHouseRepository = publishHouseRepository;
        }

        public async Task AddAsync(PublishHouseDTO publishHouse)
        {
            PublishHouse p = new PublishHouse()
            {
                Id = publishHouse.Id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            };
            await _publishHouseRepository.AddAsync(p); ;
        }

        public async Task<IEnumerable<PublishHouseDTO>> BrowseAll()
        {
            var z = await _publishHouseRepository.BrowseAllAsync();
            return z.Select(publishHouse => new PublishHouseDTO()
            {
                Id = publishHouse.Id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            });
        }

        public async Task DeleteAsync(int id)
        {
            var z = await _publishHouseRepository.GetAsync(id);
            await _publishHouseRepository.DeleteAsync(z);
        }

        public async Task<PublishHouseDTO> GetAsync(int id)
        {
            var publishHouse = await _publishHouseRepository.GetAsync(id);
            PublishHouseDTO p = new PublishHouseDTO()
            {
                Id = publishHouse.Id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            };
            return p;
        }

        public async Task UpdateAsync(PublishHouseDTO publishHouse)
        {
            PublishHouse p = new PublishHouse()
            {
                Id = publishHouse.Id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            };
            await _publishHouseRepository.UpdateAsync(p);
        }
    }
}
