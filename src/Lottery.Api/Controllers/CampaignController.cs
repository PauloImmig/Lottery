using AutoMapper;
using Lottery.Api.Models;
using Lottery.Domain.Entities;
using Lottery.Domain.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lottery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ManageCampaign _manageCampaign;
        private readonly IMapper _mapper;

        public CampaignController(ManageCampaign manageCampaign, IMapper mapper)
        {
            this._manageCampaign = manageCampaign;
            this._mapper = mapper;
        }

        // GET: api/<CampaignController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CampaignController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CampaignController>
        [HttpPost]
        [ProducesResponseType(typeof(CreateCampaignResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Post([FromBody] CreateCampaignRequest createCampaignRequest)
        {
            var campaign = new Campaign(new CampaignPeriod(
                createCampaignRequest.StartDate,
                createCampaignRequest.EndDate), createCampaignRequest.Name, createCampaignRequest.Description);

            var newCampaign = await _manageCampaign.CreateCampaign(campaign);
            var response = _mapper.Map<CreateCampaignResponse>(newCampaign);
            return Ok(response);
        }

        // PUT api/<CampaignController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CampaignController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
