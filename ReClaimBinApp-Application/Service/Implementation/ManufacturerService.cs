using AutoMapper;
using Azure;
using Microsoft.Extensions.Logging;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;

namespace ReClaimBinApp_Application.Service.Implementation
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierService> _logger;

        public ManufacturerService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SupplierService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StandardResponse<ManufacturerResponseDto>> CreateManufacturer(ManufacturerRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"Attempting to map manaufacturer creation dto to entity");
                var manufacturer = _mapper.Map<Manufacturer>(requestDto);
                _logger.LogInformation("Attempting to create manufacturer");
                _unitOfWork.ManufacturerRepository.CreateManufacturer(manufacturer);
                _logger.LogInformation("Saving manufacturer to database");
                await _unitOfWork.SaveAsync();
                _logger.LogInformation("Mapping user response");
                var manufacturerDto = _mapper.Map<ManufacturerResponseDto>(manufacturer);
                _logger.LogInformation("Return user response");
                return StandardResponse<ManufacturerResponseDto>.Success("Successful", manufacturerDto, 201);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception: {ex.Message}"); }
        }

        public async Task<StandardResponse<string>> DeleteManufacturer(string id)
        {
            try
            {
                _logger.LogInformation($"Attempting to get Id with id {id}");
                var manufacturer = await GetManufacturerWithId(id, false);
                if (manufacturer == null)
                {
                    _logger.LogInformation($"Manufacturer {id} not found in the database");
                    return StandardResponse<string>.Failed($"Manufacturer {id} not found in the database", 406);
                }
                _unitOfWork.ManufacturerRepository.DeleteManufacturer(manufacturer);
                await _unitOfWork.SaveAsync();
                return StandardResponse<string>.Success($"Successful", $"Manufacturer with {id} deleted from the database", 200);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        }

        public async Task<StandardResponse<IEnumerable<ManufacturerResponseDto>>> GetAllManufacturers(bool trackChanges)
        {
            try
            {
                _logger.LogInformation($"Attempting to get all manufacturer");

                var manufactures = await _unitOfWork.ManufacturerRepository.GetAllManufacturers(trackChanges);
                var manufactureDtos = _mapper.Map<IEnumerable<ManufacturerResponseDto>>(manufactures);
                return StandardResponse<IEnumerable<ManufacturerResponseDto>>.Success("Successful", manufactureDtos, 200);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        }

       

        public async Task<StandardResponse<ManufacturerResponseDto>> GetManufacturerById(string id, bool trackChanges)
        {
            try
            {
                _logger.LogInformation($"Attempting to get id with id {id}");
                var manufacturer = await GetManufacturerWithId(id, trackChanges);
                var manufactureDto = _mapper.Map<ManufacturerResponseDto>(manufacturer);
                return StandardResponse<ManufacturerResponseDto>.Success("Successful", manufactureDto, 200);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        }

        public async Task<StandardResponse<int>> UpdateManufacturer(string id, ManufacturerRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"{nameof(UpdateManufacturer)}");
                var manufacturerFromDb = await GetManufacturerWithId(id, false);
                if (manufacturerFromDb == null)
                {
                    _logger.LogInformation($"Manufacturer {id} not found in the database");
                    return StandardResponse<int>.Failed($"Manufacturer {id} not found in the database", 406);
                }
                var manufacturer = _mapper.Map<Manufacturer>(requestDto);
                _unitOfWork.ManufacturerRepository.UpdateManufacturer(manufacturer);
                await _unitOfWork.SaveAsync();
                return StandardResponse<int>.Success($"Manufacturer {id} not found in the database", 200, 200);
            }
            catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        }
        private async Task<Manufacturer> GetManufacturerWithId(string id, bool trackChanges)
        {
            var manufacturer = await _unitOfWork.ManufacturerRepository.GetManufacturerById(id, trackChanges); 
            return manufacturer;
        }
        //public async Task<StandardResponse<ManufacturerResponseDto>> GetManufacturerByEmail(string email, bool trackChanges)
        //{
        //    try
        //    {
        //        _logger.LogInformation($"Attempting to get email with email{email}");
        //        var manufacturer = await _unitOfWork.ManufacturerRepository.GetManufacturerByEmail(email, trackChanges);
        //        var manufactureDto = _mapper.Map<ManufacturerResponseDto>(manufacturer);
        //        return StandardResponse<ManufacturerResponseDto>.Success("Successful", manufactureDto, 200);
        //    }
        //    catch (Exception ex) { throw new RequestFailedException($"Request failed exception:{ex.Message}"); }
        //}
    }
}
