using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using TinyApi.Attributes;
using TinyApi.Extensions.Http;
using TinyModel;
using TinyModel.DTO;
using TinyService.Contracts;

namespace TinyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private ITinyService _service;
        public OperationController(ITinyService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO credentials)
        {

            try
            {
                string token = _service.Authenticate(credentials.Username, credentials.Password);
                return Ok(token);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [AuthorizationFilter(UserRole.ADMIN)]
        [HttpPost("client/create")]
        public IActionResult CreateClient(ClientDTO client)
        {
            var clientCreated = _service.CreateClient(client);

            if (clientCreated == null) return NoContent();

            return Ok(clientCreated);
        }

        [AuthorizationFilter(UserRole.ADMIN, UserRole.CARD_ISSUER)]
        [HttpGet("clients")]
        public IActionResult GetClients()
        {
            return Ok(_service.GetClients());
        }

        [AuthorizationFilter(UserRole.CARD_ISSUER)]
        [HttpPost("card/issue")]
        public IActionResult IssueLoyaltyCard([FromQuery, Required] int clientId)
        {
            var cardCreated = _service.IssueCard(clientId);

            if (cardCreated == null) return NoContent();

            return Ok(cardCreated);
        }

        [AuthorizationFilter(UserRole.CARD_ISSUER)]
        [HttpGet("cards")]
        public IActionResult GetCards()
        {
            return Ok(_service.GetCards());
        }

        [AuthorizationFilter(UserRole.CARD_OWNER)]
        [HttpPost("transaction/create")]
        public IActionResult CreateLoyaltyCardTransaction([FromQuery, Required] int clientId, [FromBody] LoyaltyCardTransactionDTO transaction)
        {
            var cardCreated = _service.CreateTransaction(clientId, transaction.CardNumber, transaction.LoyaltyPointsEarned);

            if (cardCreated == null) return NoContent();

            return Ok(cardCreated);
        }

        [AuthorizationFilter(UserRole.CARD_OWNER)]
        [HttpGet("transactions/balance")]
        public IActionResult GetBalance([FromQuery, Required] int clientId)
        {
            return Ok(_service.GetBalance(clientId));
        }
    }
}
