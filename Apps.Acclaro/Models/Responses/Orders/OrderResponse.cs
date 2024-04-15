using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Responses.Orders;

public class OrderResponse
{
    [Display("Order ID")]
    public string Orderid { get; set; }

    [Display("User")]
    public User User { get; set; }

    [Display("User group")]
    public string Usergroup { get; set; }

    [Display("Plunet order ID")]
    public string PlunetOrderid { get; set; }

    [Display("Plunet request ID")]
    public string PlunetRequestid { get; set; }

    [Display("Plunet quote ID")]
    public object PlunetQuoteid { get; set; }

    [Display("Name")]
    public string Name { get; set; }

    [Display("Status")]
    public string Status { get; set; }

    [Display("Process type")]
    public string ProcessType { get; set; }

    [Display("Order type")]
    public string OrderType { get; set; }

    [Display("Source file count")]
    public int Sourcefilecount { get; set; }

    [Display("Reference file count")]
    public int Referencefilecount { get; set; }

    [Display("Target file count")]
    public int Targetfilecount { get; set; }

    [Display("Requested due date")]
    public DateTime? RequestedDueDate { get; set; }

    [Display("Due date")]
    public DateTime? Duedate { get; set; }

    [Display("Client reference")]
    public string Clientref { get; set; }

    [Display("Delivery")]
    public string Delivery { get; set; }

    [Display("Created")]
    public DateTime? Created { get; set; }

    [Display("Modified")]
    public DateTime? Modified { get; set; }

    [Display("Source language codes")]
    public List<string> Sourcelang { get; set; }

    [Display("Target language codes")]
    public List<string> Targetlang { get; set; }

    [Display("Email address")]
    public string Emailaddress { get; set; }

    [Display("Tags")]
    public List<string> Tags { get; set; }

    [Display("Estimated word count")]
    public int Estimatedwordcount { get; set; }

    [Display("Comments")]
    public string Comments { get; set; }

    [Display("Account")]
    public Account Account { get; set; }

    public OrderResponse(OrderDto dto)
    {
        Orderid = dto.Orderid.ToString();
        User = dto.User;
        Usergroup = dto.Usergroup.ToString();
        PlunetOrderid = dto.PlunetOrderid;
        PlunetQuoteid = dto.PlunetQuoteid;
        PlunetRequestid = dto.PlunetRequestid;
        Name = dto.Name;
        Status = dto.Status;
        ProcessType = dto.ProcessType;
        OrderType = dto.Ordertype;
        Sourcefilecount = dto.Sourcefilecount;
        Referencefilecount = dto.Referencefilecount;
        Targetfilecount = dto.Targetfilecount;
        RequestedDueDate = dto.RequestedDueDate;
        Duedate = dto.Duedate;
        Clientref = dto.Clientref;
        Delivery = dto.Delivery;
        Created = dto.Created;
        Modified = dto.Modified;
        Sourcelang = dto.Sourcelang;
        Targetlang = dto.Targetlang;
        Emailaddress = dto.Emailaddress;
        Tags = dto.Tags;
        Estimatedwordcount = dto.Estimatedwordcount;
        Comments = dto.Comments;
        Account = dto.Account;
    }
}