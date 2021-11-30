using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Participants;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class ParticipantFacade : IAppFacade
    {
        public readonly ParticipantRepository ParticipantRepository;
        public readonly IMapper Mapper;

        public ParticipantFacade(ParticipantRepository participantRepository,
            IMapper mapper)
        {
            this.ParticipantRepository = participantRepository;
            this.Mapper = mapper;
        }

        public List<ParticipantListModel> GetAll()
        {
            return Mapper.Map<List<ParticipantListModel>>(ParticipantRepository.GetAll());
        }

        public ParticipantDetailModel GetById(Guid id)
        {
            return Mapper.Map<ParticipantDetailModel>(ParticipantRepository.GetById(id));
        }

        public Guid Create(ParticipantNewModel participant)
        {
            var participantEntity = Mapper.Map<Participant>(participant);
            return ParticipantRepository.Create(participantEntity);
        }

        public Guid? Update(ParticipantUpdateModel participant)
        {
            var participantEntity = Mapper.Map<Participant>(participant);
            return ParticipantRepository.Update(participantEntity);
        }

        public void Delete(Guid id)
        {
            ParticipantRepository.Delete(id);
        }

    }
}
