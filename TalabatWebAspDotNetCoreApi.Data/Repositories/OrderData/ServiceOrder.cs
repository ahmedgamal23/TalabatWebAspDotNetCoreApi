using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.OrderData
{
    public class ServiceOrder : IServiceData<DtoOrder>
    {
        private readonly AppDbContext _appDbContext;

        public ServiceOrder(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelError> GetElement(int id)
        {
            var item = await _appDbContext.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return new ModelError() { IsError = false, Message = $"Successfully: Data is loaded...", Data=item};
            }
            return new ModelError() { IsError = true, Message = $"Error : there is no order with this id {id} !" };
        }

        public async Task<ModelError> Add(DtoOrder dtoOrder)
        {
            if (dtoOrder != null)
            {
                var orderItem = await _appDbContext.OrderItems.Where(x => x.Id == dtoOrder.OrderItemId).SingleOrDefaultAsync();
                var RestaurantItem = await _appDbContext.Restaurants.Where(x => x.Id == dtoOrder.RestaurantId).SingleOrDefaultAsync();
                var userItem = await _appDbContext.Users.Where(x => x.Id == dtoOrder.UserId).SingleOrDefaultAsync();

                if (orderItem == null || RestaurantItem == null || userItem == null)
                {
                    return new ModelError() { IsError = true, Message = $"Error Missing Information : cann't add this order {dtoOrder} !" };
                }

                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderStatus = dtoOrder.OrderStatus.ToString(),
                    OrderItemId = dtoOrder.OrderItemId,
                    RestaurantId = dtoOrder.RestaurantId,
                    TotalAmount = dtoOrder.TotalAmount,
                    UserId = dtoOrder.UserId,
                };
                _appDbContext.Orders.Add(order);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = $"Successfully: Data is saved...", Data = order };
            }
            return new ModelError() { IsError = true, Message = $"Error: cann't add this order {dtoOrder} !" };
        }

        public async Task<ModelError> Update(int id, DtoOrder dtoOrder)
        {
            var item = await _appDbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(item != null)
            {
                if (dtoOrder != null)
                {
                    item.OrderDate = DateTime.Now;
                    item.OrderStatus = dtoOrder.OrderStatus.ToString();
                    item.OrderItemId = dtoOrder.OrderItemId;
                    item.RestaurantId = dtoOrder.RestaurantId;
                    item.TotalAmount = dtoOrder.TotalAmount;
                    item.UserId = dtoOrder.UserId;
                    _appDbContext.Orders.Add(item);
                    await _appDbContext.SaveChangesAsync();
                    return new ModelError() { IsError = false, Message = $"Successfully: Data is updated...", Data = item };
                }
            }
            return new ModelError() { IsError = true, Message = $"Error: there is no order with this id {id} !" };
        }

        public async Task<ModelError> Delete(int id)
        {
            var item = await _appDbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(item != null)
            {
                _appDbContext.Orders.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = $"Successfully: Delete this order {id}...", Data = item };
            }
            return new ModelError() { IsError = true, Message = $"Error: there is no order with this id {id} !" };
        }
    }
}
