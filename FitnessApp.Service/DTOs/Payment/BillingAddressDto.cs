﻿namespace FitnessApp.Service.DTOs.Payment;

public record BillingAddressDto
{
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}