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
    public class ServicePayment : IServicePayment
    {
        private readonly AppDbContext _appDbContext;

        public ServicePayment(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelError> GetAll()
        {
            var items = await _appDbContext.Payments.ToListAsync();
            if (items != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = items };
            }
            return new ModelError() { IsError = true, Message = "There is no menu items exist" };
        }

        public async Task<ModelError> GetElement(int id)
        {
            var item = await _appDbContext.Payments.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item != null)
            {
                return new ModelError() { IsError = false, Message = "Successfully: load data....", Data = item };
            }
            return new ModelError() { IsError = true, Message = $"There is no payment item exist for this id {id}" };
        }

        public async Task<ModelError> Add(DtoPayment model)
        {
            if (model != null)
            {
                var checkOrder = _appDbContext.Orders.Where(x => x.Id == model.OrderId);
                if (checkOrder.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                Payment payment = new Payment()
                {
                    OrderId = model.OrderId,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = model.PaymentMethod.ToString(),
                    PaymentStatus = model.PaymentStatus.ToString()
                };

                await _appDbContext.Payments.AddAsync(payment);
                int result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                    return new ModelError() { IsError = false, Message = "Successfully: Add payment ....", Data = payment };
                else
                    return new ModelError() { IsError = true, Message = "Error: Cann't save this Payment item in database !" };
            }
            return new ModelError() { IsError = true, Message = "Error: Cann't add this payment item !" };
        }

        public async Task<ModelError> Update(int id, DtoPayment model)
        {
            if (model != null)
            {
                var checkOrder = _appDbContext.Orders.Where(x => x.Id == model.OrderId);
                if (checkOrder.IsNullOrEmpty())
                {
                    return new ModelError() { IsError = true, Message = $"Error: some data not found !" };
                }

                var item = await _appDbContext.Payments.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    item.OrderId = model.OrderId;
                    item.PaymentMethod = model.PaymentMethod.ToString();
                    item.PaymentStatus = model.PaymentStatus.ToString();
                    item.PaymentDate = DateTime.Now;

                    await _appDbContext.Payments.AddAsync(item);
                    int result = await _appDbContext.SaveChangesAsync();
                    if (result > 0)
                        return new ModelError() { IsError = false, Message = "Successfully: update Payment item....", Data = item };
                    else
                        return new ModelError() { IsError = true, Message = "Error: Cann't update this Payment item in database !" };
                }
                return new ModelError() { IsError = true, Message = $"Error: there is no Payment item with this id {id}" };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this Payments item !" };
        }

        public async Task<ModelError> Delete(int id)
        {
            var item = _appDbContext.Payments.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _appDbContext.Payments.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return new ModelError() { IsError = false, Message = $"Successfully: delete this Payment item with this id {id} ....", Data = item };
            }
            return new ModelError() { IsError = true, Message = "Error: error in this Payment item !" };
        }
    }
}
