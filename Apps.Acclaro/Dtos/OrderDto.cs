using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Dtos
{
    public class OrderDto
    {
        public int Orderid { get; set; }
        public User User { get; set; }
        public int Usergroup { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string ProcessType { get; set; }
        public string Ordertype { get; set; }
        public int Sourcefilecount { get; set; }
        public int Referencefilecount { get; set; }
        public int Targetfilecount { get; set; }
        public string RequestedDueDate { get; set; }
        public string Duedate { get; set; }
        public string Delivery { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public List<string> Sourcelang { get; set; }
        public List<string> Targetlang { get; set; }
        public string Emailaddress { get; set; }
        public int Emailquote { get; set; }
        public int Emailfile { get; set; }
        public int Emaildone { get; set; }
        public int Emailsubmit { get; set; }
        public int Emailcomment { get; set; }
        public int Quoterequired { get; set; }
        public int Autoapprove { get; set; }
        public int Autoapproveamt { get; set; }
        public int Estimatedwordcount { get; set; }
        public string Lastdelivery { get; set; }
        public string Invoicedate { get; set; }
        public string Invoicedue { get; set; }
        public string InPreparation { get; set; }
        public string InProgress { get; set; }
        public string InReview { get; set; }
        public string Completed { get; set; }
        public string Canceled { get; set; }
        public string GettingQuote { get; set; }
        public string NeedsApproval { get; set; }
        public string Comments { get; set; }
        public Account Account { get; set; }
    }

    public class Account
    {
        public string Plunetid { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Lastactivity { get; set; }
    }

    public class User
    {
        public string Plunetid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
