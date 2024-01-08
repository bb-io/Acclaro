using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Orders
{
    public class CommentResponse
    {
        [Display("ID")]
        public string Id { get; set; }

        [Display("Author email")]
        public string Author { get; set; }

        [Display("Comment")]
        public string Comment { get; set; }

        [Display("Time")]
        public DateTime Timestamp { get; set; }

        [Display("Time edited")]
        public DateTime Edited { get; set; }

        [Display("Is system comment?")]
        public bool System { get; set; }

        public CommentResponse(CommentDto comment)
        {
            Id = comment.Id.ToString();
            Author = comment.Author.ToString();
            Comment = comment.Comment;
            Timestamp = comment.Timestamp;
            Edited = comment.Edited;
            System = comment.System;
        }
    }
}
