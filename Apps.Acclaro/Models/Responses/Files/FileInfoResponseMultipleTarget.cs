using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Files
{
    public class FileInfoResponseMultipleTarget
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

        [Display("Target language")]
        public IEnumerable<LanguageDto> Targetlang { get; set; }

        [Display("Client reference")]
        public string? ClientRef { get; set; }

        [Display("Target file ID")]
        public string? TargetFileId { get; set; }

        [Display("Preview file ID")]
        public string? PreviewFileId { get; set; }

        public FileInfoResponseMultipleTarget(FileInfoDtoMultipleTarget dto)
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
            ClientRef = dto.Clientref;
            TargetFileId = dto.Targetfile.HasValue ? dto.Targetfile.Value.ToString() : null;
            PreviewFileId = dto.Previewfile.HasValue ? dto.Previewfile.Value.ToString() : null;
        }
    }
}
