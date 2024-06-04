using Business.Abstract;
using Entities.Concrete;
using Entities.ViewModels.CarrierConfigurations;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class CarrierConfigurationController : Controller
{
    private readonly ICarrierConfigurationService _carrierConfigurationService;

    public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
    {
        _carrierConfigurationService = carrierConfigurationService;
    }


    [HttpGet(template: "getall")]
    public IActionResult GetAll()
    {
        var result = _carrierConfigurationService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet(template: "getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _carrierConfigurationService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost(template: "add")]
    public IActionResult Add(VmCreateCarrierConfiguration createCarrierConfiguration)
    {
        CarrierConfiguration carrierConfiguration = new()
        {
            CarrierId = createCarrierConfiguration.CarrierId,
            CarrierMaxDesi = createCarrierConfiguration.CarrierMaxDesi,
            CarrierMinDesi = createCarrierConfiguration.CarrierMinDesi,
            CarrierCost = createCarrierConfiguration.CarrierCost,
        };

        var result = _carrierConfigurationService.Add(carrierConfiguration);

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut(template: "update")]
    public IActionResult Update(VmUpdateCarrierConfiguration updateCarrierConfiguration)
    {
        CarrierConfiguration carrierConfiguration = new()
        {
            CarrierConfigurationId = updateCarrierConfiguration.CarrierConfigurationId,
            CarrierId = updateCarrierConfiguration.CarrierId,
            CarrierMaxDesi = updateCarrierConfiguration.CarrierMaxDesi,
            CarrierMinDesi = updateCarrierConfiguration.CarrierMinDesi,
            CarrierCost = updateCarrierConfiguration.CarrierCost
        };

        var result = _carrierConfigurationService.Update(carrierConfiguration);

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete(template: "delete")]
    public IActionResult Delete(VmDeleteCarrierConfiguration deleteCarrierConfiguration)
    {
        CarrierConfiguration carrierConfiguration = new()
        {
            CarrierConfigurationId = deleteCarrierConfiguration.CarrierConfigurationId
        };

        var result = _carrierConfigurationService.Delete(carrierConfiguration);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}