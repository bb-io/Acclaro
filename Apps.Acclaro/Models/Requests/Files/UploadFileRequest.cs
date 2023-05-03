using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class UploadFileRequest
    {
        public string OrderId { get; set; }
        public string Sourcelang { get; set; }
        public string Targetlang { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
