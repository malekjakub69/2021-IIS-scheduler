using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Facades.Interfaces;
using AppModels.Models.Users;
using AppEntities.Entities;
using App.Repositories;
using AutoMapper;

namespace App.Facades
{
    public class UserFacade : IAppFacade
    {
        public readonly UserRepository userRepository;
        public readonly IMapper mapper;

        public UserFacade(UserRepository userRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public List<UserListModel> GetAll()
        {
            return mapper.Map<List<UserListModel>>(userRepository.GetAll());
        }

        public UserDetailModel GetById(Guid id)
        {
            return mapper.Map<UserDetailModel>(userRepository.GetById(id));
        }

        public Guid Create(UserNewModel user)
        {
            var userEntity = mapper.Map<User>(user);
            return userRepository.Create(userEntity);
        }

        public Guid Update(UserUpdateModel user)
        {
            var userEntity = mapper.Map<User>(user);
            return userRepository.Update(userEntity);
        }

        public void Delete(Guid id)
        {
            userRepository.Delete(id);
        }

    }
}
