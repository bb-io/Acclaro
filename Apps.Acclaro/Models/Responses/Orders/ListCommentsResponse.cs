using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Orders
{
    public class ListCommentsResponse
    {
        [Display("Comments")]
        public IEnumerable<CommentResponse> Comments { get; set; }
    }
}
