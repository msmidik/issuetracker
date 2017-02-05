using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    interface IEmailService
    {
        void Send(string text);
    }
}
