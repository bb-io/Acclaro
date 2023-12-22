using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Files
{
    public class FileInfoResponse
    {
        [Display("File ID")]
        public string FileId { get; set; }

        [Display("ID")]
        public string Id { get; set; }

        [Display("Order ID")]
        public string OrderId { get; set; }

        [Display("File type")]
        public string Filetype { get; set; }

        [Display("Original filename")]
        public string Originalfilename { get; set; }

        public string Filename { get; set; }

        [Display("Plunet filename")]
        public string PlunetFilename { get; set; }

        public string Encoding { get; set; }

        [Display("Mime type")]
        public string Mimetype { get; set; }

        public int Size { get; set; }

        public string Status { get; set; }

        public DateTime Uploaded { get; set; }

        [Display("Source language")]
        public LanguageDto Sourcelang { get; set; }

        [Display("Target languages")]
        public List<LanguageDto> Targetlang { get; set; }

        public FileInfoResponse(FileInfoDto dto)
        {
            FileId = dto.Fileid.ToString();
            Id = dto.Id.ToString();
            OrderId = dto.Orderid.ToString();
            Filetype = dto.Filetype; 
            Originalfilename = dto.Originalfilename;
            Filename = dto.Filename;
            PlunetFilename = dto.PlunetFilename;
            Encoding = dto.Encoding;
            Mimetype = dto.Mimetype;
            Size = dto.Size;
            Status = dto.Status;
            Uploaded = dto.Uploaded;
            Sourcelang = dto.Sourcelang;
            Targetlang = dto.Targetlang;
        }

    }
}
