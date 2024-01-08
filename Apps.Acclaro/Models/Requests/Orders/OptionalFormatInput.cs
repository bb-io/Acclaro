using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class OptionalFormatInput
    {
        [Display("Format")]
        [DataSource(typeof(CommentFormatHandler))]
        public string? Format { get; set; }
    }
}
