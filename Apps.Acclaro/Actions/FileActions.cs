using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests;
using Apps.Acclaro.Models.Requests.Files;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using RestSharp;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class FileActions : AcclaroInvocable
    {
        private readonly IFileManagementClient _fileManagementClient;
        
        public FileActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) 
            : base(invocationContext)
        {
            _fileManagementClient = fileManagementClient;
        }

        [Action("Upload file", Description = "Upload a file to an order")]
        public async Task<FileInfoResponse> UploadFile([ActionParameter] OrderRequest input,
            [ActionParameter] UploadFileRequest file, [ActionParameter] RequiredLanguageRequest languages)
        {
            var path = "files";
            if (file.IsReference.HasValue && file.IsReference.Value)
                path = "file-reference";

            var request = new AcclaroRequest($"/orders/{input.Id}/{path}", Method.Post, Creds);
            if (languages.SourceLanguage != null)
                request.AddParameter("sourcelang", languages.SourceLanguage);

            if (languages.TargetLanguages != null)
                request.AddParameter("targetlang", string.Join(',', languages.TargetLanguages));

            if (file.ClientRef != null)
                request.AddParameter("clientref", file.ClientRef);

            var fileStream = await _fileManagementClient.DownloadAsync(file.File);
            var fileBytes = await fileStream.GetByteData();
            request.AddFile("file", fileBytes, file.File.Name);
            var response = await Client.ExecuteAcclaro<FileInfoDto>(request);

            var id = response.Fileid;

            if (file.CallbackUrl != null)
            {
                var callbackRequest = new AcclaroRequest($"/orders/{input.Id}/files/{id}/callback", Method.Post, Creds);
                callbackRequest.AddParameter("url", file.CallbackUrl);
                await Client.ExecuteAcclaro(callbackRequest);
            }

            if (file.CallbackEmail != null)
            {
                var emailRequest = new AcclaroRequest($"/orders/{input.Id}/files/{id}/email", Method.Post, Creds);
                emailRequest.AddParameter("email", file.CallbackEmail);
                await Client.ExecuteAcclaro(emailRequest);
            }

            if (file.ReviewUrl != null)
            {
                var reviewRequest = new AcclaroRequest($"/orders/{input.Id}/files/{id}/review-url", Method.Post, Creds);
                reviewRequest.AddParameter("url", file.ReviewUrl);
                await Client.ExecuteAcclaro(reviewRequest);
            }

            return new(response);
        }

        //[Action("List all order files", Description = "List all order files")]
        //public ListFilesResponse ListOrderFiles(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        //[ActionParameter] string orderId)
        //{
        //    var client = new AcclaroClient();
        //    var request = new AcclaroRequest($"/orders/{orderId}/files-info", Method.Get, authenticationCredentialsProviders);
        //    return new ListFilesResponse()
        //    {
        //        Files = client.Get<ResponseWrapper<List<FileInfoStatusDto>>>(request).Data
        //    };
        //}

        [Action("Get file information", Description = "Get information of a file")]
        public async Task<FileInfoResponse> GetFileInfo([ActionParameter] OrderRequest input,
            [ActionParameter] FileRequest file)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/files/{file.FileId}/status", Method.Get, Creds);
            var response = await Client.ExecuteAcclaro<FileInfoDto>(request);
            return new(response);
        }

        [Action("Download file", Description = "Download order file by ID")]
        public async Task<FileDataResponse> DownloadFile([ActionParameter] OrderRequest input, 
            [ActionParameter] FileRequest file)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/files/{file.FileId}", Method.Get, Creds);
            var response = Client.Get(request);
            var filename = response.ContentHeaders.First(h => h.Name == "Content-Disposition").Value.ToString()
                .Split('"')[1];
            var contentType = response.ContentType;

            using var stream = new MemoryStream(response.RawBytes);
            var fileReference = await _fileManagementClient.UploadAsync(stream, contentType, filename);
            return new FileDataResponse { File = fileReference };
        }

        //[Action("Delete file", Description = "Delete file")]
        //public void DeleteFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        //    [ActionParameter] string orderId, [ActionParameter] string fileId)
        //{
        //    var client = new AcclaroClient();
        //    var request = new AcclaroRequest($"/orders/{orderId}/files/{fileId}", Method.Delete, authenticationCredentialsProviders);
        //    client.Execute(request);
        //}
    }
}
