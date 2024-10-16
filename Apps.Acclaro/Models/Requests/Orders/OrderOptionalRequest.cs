﻿using Apps.Acclaro.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Acclaro.Models.Requests.Orders;

public class OrderOptionalRequest
{
    [Display("Order ID")]
    [DataSource(typeof(OrderHandler))]
    public string? Id { get; set; }
}