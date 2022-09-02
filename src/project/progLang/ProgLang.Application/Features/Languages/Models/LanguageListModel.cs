using Core.Persistence.Paging;
using ProgLang.Application.Features.Languages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Languages.Models
{
    public class LanguageListModel:BasePageableModel
    {
        public List<LanguageListDto> Items { get; set; }
    }
}
