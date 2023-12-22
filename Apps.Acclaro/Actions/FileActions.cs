using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests;
using Apps.Acclaro.Models.Requests.Files;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Responses;
using Apps.Acclaro.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class FileActions : AcclaroInvocable
    {
        public FileActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Upload file", Description = "Upload a file to an order")]
        public async Task<FileInfoDto> UploadFile([ActionParameter] OrderRequest input, [ActionParameter] UploadFileRequest file, [ActionParameter] LanguageRequest languages)
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

            request.AddFile("file", file.File.Bytes, file.File.Name);
            var response = await Client.PostAsync<ResponseWrapper<FileInfoDto>>(request);

            var id = response.Data.Fileid;

            if (file.CallbackUrl != null)
            {
                var callbackRequest = new AcclaroRequest($"/orders/{input.Id}/files/{id}/callback", Method.Post, Creds);
                callbackRequest.AddParameter("url", file.CallbackUrl);
                await Client.PostAsync(callbackRequest);
            }

            if (file.CallbackEmail != null)
            {
                var emailRequest = new AcclaroRequest($"/orders/{input.Id}/files/{id}/email", Method.Post, Creds);
                emailRequest.AddParameter("email", file.CallbackEmail);
                await Client.PostAsync(emailRequest);
            }

            if (file.ReviewUrl != null)
            {
                var reviewRequest = new AcclaroRequest($"/orders/{input.Id}/files/{id}/review-url", Method.Post, Creds);
                reviewRequest.AddParameter("url", file.ReviewUrl);
                await Client.PostAsync(reviewRequest);
            }

            return response.Data;
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

        [Action("Get file information", Description = "Get actual information on a file")]
        public async Task<FileInfoStatusDto> GetFileInfo([ActionParameter] OrderRequest input, [ActionParameter] FileRequest file)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/files/{file.FileId}/status", Method.Get, Creds);
            var response = await Client.GetAsync<ResponseWrapper<FileInfoStatusDto>>(request);

            return response.Data;
        }        

        [Action("Download file", Description = "Download order file by ID")]
        public FileDataResponse? DownloadFile([ActionParameter] OrderRequest input, [ActionParameter] FileRequest file)
        {
            var request = new AcclaroRequest($"//orders/{input.Id}/files/{file.FileId}", Method.Get, Creds);
            var response = Client.Get(request);
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
