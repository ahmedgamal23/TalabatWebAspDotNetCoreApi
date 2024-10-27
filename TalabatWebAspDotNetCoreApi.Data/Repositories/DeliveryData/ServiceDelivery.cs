using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.DeliveryData
{
    public class ServiceDelivery:IServiceDelivery
    {
        private readonly AppDbContext _appDbContext;

        public ServiceDelivery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelError> GetAll()
        {
            var items = await _appDbContext.Deliveries.ToListAsync();
            if (items != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = items };
            }
            return new ModelError() { IsError = true, Message = "There is no delivery data exist" };
        }

        public async Task<ModelError> GetElement(int id)
        {
            var item = await _appDbContext.Deliveries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = item };
            }
            return new ModelError() { IsError = true, Message = $"There is no delivery data exist for this id {id}" };
        }

        public async Task<ModelError> Add(DtoDelivery model)
        {
            if (model != null)
            {
                var checkUserDelivery = _appDbContext.Users.Where(x => x.Id == model.DeliveryPersonId);
                var checkOrder = _appDbContext.Orders.Where(x => x.Id == model.OrderId);
                if (checkUserDelivery.IsNullOrEmpty() || checkOrder.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                Delivery delivery = new Delivery()
                {
                    DeliveryTime = DateTime.Now,
                    DeliveryPersonId = model.DeliveryPersonId,
                    DeliveryStatus = model.DeliveryStatus.ToString(),
                    OrderId = model.OrderId
                };

                await _appDbContext.Deliveries.AddAsync(delivery);
                int result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                    return new ModelError() { IsError = false, Message = "Successfully: Add delivery data ....", Data = delivery };
                else
                    return new ModelError() { IsError = true, Message = "Error: Cann't save this delivery data in database !" };
            }
            return new ModelError() { IsError = true, Message = "Error: Cann't add this delivery data !" };
        }

        public async Task<ModelError> Update(int id, DtoDelivery model)
        {
            if (model != null)
            {
                var checkUserDelivery = _appDbContext.Users.Where(x => x.Id == model.DeliveryPersonId);
                var checkOrder = _appDbContext.Orders.Where(x => x.Id == model.OrderId);
                if (checkUserDelivery.IsNullOrEmpty() || checkOrder.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                var item = await _appDbContext.Deliveries.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    item.DeliveryTime = DateTime.Now;
                    item.DeliveryPersonId = model.DeliveryPersonId;
                    item.OrderId = model.OrderId;
                    item.DeliveryStatus = model.DeliveryStatus.ToString();

                    await _appDbContext.Deliveries.AddAsync(item);
                    int result = await _appDbContext.SaveChangesAsync();
                    if (result > 0)
                        return new ModelError() { IsError = false, Message = "Successfully: update delivery data....", Data = item };
                    else
                        return new ModelError() { IsError = true, Message = "Error: Cann't update this delivery data in database !" };
                }
                return new ModelError() { IsError = true, Message = $"Error: there is no delivery data with this id {id}" };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this delivery data !" };
        }

        public async Task<ModelError> Delete(int id)
        {
            var item = _appDbContext.Deliveries.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _appDbContext.Deliveries.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = $"Successfully: delete this delivery data with this id {id} ....", Data = item };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this delivery data !" };
        }
    }
}
