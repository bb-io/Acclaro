using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Dtos
{
    public class FileInfoStatusDto
    {
        [Display("File ID")]
        public int Fileid { get; set; }
        
        [Display("ID")]
        public int Id { get; set; }
        
        [Display("Order ID")]
        public int Orderid { get; set; }
        
        [Display("File type")]
        public string Filetype { get; set; }
        
        [Display("Original filename")]
        public string Originalfilename { get; set; }
        
        public string Filename { get; set; }

        [Display("Plunet filename")]
        [JsonPropertyName("plunet-filename")]
        public string PlunetFilename { get; set; }
        
        public string Encoding { get; set; }
        
        [Display("Mime type")]
        public string Mimetype { get; set; }
        
        public int Size { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Uploaded { get; set; }
        
        [Display("Source language")]
        public Sourcelang Sourcelang { get; set; }
        
        [Display("Target language")]
        public Targetlang Targetlang { get; set; }
    }
}
