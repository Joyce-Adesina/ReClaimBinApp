using Microsoft.AspNetCore.Mvc;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Shared.RequestParameter.ModelParameter;
using System.Text.Json;

namespace ReClaimBinApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        [Route("manufacturer")]
        public async Task<IActionResult> GetAllManufacturers([FromQuery]ManufacturerRequestInputParameter parameter)
        {
            var resullt = await _manufacturerService.GetAllManufacturers(parameter, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(resullt.Data.Item2));
            return Ok(resullt.Data.Item1);
        }

        // GET api/<ManufacturersController>/5
        [HttpGet("getManufacturer/id/{id}")]
        public async Task<IActionResult> GetManufacturerById(string id)
        {
            var result = await _manufacturerService.GetManufacturerById(id, false);
            return Ok(result);
        }
        [HttpGet("getManufacturer/email/{email}")]
        //public async Task<IActionResult> GetManufacturerByEmail(string email)
        //{
        //    var result = await _manufacturerService.GetManufacturerByEmail(email, false);
        //    return Ok(result);
        //}

        // POST api/<ManufacturersController>
        [HttpPost]
        [Route("createManufacturer")]
        public async Task<IActionResult> CreateManufacturer([FromBody] ManufacturerRequestDto requestDto)
        {
            var result = await _manufacturerService.CreateManufacturer(requestDto);
            return CreatedAtAction(nameof(GetManufacturerById), new { Id = result.Data.Id }, result.Data);
        }

        // PUT api/<ManufacturersController>/5
        [HttpPut]
        [Route("Updatemanufacturer{id}")]
        public async Task<IActionResult> UpdateManufacturer(string id, [FromBody] ManufacturerRequestDto requestDto)
        {
            var result = await _manufacturerService.UpdateManufacturer(id, requestDto);
            return Ok(result);
        }

        // DELETE api/<ManufacturersController>/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteManufacturer(string id)
        {
            var result = await _manufacturerService.DeleteManufacturer(id);
            return Ok(result);
        }
    }
}
