using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers
{
    public class CommentFormatHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
        {
            { "text", "Text" },
            { "html", "HTML" },
        };
    }
}
