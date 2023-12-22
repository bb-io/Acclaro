using Blackbird.Applications.Sdk.Common;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class UploadFileRequest
    {
        public File File { get; set; }

        [Display("Client reference", Description = "If supplied when the order is loaded, it will be returned in all future calls about this order.")]
        public string? ClientRef { get; set; }

        [Display("Review URL")]
        public string? ReviewUrl { get; set; }

        [Display("Callback URL")]
        public string? CallbackUrl { get; set; }

        [Display("Callback email")]
        public string? CallbackEmail { get; set; }

        [Display("Is reference file")]
        public bool? IsReference { get; set; }
    }
}
