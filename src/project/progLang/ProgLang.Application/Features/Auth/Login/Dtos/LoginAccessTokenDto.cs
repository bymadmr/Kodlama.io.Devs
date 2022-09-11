using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Auth.Login.Dtos
{
    public class LoginAccessTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
