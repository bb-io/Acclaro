using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class UploadReferenceFileRequest
    {
        public string OrderId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
