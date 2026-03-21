using ApplicationLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationLayer.DTOs.Response;

namespace ApplicationLayer.IRepository.Admin
{
    public interface IUserAccount
    {
        Task<GrneralResponse> CreateAccount(UserRequest userRequest);
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
