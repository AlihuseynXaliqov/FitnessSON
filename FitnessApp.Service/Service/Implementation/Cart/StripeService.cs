﻿using FitnessApp.Core.Stripe;
using FitnessApp.Service.DTOs.Payment;
using FitnessApp.Service.Helper.Email;
using FitnessApp.Service.Service.Interface.Cart;
using FitnessApp.Service.Service.Interface.Users;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace FitnessApp.Service.Service.Implementation.Cart;

public class StripeService
{
    private readonly IMailService _mailService;
    private readonly ICartItemsService _cartItemsService;

    public StripeService(IOptions<StripeSettings> stripeSettings,
        IMailService mailService, ICartItemsService cartItemsService)
    {
        _mailService = mailService;
        _cartItemsService = cartItemsService;
        var stripeSettings1 = stripeSettings.Value;
        StripeConfiguration.ApiKey = stripeSettings1.Secretkey;
    }

    public async Task<Session> CreateCheckoutSession(PaymentDto paymentDto, string userId)
    {
        // Get the user's cart items
        var cartItems = await _cartItemsService.GetCartAsync(userId);

        // Create session options for Stripe
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>(),
            Mode = "payment",
            SuccessUrl = "http://localhost:5179/success?session_id={CHECKOUT_SESSION_ID}",
            CancelUrl = "http://localhost:5179/cancel",
            Metadata = new Dictionary<string, string>
            {
                { "email", paymentDto.BillingEmail },
                { "billingName", paymentDto.BillingName },
                { "billingPhone", paymentDto.BillingPhone },
                {
                    "billingAddress",
                    $"{paymentDto.BillingAddress.Line1}, {paymentDto.BillingAddress.City}, {paymentDto.BillingAddress.Country}"
                }
            }
        };
        foreach (var item in cartItems)
        {
            options.LineItems.Add(new SessionLineItemOptions
            {
                Quantity = item.Quantity,
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "usd",
                    UnitAmount = (long)(item.DiscountPrice * 100),
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.Name,
                        Images = new List<string> { item.ImageUrl }
                    }
                }
            });
        }

        var service = new SessionService();
        var session = await service.CreateAsync(options);


        var mailRequest = new MailRequest
        {
            ToEmail = paymentDto.BillingEmail,
            Subject = "Uğurlu Ödəniş",
            Body = $"Hormətli {paymentDto.BillingName}, sizin ödəniş uğurla yerinə yetirildi." +
                   "<br><br>" +
                   "Ən yaxşı arzularla,<br>" +
                   "FitnessApp Komandası"
        };

        await _mailService.SendEmailAsync(mailRequest);
        return session;
    }
}