using Business.Abstract;
using Entities.Concrete;
using Entities.ViewModels.Carriers;
using Entities.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }


    [HttpGet(template: "getall")]
    public IActionResult GetAll()
    {
        var result = _orderService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet(template: "getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _orderService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost(template: "add")]
    public IActionResult Add(VmCreateOrder createOrder)
    {
        Order order = new()
        {
            OrderDesi = createOrder.OrderDesi,
        };

        var result = _orderService.Add(order);

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete(template: "delete")]
    public IActionResult Delete(VmDeleteOrder deleteOrder)
    {
        Order order = new()
        {
            OrderId = deleteOrder.OrderId
        };

        var result = _orderService.Delete(order);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}