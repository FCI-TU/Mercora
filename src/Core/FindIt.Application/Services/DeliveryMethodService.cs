using AutoMapper;
using FindIt.Application.ErrorHandling;
using FindIt.Application.Interfaces;
using FindIt.Domain.Interfaces;
using FindIt.Domain.OrderEntities;
using FindIt.Shared.Checkout;

namespace BlazorEcommerce.Infrastructure.Services;
public class DeliveryMethodService(IUnitOfWork unitOfWork, IMapper mapper) : IDeliveryMethodService
{
    public async Task<Result<IReadOnlyList<OrderDeliveryMethodModel>>> GetAllDeliveryMethodsAsync()
    {
        var deliveryMethodsRepo = unitOfWork.Repository<OrderDeliveryMethod>();

        var deliveryMethods = await deliveryMethodsRepo.GetAllAsync();

        var deliveryMethodsResponse = mapper.Map<IReadOnlyList<OrderDeliveryMethodModel>>(deliveryMethods);

        return Result.Success(deliveryMethodsResponse);
    }

    public async Task<Result<OrderDeliveryMethodModel>> GetDeliveryMethodByIdAsync(int id)
    {
        var deliveryMethodsRepo = unitOfWork.Repository<OrderDeliveryMethod>();

        var deliveryMethod = await deliveryMethodsRepo.GetByIdAsync(id);

        var deliveryMethodResponse = mapper.Map<OrderDeliveryMethodModel>(deliveryMethod);

        return deliveryMethod == null ? Result.Failure<OrderDeliveryMethodModel>(new Status(404, $"Delivery method with id {id} not found")) 
	        : Result.Success(deliveryMethodResponse);
    }

    public async Task<Result<OrderDeliveryMethodModel>> CreateDeliveryMethodAsync(OrderDeliveryMethodModel deliveryMethod)
    {
        var orderDeliveryMethod = mapper.Map<OrderDeliveryMethod>(deliveryMethod);

        var deliveryMethodsRepo = unitOfWork.Repository<OrderDeliveryMethod>();

        await deliveryMethodsRepo.AddAsync(orderDeliveryMethod);

        var result = await unitOfWork.CompleteAsync();

        return result <= 0 ? Result.Failure<OrderDeliveryMethodModel>(new Status(500, "Failed to create delivery method")) 
	        : Result.Success(deliveryMethod);
    }

    public async Task<Result<OrderDeliveryMethodModel>> UpdateDeliveryMethodAsync(int id, OrderDeliveryMethodModel deliveryMethod)
    {
        var deliveryMethodsRepo = unitOfWork.Repository<OrderDeliveryMethod>();

        var existingDeliveryMethod = await deliveryMethodsRepo.GetByIdAsync(id);

        if (existingDeliveryMethod == null)
            return Result.Failure<OrderDeliveryMethodModel>(new Status(404, $"Delivery method with id {id} not found"));

        mapper.Map(deliveryMethod, existingDeliveryMethod);

        deliveryMethodsRepo.Update(existingDeliveryMethod);

        var result = await unitOfWork.CompleteAsync();

        var deliveryMethodResponse = mapper.Map<OrderDeliveryMethodModel>(existingDeliveryMethod);

        return result <= 0 ? Result.Failure<OrderDeliveryMethodModel>(new Status(500, "Failed to update delivery method")) : 
	        Result.Success(deliveryMethodResponse);
    }

    public async Task<Result<OrderDeliveryMethodModel>> DeleteDeliveryMethodAsync(int id)
    {
        var deliveryMethodsRepo = unitOfWork.Repository<OrderDeliveryMethod>();

        var deliveryMethod = await deliveryMethodsRepo.GetByIdAsync(id);

        if (deliveryMethod == null)
            return Result.Failure<OrderDeliveryMethodModel>(new Status(404, $"Delivery method with id {id} not found"));

        deliveryMethodsRepo.Delete(deliveryMethod);

        var result = await unitOfWork.CompleteAsync();

        var deliveryMethodResponse = mapper.Map<OrderDeliveryMethodModel>(deliveryMethod);

        return result <= 0 ? Result.Failure<OrderDeliveryMethodModel>(new Status(500, "Failed to delete delivery method")) 
	        : Result.Success(deliveryMethodResponse);
    }

}