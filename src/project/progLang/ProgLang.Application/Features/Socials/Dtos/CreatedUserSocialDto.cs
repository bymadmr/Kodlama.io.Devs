using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Socials.Dtos
{
    public class CreatedUserSocialDto
    {
        public int UserId { get; set; }
        public int SocialId { get; set; }
        public string Url { get; set; }
    }
}
