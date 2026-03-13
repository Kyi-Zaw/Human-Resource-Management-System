using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class Response
    {
        public record class GrneralResponse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, string Token, string Message);
    }
}
