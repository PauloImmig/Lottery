using Lottery.Domain.Entities;
using Lottery.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Domain.UseCases
{
    public class ManageCampaign
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManageCampaign(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Campaign> CreateCampaign(Campaign campaign)
        {
            var campaignRepository = _unitOfWork.Repository<Campaign>();
            var result = campaignRepository.Insert(campaign);
            await _unitOfWork.Commit();
            return result;
        }

        public async Task<Campaign> InactivateCampaign(Guid id)
        {
            var campaignRepository = _unitOfWork.Repository<Campaign>();
            var campaign = campaignRepository.Find(id);
            campaign.Inactivate();
            var result = campaignRepository.Update(campaign);
            await _unitOfWork.Commit();
            return result;
        }

        public IEnumerable<Campaign> GetAllCampaigns()
        {
            var campaignRepository = _unitOfWork.Repository<Campaign>();
            return campaignRepository.Queryable(x => x.EmailTemplate).ToList();
        }

        public async Task<Campaign> SetCampaignEmailTemplate(Guid campaignId, CampaignEmailTemplate campaignEmailTemplate)
        {
            var campaignRepository = _unitOfWork.Repository<Campaign>();
            var campaign = campaignRepository
                .Queryable()
                .SingleOrDefault(x => x.Id == campaignId);

            if (campaign == null) throw new Exception($"Campaign not found. Id: {campaignId}.");

            campaign.SetEmailTemplate(campaignEmailTemplate);
            var result = campaignRepository.Update(campaign);
            await _unitOfWork.Commit();
            return result;
        }

        public Campaign GetCampaignById(Guid id)
        {
            var campaignRepository = _unitOfWork.Repository<Campaign>();
            return campaignRepository.Find(id);
        }
    }
}
