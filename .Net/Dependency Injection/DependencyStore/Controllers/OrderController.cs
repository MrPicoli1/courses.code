using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeService _deliveryFeeService;
    private readonly IPromocodeRepository _promocodeRepository;

    public OrderController(ICustomerRepository customerRepository, IDeliveryFeeService deliveryFeeService, IPromocodeRepository promocodeRepository)
    {
        _customerRepository = customerRepository;
        _deliveryFeeService = deliveryFeeService;
        _promocodeRepository = promocodeRepository;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
    {
        // #1 - Recupera o cliente        
       var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null)
        {
            return NotFound();
        }


        var deliveryFee=  await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);
        var cupon = await _promocodeRepository.GetPromoCodeAsync(promoCode);
        var discount = cupon?.Value ?? 0M;



        // #5 - Gera o pedido
        var order = new Order(deliveryFee, discount, new List<Product>());
      
        // #7 - Retorna
        return Ok( $"Pedido {order.Code} gerado com sucesso!");
    }
}