using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Auth.Register.Dtos
{
    public class RegisterAccessTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
