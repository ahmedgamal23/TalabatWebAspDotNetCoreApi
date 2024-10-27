using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.MenuItemData
{
    public class ServiceMenuItem : IServiceMenuItem
    {
        private readonly AppDbContext _appDbContext;

        public ServiceMenuItem(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelError> GetAll()
        {
            var menuItems = await _appDbContext.MenuItems.ToListAsync();
            if(menuItems != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data=menuItems };
            }
            return new ModelError() { IsError = true, Message = "There is no menu items exist" };
        }

        public async Task<ModelError> GetElement(int id)
        {
            var menuItem = await _appDbContext.MenuItems.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (menuItem != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = menuItem };
            }
            return new ModelError() { IsError = true, Message = $"There is no menu item exist for this id {id}" };
        }

        public async Task<ModelError> Add(DtoMenuItem model)
        {
            if (model != null)
            {
                var check = _appDbContext.Restaurants.Where(x => x.Id == model.RestaurantId);
                if (check.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: this restaurant id {model.RestaurantId} not found !" };
                }

                MenuItem menuItem = new MenuItem()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Category = model.Category,
                    RestaurantId = model.RestaurantId
                };
                await _appDbContext.MenuItems.AddAsync(menuItem);
                int result = await _appDbContext.SaveChangesAsync();
                if(result > 0)
                    return new ModelError() { IsError = false, Message = "Successfully: Add menu item....", Data = menuItem };
                else
                    return new ModelError() { IsError = true, Message = "Error: Cann't save this menu item in database !" };
            }
            return new ModelError() { IsError = true, Message = "Error: Cann't add this menu item !" };
        }

        public async Task<ModelError> Update(int id, DtoMenuItem model)
        {
            if(model != null)
            {
                var check = _appDbContext.Restaurants.Where(x => x.Id == model.RestaurantId);
                if (check.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: this restaurant id { model.RestaurantId } not found !" };
                }
                
                var item = await _appDbContext.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
                if(item  != null)
                {
                    item.Description = model.Description;
                    item.Price = model.Price;
                    item.Category = model.Category;
                    item.RestaurantId= model.RestaurantId;
                    item.Name = model.Name;

                    await _appDbContext.MenuItems.AddAsync(item);
                    int result = await _appDbContext.SaveChangesAsync();
                    if (result > 0)
                        return new ModelError() { IsError = false, Message = "Successfully: update menu item....", Data = item };
                    else
                        return new ModelError() { IsError = true, Message = "Error: Cann't update this menu item in database !" };
                }
                return new ModelError() { IsError = true, Message = $"Error: there is no menu item with this id {id}" };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this menu item !" };
        }

        public async Task<ModelError> Delete(int id)
        {
            var item = _appDbContext.MenuItems.FirstOrDefault(x => x.Id == id);
            if(item != null)
            {
                _appDbContext.MenuItems.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = $"Successfully: delete this menu item with this id {id} ....", Data = item };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this menu item !" };
        }

    }
}
