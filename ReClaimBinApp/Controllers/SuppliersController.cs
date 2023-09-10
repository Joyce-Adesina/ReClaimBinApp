using Microsoft.AspNetCore.Mvc;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Application.Service.Implementation;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.SupplierRequestDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReClaimBinApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/<SuppliersController>
        [HttpGet]
        [Route("suppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var resullt = await _supplierService.GetAllSuppliers(false);
            return Ok(resullt);
        }

        // GET api/<SuppliersController>/5
        [HttpGet("getsupplier/id/{id}")]
        public async Task<IActionResult> GetSupplierById(string id)
        {
            var result = await _supplierService.GetSupplierById(id, false);
            return Ok(result);
        }
        //[HttpGet("getsupplier/email/{email}")]
        //public async Task<IActionResult> GetSupplierByEmail(string email)
        //{
        //    var result = await _supplierService.GetSupplierByEmail(email, false);
        //    return Ok(result);
        //}

        // POST api/<SuppliersController>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierRequestDto requestDto)
        {
            var result = await _supplierService.CreateSupplier(requestDto);
            /*return CreatedAtAction(nameof(GetSupplierById), new { Id = result.Data.Id }, result.Data);*/
            return Ok(result);
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(string id, [FromBody] SupplierRequestDto requestDto)
        {
            var result = await _supplierService.UpdateSupplier(id, requestDto);
            return Ok(result);
        }


        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
