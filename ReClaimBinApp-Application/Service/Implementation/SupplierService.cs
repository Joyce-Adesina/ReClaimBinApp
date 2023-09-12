using AutoMapper;
using Azure;
using Microsoft.Extensions.Logging;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Dtos.SupplierRequestDto;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;

namespace ReClaimBinApp_Application.Service.Implementation
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<StandardResponse<SupplierResponseDto>> CreateSupplier(SupplierRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"Attempting to map supplier creation dto to entity");
                var supplier = _mapper.Map<Supplier>(requestDto);
                _logger.LogInformation("Attempting to create supplier");
                _unitOfWork.SupplierRepository.CreateSupplier(supplier);
                _logger.LogInformation("Saving supplier to database");
                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Mapping user response");
                var supplierDto = _mapper.Map<SupplierResponseDto>(supplier);
                _logger.LogInformation("Return user response");
                return StandardResponse<SupplierResponseDto>.Success("Successful", supplierDto, 201);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception: {ex.Message}"); }
        }
        public async Task<StandardResponse<string>> DeleteSupplier(string id)
        {
            try
            {
                _logger.LogInformation($"Attempting to get Id with id {id}");
                var supplier = await GetSupplierWithId(id);
                if (supplier == null)
                {
                    _logger.LogInformation($"Supplier {id} not found in the database");
                    return StandardResponse<string>.Failed($"Supplier {id} not found in the database", 406);
                }
                _unitOfWork.SupplierRepository.Delete(supplier);
                await _unitOfWork.SaveAsync();
                return StandardResponse<string>.Success($"Successful", $"Supplier with {id} deleted from the database", 200);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        }
/*        public async Task<StandardResponse<IEnumerable<SupplierResponseDto>>> GetAllSuppliers( bool trackChanges)
        {
            try
            {
               *//* _logger.LogInformation($"Attempting to get all Supplier");
                var suppliers = await _unitOfWork.SupplierRepository.GetAllSuppliers(parameter ,trackChanges);
                var supplierDtos = _mapper.Map<IEnumerable<SupplierResponseDto>>(suppliers);
                return StandardResponse<IEnumerable<SupplierResponseDto  MetaData  pagingData)>.Success("Successfully retrieved all Supplier", (supplierDtos ,supplier.MetaData, 200);*//*
            }
            catch (Exception ex)
            
            {
                throw new RequestFailedException($"Request failed exception:{ex.Message}"); 
            }
        }*/
        public async Task<StandardResponse<SupplierResponseDto>> GetSupplierById(string id, bool trackChanges)
        {
            try
            {
                _logger.LogInformation($"Attempting to get id with id {id}");
                var suppliers = await _unitOfWork.SupplierRepository.GetSupplierById(id, trackChanges);
                var supplierDto = _mapper.Map<SupplierResponseDto>(suppliers);
                return StandardResponse<SupplierResponseDto>.Success("Success", supplierDto);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        }
        public async Task<StandardResponse<int>> UpdateSupplier(string id, SupplierRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"{nameof(UpdateSupplier)}");
                var supplierFromDb = await GetSupplierById(id, false);
                if (supplierFromDb == null)
                {
                    _logger.LogInformation($"Supplier {id} not found in the database");
                    return StandardResponse<int>.Failed($"Supplier {id} not found in the database", 406);
                }
                var supplier = _mapper.Map<Supplier>(requestDto);
                _unitOfWork.SupplierRepository.UpdateSupplier(supplier);
                await _unitOfWork.SaveAsync();
                return StandardResponse<int>.Success($"Supplier {id} not found in the database", 200, 200);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        }
        private async Task<Supplier> GetSupplierWithId(string id)
        {
            var result = await _unitOfWork.SupplierRepository.GetSupplierById(id, false);
            return result;
        }
    }
}