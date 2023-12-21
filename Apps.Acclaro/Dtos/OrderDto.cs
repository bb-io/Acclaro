using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Acclaro.Dtos
{
    public class OrderDto
    {
        [Display("Order ID")]
        [JsonProperty("orderid")]
        public string Orderid { get; set; }

        [Display("User")]
        [JsonProperty("user")]
        public User User { get; set; }

        [Display("User group")]
        [JsonProperty("usergroup")]
        public string Usergroup { get; set; }

        [Display("Plunet order ID")]
        [JsonProperty("plunet-orderid")]
        public string PlunetOrderid { get; set; }

        [Display("Plunet request ID")]
        [JsonProperty("plunet-requestid")]
        public string PlunetRequestid { get; set; }

        [Display("Plunet quote ID")]
        [JsonProperty("plunet-quoteid")]
        public object PlunetQuoteid { get; set; }

        [Display("Plunet quote number")]
        [JsonProperty("plunet-quotenum")]
        public object PlunetQuotenum { get; set; }

        [Display("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display("Status")]
        [JsonProperty("status")]
        public string Status { get; set; }

        [Display("Process type")]
        [JsonProperty("process_type")]
        public string ProcessType { get; set; }

        [Display("Order type")]
        [JsonProperty("ordertype")]
        public string Ordertype { get; set; }

        [Display("Source file count")]
        [JsonProperty("sourcefilecount")]
        public int Sourcefilecount { get; set; }

        [Display("Reference file count")]
        [JsonProperty("referencefilecount")]
        public int Referencefilecount { get; set; }

        [Display("Target file count")]
        [JsonProperty("targetfilecount")]
        public int Targetfilecount { get; set; }

        [Display("Requested due date")]
        [JsonProperty("requested_due_date")]
        public DateTime RequestedDueDate { get; set; }

        [Display("Due date")]
        [JsonProperty("duedate")]
        public DateTime Duedate { get; set; }

        [Display("Client reference")]
        [JsonProperty("clientref")]
        public string Clientref { get; set; }

        [Display("Delivery")]
        [JsonProperty("delivery")]
        public string Delivery { get; set; }

        //[JsonProperty("rating")]
        //public object Rating { get; set; }

        //[JsonProperty("review")]
        //public object Review { get; set; }

        [Display("Created")]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [Display("Modified")]
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [Display("Source languages")]
        [JsonProperty("sourcelang")]
        public List<string> Sourcelang { get; set; }

        [Display("Target languages")]
        [JsonProperty("targetlang")]
        public List<string> Targetlang { get; set; }

        //[JsonProperty("ordertypecode")]
        //public int Ordertypecode { get; set; }

        [Display("Email address")]
        [JsonProperty("emailaddress")]
        public string Emailaddress { get; set; }

        //[JsonProperty("emailquote")]
        //public int Emailquote { get; set; }

        //[JsonProperty("emailfile")]
        //public int Emailfile { get; set; }

        //[JsonProperty("emaildone")]
        //public int Emaildone { get; set; }

        //[JsonProperty("emailsubmit")]
        //public int Emailsubmit { get; set; }

        //[JsonProperty("emailcomment")]
        //public int Emailcomment { get; set; }

        //[JsonProperty("quoterequired")]
        //public int Quoterequired { get; set; }

        //[JsonProperty("autoapprove")]
        //public int Autoapprove { get; set; }

        //[JsonProperty("autoapproveamt")]
        //public int Autoapproveamt { get; set; }

        [Display("Tags")]
        [JsonProperty("tags")]
        public string Tags { get; set; }

        [Display("Estimated word count")]
        [JsonProperty("estimatedwordcount")]
        public int Estimatedwordcount { get; set; }

        //[JsonProperty("lastdelivery")]
        //public string Lastdelivery { get; set; }

        //[JsonProperty("invoicedate")]
        //public string Invoicedate { get; set; }

        //[JsonProperty("invoicedue")]
        //public string Invoicedue { get; set; }

        //[JsonProperty("in_preparation")]
        //public DateTime InPreparation { get; set; }

        //[JsonProperty("in_progress")]
        //public string InProgress { get; set; }

        //[JsonProperty("in_review")]
        //public string InReview { get; set; }

        //[JsonProperty("completed")]
        //public string Completed { get; set; }

        //[JsonProperty("canceled")]
        //public string Canceled { get; set; }

        //[JsonProperty("getting_quote")]
        //public string GettingQuote { get; set; }

        //[JsonProperty("needs_approval")]
        //public string NeedsApproval { get; set; }

        [Display("Comments")]
        [JsonProperty("comments")]
        public string Comments { get; set; }

        //[JsonProperty("invoice_numbers")]
        //public object InvoiceNumbers { get; set; }

        //[JsonProperty("invoice_data")]
        //public object InvoiceData { get; set; }

        [Display("Account")]
        [JsonProperty("account")]
        public Account Account { get; set; }

        //[JsonProperty("comment_callback")]
        //public object CommentCallback { get; set; }

        //[JsonProperty("callbacks")]
        //public List<object> Callbacks { get; set; }

        //[JsonProperty("emails")]
        //public List<object> Emails { get; set; }

        //[JsonProperty("program")]
        //public object Program { get; set; }

        //[JsonProperty("source_word_count")]
        //public SourceWordCount SourceWordCount { get; set; }
    }

    public class Account
    {
        [Display("Plunet ID")]
        [JsonProperty("plunetid")]
        public string Plunetid { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [Display("Last activity")]
        [JsonProperty("lastactivity")]
        public DateTime Lastactivity { get; set; }
    }

    public class User
    {
        [Display("Plunet ID")]
        [JsonProperty("plunetid")]
        public string Plunetid { get; set; }

        [Display("First name")]
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [Display("Lastname")]
        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
    }
}
