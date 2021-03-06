using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Gatekeeper.Client.Shared.Components.Form.FormValidator
{
    public class EmailValidator : IFormValidator
    {
        public Task<FormValidatorResponse> Check(string value, CancellationToken cancellationToken)
        {
            try {
                MailAddress addr = new MailAddress(value);
                if (addr.Address == value)
                {
                    return Task.FromResult(new FormValidatorResponse(true, null));
                }
            } catch {}

            return Task.FromResult(new FormValidatorResponse(false, "Email is not valid"));
        }
    }
}
