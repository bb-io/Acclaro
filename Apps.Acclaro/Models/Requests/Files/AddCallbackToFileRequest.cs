using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class AddCallbackToFileRequest
    {
        public string OrderId { get; set; }

        public string FileId { get; set; }

        public string CallbackUrl { get; set; }
    }
}
