using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Files
{
    public class SearchFilesResponse
    {
        [Display("Files")]
        public IEnumerable<FileInfoResponse> Files { get; set; }
    }
}
