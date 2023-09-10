using Microsoft.AspNetCore.Mvc;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;

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
        public async Task<IActionResult> GetAllManufacturers()
        {
            var resullt = await _manufacturerService.GetAllManufacturers(false);
            return Ok(resullt);
        }

        // GET api/<ManufacturersController>/5
        [HttpGet("getcompany/id/{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var result = await _manufacturerService.GetManufacturerById(id, false);
            return Ok(result);
        }
        [HttpGet("getcompany/email/{email}")]
        //public async Task<IActionResult> GetManufacturerByEmail(string email)
        //{
        //    var result = await _manufacturerService.GetManufacturerByEmail(email, false);
        //    return Ok(result);
        //}

        // POST api/<ManufacturersController>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateManufacturer([FromBody] ManufacturerRequestDto requestDto)
        {
            var result = await _manufacturerService.CreateManufacturer(requestDto);
            return CreatedAtAction(nameof(GetManufacturerById), new { Id = result.Data.Id }, result.Data);
        }

        // PUT api/<ManufacturersController>/5
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateManufacturer(int id, [FromBody] ManufacturerRequestDto requestDto)
        {
            var result = await _manufacturerService.UpdateManufacturer(id, requestDto);
            return Ok(result);
        }

        // DELETE api/<ManufacturersController>/5
        [HttpDelete]
        [Route("delete/id/{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var result = await _manufacturerService.DeleteManufacturer(id);
            return Ok(result);
        }
    }
}
