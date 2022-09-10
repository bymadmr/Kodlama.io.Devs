using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Domain.Entities
{
    public class Social:Entity
    {
        public string Name { get; set; }
        public Social()
        {
        }
        public Social(int id,string name)
        {
            Id=id;
            Name=name;
        }
    }
}
