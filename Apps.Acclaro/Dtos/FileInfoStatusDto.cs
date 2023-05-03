using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Dtos
{
    public class FileInfoStatusDto
    {
        public int Fileid { get; set; }
        public int Id { get; set; }
        public int Orderid { get; set; }
        public string Filetype { get; set; }
        public string Originalfilename { get; set; }
        public string Filename { get; set; }

        [JsonProperty("plunet-filename")]
        public string PlunetFilename { get; set; }
        public string Encoding { get; set; }
        public string Mimetype { get; set; }
        public int Size { get; set; }
        public string Status { get; set; }
        public DateTime Uploaded { get; set; }
        public Sourcelang Sourcelang { get; set; }
        public Targetlang Targetlang { get; set; }
    }
}
