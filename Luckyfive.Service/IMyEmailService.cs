using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.Service
{
    public interface IMyEmailService
    {
        Task SendConfirmationEmail(string postbackUrl, string userEmail);
    }
}
