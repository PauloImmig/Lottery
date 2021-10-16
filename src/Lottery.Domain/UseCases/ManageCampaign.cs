using Lottery.Domain.Entities;
using Lottery.SharedKernel.Interfaces;
using System;
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
    }
}
