﻿using AutoHub.API.Models.LotModels;
using AutoHub.BLL.DTOs.LotDTOs;
using AutoHub.BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using AutoHub.API.Common;
using Microsoft.AspNetCore.Authorization;

namespace AutoHub.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]s")]
    [Produces("application/json")]
    public class LotController : Controller
    {
        private readonly ILotService _lotService;
        private readonly IMapper _mapper;


        public LotController(ILotService lotService, IMapper mapper)
        {
            _lotService = lotService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all lots.
        /// </summary>
        /// <returns>Returns list of lots.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LotResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllLots()
        {
            var lots = _lotService.GetAll();
            var mappedLots = _mapper.Map<IEnumerable<LotResponseModel>>(lots);

            return Ok(mappedLots);
        }

        /// <summary>
        /// Get all lots with status "In progress".
        /// </summary>
        /// <returns>Returns list of lots with status "In progress".</returns>
        [HttpGet("Active")]
        [ProducesResponseType(typeof(IEnumerable<LotResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetLotsInProgress()
        {
            var lots = _lotService.GetInProgress();
            var mappedLots = _mapper.Map<IEnumerable<LotResponseModel>>(lots);

            return Ok(mappedLots);
        }

        /// <summary>
        /// Get a lot by ID.
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns>Returns lot</returns>
        [HttpGet("{lotId}")]
        [ProducesResponseType(typeof(LotResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetLotById(int lotId)
        {
            var lot = _lotService.GetById(lotId);
            var mappedLot = _mapper.Map<LotResponseModel>(lot);

            return Ok(mappedLot);
        }


        /// <summary>
        /// Create lot.
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Lots
        ///     {
        ///         "creatorId": 1,
        ///         "carId": 1,
        ///         "durationInDays": 7
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Lot was created successfully.</response>
        /// <response code="400">Invalid model.</response>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = AuthorizationRoles.Seller)]
        [Authorize(Roles = AuthorizationRoles.Administrator)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateLot([FromBody] LotCreateRequestModel model)
        {
            var mappedLot = _mapper.Map<LotCreateRequestDTO>(model);
            _lotService.Create(mappedLot);

            return StatusCode((int) HttpStatusCode.Created);
        }

        /// <summary>
        /// Update lot.
        /// </summary>
        /// <param name="lotId"></param>
        /// <param name="model"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Lots/1
        ///     {
        ///         "lotStatusId": 3,
        ///         "winnerId": 1,
        ///         "durationInDays": 7
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Lot was updated successfully.</response>
        /// <response code="400">Invalid model.</response>
        /// <response code="404">Lot not found.</response>
        /// <response code="422">Invalid status ID.</response>
        /// <returns></returns>
        [HttpPut("{lotId}")]
        [Authorize(Roles = AuthorizationRoles.Administrator)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateLot(int lotId, [FromBody] LotUpdateRequestModel model)
        {
            var mappedLot = _mapper.Map<LotUpdateRequestDTO>(model);
            _lotService.Update(lotId, mappedLot);

            return NoContent();
        }

        /// <summary>
        /// Update lot status.
        /// </summary>
        /// <param name="lotId"></param>
        /// <param name="statusId"></param>
        /// <response code="204">Lot status was updated successfully.</response>
        /// <response code="404">Lot not found.</response>
        /// <response code="422">Invalid status ID.</response>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Roles = AuthorizationRoles.Administrator)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateLotStatus(int lotId, int statusId)
        {
            _lotService.UpdateStatus(lotId, statusId);

            return NoContent();
        }

        /// <summary>
        /// Delete lot.
        /// </summary>
        /// <param name="lotId"></param>
        /// <response code="204">Lot was deleted successfully.</response>
        /// <response code="404">Lot not found.</response>
        /// <returns></returns>
        [HttpDelete("{lotId}")]
        [Authorize(Roles = AuthorizationRoles.Administrator)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteLot(int lotId)
        {
            _lotService.Delete(lotId);
            return NoContent();
        }
    }
}