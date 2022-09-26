using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OMDA.Configurations;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace OMDA.Services;

public class TwilioService
{
    private readonly TwilioSettings _twilioSettings;

    public TwilioService(IOptions<TwilioSettings> twilioSettings)
    {
        _twilioSettings = twilioSettings.Value;
    }

    public async Task<MessageResource?> SendMessageAsync(string message, string to)
    {
        TwilioClientInit();

        var messageResource = await MessageResource.CreateAsync(
            body: message,
            from: new PhoneNumber(_twilioSettings.TwilioPhoneNumber),
            to: new PhoneNumber(to)
        );

        return messageResource;
    }

    public async Task<ValidationRequestResource?> ValidateCallerAsync(string name, string phone)
    {
        TwilioClientInit();

        var validationRequest = await ValidationRequestResource.CreateAsync(
            friendlyName: name,
            phoneNumber: new PhoneNumber(phone)
        );

        return validationRequest;
    }

    private void TwilioClientInit()
    {
        TwilioClient.Init(_twilioSettings.AccountSID, _twilioSettings.AuthToken);
    }
}