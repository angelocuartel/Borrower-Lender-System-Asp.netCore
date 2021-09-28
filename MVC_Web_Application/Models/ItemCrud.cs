using Microsoft.EntityFrameworkCore;
using MVC_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application.Models
{
    public class ItemCrud : IDbAction<Item>
    {


        private readonly AppDbContext _appDbContext;

        public ItemCrud(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Item item)
        {
            using (_appDbContext)
            {
              await  _appDbContext.Items.AddAsync(item);
              await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Item item)
        {
            using (_appDbContext)
            {
                 _appDbContext.Remove(item);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Item>> GetAllData()
        {
            return await _appDbContext.Items.ToListAsync();
        }

        public async Task Update(Item item)
        {
            using (_appDbContext)
            {
                 _appDbContext.Update(item);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
