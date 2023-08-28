using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Dtos
{
    public class OrderDto
    {
        [Display("Order ID")]
        public int Orderid { get; set; }
        
        public User User { get; set; }
        
        public int Usergroup { get; set; }
        
        public string Name { get; set; }
        
        public string Status { get; set; }
        
        [Display("Process type")]
        public string ProcessType { get; set; }
        
        [Display("Order type")]
        public string Ordertype { get; set; }
        
        [Display("Source file count")]
        public int Sourcefilecount { get; set; }
        
        [Display("Reference file count")]
        public int Referencefilecount { get; set; }
        
        [Display("Target file count")]
        public int Targetfilecount { get; set; }
        
        [Display("Requested due date")]
        public string RequestedDueDate { get; set; }
        
        [Display("Due date")]
        public string Duedate { get; set; }
        
        public string Delivery { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime Modified { get; set; }
        
        [Display("Source languages")]
        public List<string> Sourcelang { get; set; }
        
        [Display("Target languages")]
        public List<string> Targetlang { get; set; }
        
        [Display("Email address")]
        public string Emailaddress { get; set; }
        
        [Display("Email quote")]
        public int Emailquote { get; set; }
        
        [Display("Email file")]
        public int Emailfile { get; set; }
        
        [Display("Email done")]
        public int Emaildone { get; set; }
        
        [Display("Email submit")]
        public int Emailsubmit { get; set; }
        
        [Display("Email comment")]
        public int Emailcomment { get; set; }
        
        [Display("Quote required")]
        public int Quoterequired { get; set; }
        
        [Display("Auto approve")]
        public int Autoapprove { get; set; }
        
        [Display("Auto approve amt")]
        public int Autoapproveamt { get; set; }
        
        [Display("Estimated word count")]
        public int Estimatedwordcount { get; set; }
        
        [Display("Last delivery")]
        public string Lastdelivery { get; set; }
        
        [Display("Invoice date")]
        public string Invoicedate { get; set; }
        
        [Display("Invoice due")]
        public string Invoicedue { get; set; }
        
        [Display("In preparation")]
        public string InPreparation { get; set; }
        
        [Display("In progress")]
        public string InProgress { get; set; }
        
        [Display("In review")]
        public string InReview { get; set; }
        
        public string Completed { get; set; }
        
        public string Canceled { get; set; }
        
        [Display("Getting quote")]
        public string GettingQuote { get; set; }
        
        [Display("Needs approval")]
        public string NeedsApproval { get; set; }
        
        public string Comments { get; set; }
        
        public Account Account { get; set; }
    }

    public class Account
    {
        [Display("Plunet ID")]
        public string Plunetid { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        
        [Display("Last activity")]
        public DateTime Lastactivity { get; set; }
    }

    public class User
    {
        [Display("Plunet ID")]
        public string Plunetid { get; set; }
        
        [Display("First name")]
        public string Firstname { get; set; }
        
        [Display("Last name")]
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
