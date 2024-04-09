using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class CommentRequest
    {
        [Display("Comment ID")]
        public string CommentId { get; set; }
    }
}
