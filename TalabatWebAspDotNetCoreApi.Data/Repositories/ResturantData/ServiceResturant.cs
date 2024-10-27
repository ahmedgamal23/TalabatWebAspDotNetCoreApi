using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.Resturant
{
    public class ServiceResturant : IServiceResturant
    {
        private readonly AppDbContext _appDbContext;

        public ServiceResturant(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelError> GetAll()
        {
            var allResturant = await _appDbContext.Restaurants.ToListAsync();

            if (allResturant.Count != 0)
            {
                return new ModelError() { IsError = false, Message = "Successfully load data", Data = allResturant };
            }
            return new ModelError() { IsError = true, Message = "No Resturent Found !" };
        }

        public async Task<ModelError> GetElement(int id)
        {
            var resturant = await _appDbContext.Restaurants.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (resturant != null)
            {
                return new ModelError() { IsError=false, Message ="Successfully load data", Data = resturant };
            }
            return new ModelError() { IsError = true, Message = $"this resturant id {id} not found !" };
        }

        public async Task<ModelError> Add(DtoResturant model)
        {
            if(model != null)
            {
                Restaurant restaurant = new Restaurant()
                {
                    Description = model.Description,
                    Name = model.Name,
                    Location = model.Location,
                    OpeningHours = model.OpeningHours,
                    Rating = model.Rating
                };
                _appDbContext.Restaurants.Add(restaurant);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = "Successfully: Restaurant is added....", Data=restaurant };
            }
            return new ModelError() { IsError = true, Message = "Error: No resturant to add it !"}; 
        }

        public async Task<ModelError> Update(int id, DtoResturant model)
        {
            if (model != null)
            {
                var restaurant = await _appDbContext.Restaurants.Where(x => x.Id == id).FirstOrDefaultAsync();
                if(restaurant != null)
                {
                    restaurant.Description = model.Description;
                    restaurant.Location = model.Location;
                    restaurant.Rating = model.Rating;
                    restaurant.OpeningHours = model.OpeningHours;
                    restaurant.Name = model.Name;

                    _appDbContext.Restaurants.Update(restaurant);
                    await _appDbContext.SaveChangesAsync();
                    return new ModelError() { IsError = false, Message = "Successfully: update the restaurant....." };
                }
                return new ModelError() { IsError = true, Message = $"Error: No resturant exist with this id {id} !" };
            }
            return new ModelError() { IsError = true, Message = "Error: No resturant to update it !" };
        }

        public async Task<ModelError> Delete(int id)
        {
            var restaurant = await _appDbContext.Restaurants.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(restaurant != null)
            {
                _appDbContext.Restaurants.Remove(restaurant);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = "Successfully: delete resturant...." };
            }
            return new ModelError() { IsError = true, Message = $"Error: No resturant exist with this id {id} !" };
        }

    }
}
