using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class UserSocial:Entity
    {
        public int UserId { get; set; }
        public int SocialId { get; set; }
        public string Url { get; set; }
        public UserSocial( int userId, int socialId, string url)
        {
            UserId = userId;
            SocialId = socialId;
            Url = url;
        }
    }
}
