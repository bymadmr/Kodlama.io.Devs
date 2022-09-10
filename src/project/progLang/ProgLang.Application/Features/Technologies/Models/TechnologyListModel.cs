using Core.Persistence.Paging;
using ProgLang.Application.Features.Technologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Technologies.Models
{
    public class TechnologyListModel:BasePageableModel
    {
        public List<TechnologyListDto> Items { get; set; }
    }
}
