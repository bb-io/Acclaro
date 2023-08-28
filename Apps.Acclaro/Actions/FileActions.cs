using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests.Files;
using Apps.Acclaro.Models.Responses;
using Apps.Acclaro.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class FileActions
    {
        [Action("List all order files", Description = "List all order files")]
        public ListFilesResponse ListOrderFiles(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/files-info", Method.Get, authenticationCredentialsProviders);
            return new ListFilesResponse()
            {
                Files = client.Get<ResponseWrapper<List<FileInfoStatusDto>>>(request).Data
            };
        }

        [Action("Get file information", Description = "Get file information by Id")]
        public FileInfoStatusDto? GetFileInfo(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId, [ActionParameter] string fileId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/files/{fileId}/status", Method.Get, authenticationCredentialsProviders);
            return client.Get<ResponseWrapper<FileInfoStatusDto>>(request).Data;
        }

        [Action("Upload file", Description = "Upload file")]
        public FileInfoDto? UploadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] UploadFileRequest input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{input.OrderId}/files", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("orderid", input.OrderId);
            request.AddParameter("sourcelang", input.Sourcelang);
            request.AddParameter("targetlang", input.Targetlang);
            request.AddFile("file", input.File.Bytes, input.File.Name);
            return client.Execute<ResponseWrapper<FileInfoDto>>(request).Data.Data;
        }

        [Action("Upload reference file", Description = "Upload reference file (glossaries, style guides etc)")]
        public FileInfoDto? UploadReferenceFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] UploadReferenceFileRequest input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{input.OrderId}/reference-file", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("orderid", input.OrderId);
            request.AddFile("file", input.File.Bytes, input.File.Name);
            return client.Execute<ResponseWrapper<FileInfoDto>>(request).Data.Data;
        }

        [Action("Download file", Description = "Download order file by Id")]
        public FileDataResponse? DownloadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId, [ActionParameter] string fileId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/files/{fileId}", Method.Get, authenticationCredentialsProviders);
            var response = client.Get(request);
            var filenameHeader = response.ContentHeaders.First(h => h.Name == "Content-Disposition");
            var filename = filenameHeader.Value.ToString().Split('"')[1];
            var contentType = response.ContentType;
            
            return new FileDataResponse()
            {
                File = new File(response.RawBytes)
                {
                    Name = filename,
                    ContentType = contentType
                }
            };
        }

        [Action("Delete file", Description = "Delete file")]
        public void DeleteFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId, [ActionParameter] string fileId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/files/{fileId}", Method.Delete, authenticationCredentialsProviders);
            client.Execute(request);
        }

        [Action("Add callback to file", Description = "Add callback to file")]
        public void AddCallbackToFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AddCallbackToFileRequest input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{input.OrderId}/files/{input.FileId}/callback", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("url", input.CallbackUrl);
            client.Execute(request);
        }

        [Action("Delete callback to file", Description = "Delete callback to file")]
        public void DeleteCallbackToFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AddCallbackToFileRequest input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{input.OrderId}/files/{input.FileId}/callback", Method.Delete, authenticationCredentialsProviders);
            request.AddParameter("url", input.CallbackUrl);
            client.Execute(request);
        }
    }
}
