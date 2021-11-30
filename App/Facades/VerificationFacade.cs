using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Verifications;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class VerificationFacade : IAppFacade
    {
        public readonly VerificationRepository VerificationRepository;
        public readonly IMapper Mapper;

        public VerificationFacade(VerificationRepository verificationRepository,
            IMapper mapper)
        {
            this.VerificationRepository = verificationRepository;
            this.Mapper = mapper;
        }

        public List<VerificationListModel> GetAll()
        {
            return Mapper.Map<List<VerificationListModel>>(VerificationRepository.GetAll());
        }

        public VerificationDetailModel GetById(Guid id)
        {
            return Mapper.Map<VerificationDetailModel>(VerificationRepository.GetById(id));
        }

        public Guid Create(VerificationNewModel verification)
        {
            var verificationEntity = Mapper.Map<Verification>(verification);
            return VerificationRepository.Create(verificationEntity);
        }

        public Guid? Update(VerificationUpdateModel verification)
        {
            var verificationEntity = Mapper.Map<Verification>(verification);
            return VerificationRepository.Update(verificationEntity);
        }

        public void Delete(Guid id)
        {
            VerificationRepository.Delete(id);
        }

    }
}
