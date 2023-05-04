using Apps.Acclaro.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Strings
{
    public class ListAllStringsResponse
    {
        public IEnumerable<StringListDto> Strings { get; set; }
    }
}
