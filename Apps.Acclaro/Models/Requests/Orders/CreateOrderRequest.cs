﻿using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class CreateOrderRequest
    {
        [Display("Name")]
        public string Name { get; set; }

        [Display("Comment")]
        public string? Comment { get; set; }
        
        [Display("Due date")]
        public DateTime? DueDate { get; set; }

        [Display("Delivery", Description = "Additional upload repositories for completed, translations besides the My Acclaro customer portal.")]
        [DataSource(typeof(DeliveryHandler))]
        public string? Delivery { get; set; }

        [Display("Estimated word count", Description = "May be used to assist with making a quote for this order, if the information is available.")]
        public int? EstimatedWordCount { get; set; }

        [Display("Client reference", Description = "If supplied when the order is loaded, it will be returned in all future calls about this order.")]
        public string? ClientRef { get; set; }

        [Display("Order type")]
        [DataSource(typeof(OrderTypeDto))]
        public string? Type { get; set; }

        [Display("Process type")]
        [DataSource(typeof(OrderProcessTypeHandler))]
        public string? ProcessType { get; set; }

        [Display("Callback URL")]
        public string? CallbackUrl { get; set; }

        [Display("Callback email")]
        public string? CallbackEmail { get; set; }

        [Display("Tags")]
        public IEnumerable<string>? Tags { get; set; }
    }
}
