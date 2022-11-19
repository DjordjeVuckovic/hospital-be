using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.Dtos.Request;
using HospitalLibrary.BloodConsumptions.Model;
using HospitalLibrary.BloodConsumptions.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BloodConsumptionController : ControllerBase
    {
        private readonly BloodConsumptionService _bloodConsumptionService;
        private readonly IMapper _mapper;
        
        public BloodConsumptionController( BloodConsumptionService bloodConsumptionService, IMapper mapper)
        {
            _bloodConsumptionService = bloodConsumptionService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<BloodConsumption>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<BloodConsumption>>> GetAllConsumptions()
        {
            var result = await _bloodConsumptionService.GetAllConsumptions();
            return result == null ? NotFound() : Ok(result);
        }
        
        [HttpGet("getBankConsumptions/{bloodBankName}")]
        [ProducesResponseType(typeof(List<BloodConsumption>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<BloodConsumption>>> GetByBloodBankName([FromRoute]String bloodBankName)
        {
            var result = await _bloodConsumptionService.GetByBloodBankName(bloodBankName);
            return result == null ? NotFound() : Ok(result);
        }
        
        [HttpGet("getDoctorConsumptions/{doctorId:Guid}")]
        [ProducesResponseType(typeof(List<BloodConsumption>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<BloodConsumption>>> GetByBloodBankName([FromRoute]Guid doctorId)
        {
            var result = await _bloodConsumptionService.GetByDoctorId(doctorId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("{doctorId:Guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<BloodConsumption>>> GetByBloodBankName([FromRoute] Guid doctorId,[FromBody] BloodConsumationRequest request)
        {
            var consumption = _mapper.Map<BloodConsumption>(request);
            consumption.DoctorId = doctorId;
            var result = await _bloodConsumptionService.CreateConsumption(consumption);
            return result == null ? NotFound() : Ok(result);
        }

    }
}