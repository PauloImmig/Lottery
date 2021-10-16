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
        [HttpGet(Name = "GetAllCampaigns")]
        [ProducesResponseType(typeof(GetAllCampaignsResponse), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var campaigns = _manageCampaign.GetAllCampaigns();
            var result = _mapper.Map<IEnumerable<Campaign>, List<GetAllCampaignsResponse>>(campaigns);
            return Ok(result);
        }

        // GET api/<CampaignController>/5
        [HttpGet("{id}", Name = "GetCampainById")]
        [ProducesResponseType(typeof(GetCampaignByIdResponse), StatusCodes.Status200OK)]
        public IActionResult Get(Guid id)
        {
            var campaigns = _manageCampaign.GetCampaignById(id);
            var result = _mapper.Map<Campaign, GetCampaignByIdResponse>(campaigns);
            return Ok(result);
        }

        // POST api/<CampaignController>
        [HttpPost("CreateCampaign")]
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
        [HttpPut("{id}/email-template", Name = "SetCampaignEmailTemplate")]
        public async Task<IActionResult> Put(Guid id, [FromBody] SetCampaignEmailTemplateRequest setCampaignEmailTemplateRequest)
        {
            CampaignEmailTemplate campaignEmailTemplate = new(setCampaignEmailTemplateRequest.Subject,
                                                              setCampaignEmailTemplateRequest.Content,
                                                              new EmailContentPlaceholders(setCampaignEmailTemplateRequest.Placeholders));

            var newCampaign = await _manageCampaign.SetCampaignEmailTemplate(id, campaignEmailTemplate);
            return Ok();
        }

        // DELETE api/<CampaignController>/5
        [HttpDelete("{id}", Name = "InactivateCampaign")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _manageCampaign.InactivateCampaign(id);
            return Ok();
        }
    }
}
