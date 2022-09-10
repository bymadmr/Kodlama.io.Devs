using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Domain.Entities
{
    public class Developer:User
    {
        public virtual ICollection<Social> Socials { get; set; }
    }
}
