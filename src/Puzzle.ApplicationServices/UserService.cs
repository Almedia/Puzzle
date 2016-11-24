using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puzzle.Core.Interface;
using Puzzle.Core.Model;
using Puzzle.Infrastructure.Services;


namespace Puzzle.ApplicationServices
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository){
            this.userRepository=userRepository;
        }

        public User Get(long userId){
            var user=this.userRepository.Get(userId);
            return user;
        }

        public void Create(User user){
            this.userRepository.Create(user);
        }
    }
}