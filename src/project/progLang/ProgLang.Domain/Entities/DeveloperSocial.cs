using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Domain.Entities
{
    public class DeveloperSocial:Entity
    {
        public string Url { get; set; }
        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        public int SocialId { get; set; }
        public Social? Social { get; set; }
        public DeveloperSocial()
        {
        }
        public DeveloperSocial(int id, string url, int developerId, int socialId)
        {
            Id = id;
            Url = url;
            DeveloperId = developerId;
            SocialId = socialId;
        }
    }
}
