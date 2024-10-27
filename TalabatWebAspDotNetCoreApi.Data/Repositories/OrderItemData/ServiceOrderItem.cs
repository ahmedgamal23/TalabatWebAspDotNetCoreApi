using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.OrderItemData
{
    public class ServiceOrderItem :IServiceOrderItem
    {
        private readonly AppDbContext _appDbContext;

        public ServiceOrderItem(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelError> GetAll()
        {
            var items = await _appDbContext.OrderItems.ToListAsync();
            if (items != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = items };
            }
            return new ModelError() { IsError = true, Message = "There is no menu items exist" };
        }

        public async Task<ModelError> GetElement(int id)
        {
            var item = await _appDbContext.OrderItems.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = item };
            }
            return new ModelError() { IsError = true, Message = $"There is no menu item exist for this id {id}" };
        }

        public async Task<ModelError> Add(DtoOrderItem model)
        {
            if (model != null)
            {
                var checkOrder = _appDbContext.Orders.Where(x => x.Id == model.OrderId);
                var checkMenu = _appDbContext.MenuItems.Where(x => x.Id == model.MenuItemId);
                if (checkOrder.IsNullOrEmpty() || checkMenu.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                OrderItem orderItem = new OrderItem()
                {
                    MenuItemId = model.MenuItemId,
                    OrderId = model.OrderId,
                    price = model.price,
                    Quantity = model.Quantity
                };

                await _appDbContext.OrderItems.AddAsync(orderItem);
                int result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                    return new ModelError() { IsError = false, Message = "Successfully: Add Order item....", Data = orderItem };
                else
                    return new ModelError() { IsError = true, Message = "Error: Cann't save this order item in database !" };
            }
            return new ModelError() { IsError = true, Message = "Error: Cann't add this order item !" };
        }

        public async Task<ModelError> Update(int id, DtoOrderItem model)
        {
            if (model != null)
            {
                var checkOrder = _appDbContext.Orders.Where(x => x.Id == model.OrderId);
                var checkMenu = _appDbContext.MenuItems.Where(x => x.Id == model.MenuItemId);
                if (checkOrder.IsNullOrEmpty() || checkMenu.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                var item = await _appDbContext.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    item.MenuItemId = model.MenuItemId;
                    item.OrderId = model.OrderId;
                    item.price = model.price;
                    item.Quantity = model.Quantity;

                    await _appDbContext.OrderItems.AddAsync(item);
                    int result = await _appDbContext.SaveChangesAsync();
                    if (result > 0)
                        return new ModelError() { IsError = false, Message = "Successfully: update order item....", Data = item };
                    else
                        return new ModelError() { IsError = true, Message = "Error: Cann't update this order item in database !" };
                }
                return new ModelError() { IsError = true, Message = $"Error: there is no order item with this id {id}" };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this order item !" };
        }

        public async Task<ModelError> Delete(int id)
        {
            var item = _appDbContext.OrderItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _appDbContext.OrderItems.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = $"Successfully: delete this order item with this id {id} ....", Data = item };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this order item !" };
        }
    }
}
