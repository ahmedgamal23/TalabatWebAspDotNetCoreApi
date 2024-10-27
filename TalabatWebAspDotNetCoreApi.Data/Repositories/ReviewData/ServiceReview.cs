using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.ReviewData
{
    public class ServiceReview: IServiceReview
    {
        private readonly AppDbContext _appDbContext;

        public ServiceReview(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelError> GetAll()
        {
            var items = await _appDbContext.Reviews.ToListAsync();
            if (items != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = items };
            }
            return new ModelError() { IsError = true, Message = "There is no reviews exist" };
        }

        public async Task<ModelError> GetElement(int id)
        {
            var item = await _appDbContext.Reviews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = item };
            }
            return new ModelError() { IsError = true, Message = $"There is no reviews exist for this id {id}" };
        }

        public async Task<ModelError> Add(DtoReview model)
        {
            if (model != null)
            {
                var checkUser = _appDbContext.Users.Where(x => x.Id == model.UserId);
                var checkRestaurants = _appDbContext.Restaurants.Where(x => x.Id == model.RestaurantId);
                if (checkUser.IsNullOrEmpty() || checkRestaurants.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                Review review = new Review()
                {
                    Rating = model.Rating,
                    Comment = model.Comment,
                    RestaurantId = model.RestaurantId,
                    UserId = model.UserId,
                    ReviewDate = DateTime.Now
                };

                await _appDbContext.Reviews.AddAsync(review);
                int result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                    return new ModelError() { IsError = false, Message = "Successfully: Add review ....", Data = review };
                else
                    return new ModelError() { IsError = true, Message = "Error: Cann't save this review in database !" };
            }
            return new ModelError() { IsError = true, Message = "Error: Cann't add this review !" };
        }

        public async Task<ModelError> Update(int id, DtoReview model)
        {
            if (model != null)
            {
                var checkUser = _appDbContext.Users.Where(x => x.Id == model.UserId);
                var checkRestaurants = _appDbContext.Restaurants.Where(x => x.Id == model.RestaurantId);
                if (checkUser.IsNullOrEmpty() || checkRestaurants.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                var item = await _appDbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    item.ReviewDate = DateTime.Now;
                    item.UserId = model.UserId;
                    item.RestaurantId = model.RestaurantId;
                    item.Comment = model.Comment;
                    item.Rating = model.Rating;

                    await _appDbContext.Reviews.AddAsync(item);
                    int result = await _appDbContext.SaveChangesAsync();
                    if (result > 0)
                        return new ModelError() { IsError = false, Message = "Successfully: update Reviews....", Data = item };
                    else
                        return new ModelError() { IsError = true, Message = "Error: Cann't update this Reviews in database !" };
                }
                return new ModelError() { IsError = true, Message = $"Error: there is no Reviews with this id {id}" };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this Reviews !" };
        }

        public async Task<ModelError> Delete(int id)
        {
            var item = _appDbContext.Reviews.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _appDbContext.Reviews.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = $"Successfully: delete this Reviews with this id {id} ....", Data = item };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this Reviews !" };
        }
    }
}
