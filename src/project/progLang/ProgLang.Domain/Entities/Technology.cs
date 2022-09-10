using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Domain.Entities
{
    public class Technology:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int LanguageId { get; set; }
        public virtual Language? Language { get; set; }
        public Technology()
        {
        }
        public Technology(int id, string name, string description, string ımageUrl, int languageId) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = ımageUrl;
            LanguageId = languageId;
        }
    }
}
