using Business.Abstract;
using Entities.Concrete;
using Entities.ViewModels.Carriers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CarrierController : Controller
{
    private readonly ICarrierService _carrierService;

    public CarrierController(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }


    [HttpGet(template: "getall")]
    public IActionResult GetAll()
    {
        var result = _carrierService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet(template: "getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _carrierService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost(template: "add")]
    public IActionResult Add(VmCreateCarrier createCarrier)
    {
        Carrier carrier = new()
        {
            CarrierName = createCarrier.CarrierName,
            CarrierIsActive = createCarrier.CarrierIsActive,
            CarrierPlusDesiCost = createCarrier.CarrierPlusDesiCost,
            CarrierConfigurationId = createCarrier.CarrierConfigurationId
        };

        var result = _carrierService.Add(carrier);

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut(template: "update")]
    public IActionResult Update(VmUpdateCarrier updateCarrier)
    {
        Carrier carrier = new()
        {
            CarrierId = updateCarrier.CarrierId,
            CarrierName = updateCarrier.CarrierName,
            CarrierIsActive = updateCarrier.CarrierIsActive,
            CarrierPlusDesiCost = updateCarrier.CarrierPlusDesiCost,
            CarrierConfigurationId = updateCarrier.CarrierConfigurationId
        };

        var result = _carrierService.Update(carrier);
            
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete(template: "delete")]
    public IActionResult Delete(VmDeleteCarrier deleteCarrier)
    {
        Carrier carrier = new()
        {
            CarrierId = deleteCarrier.CarrierId
        };

        var result = _carrierService.Delete(carrier);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}