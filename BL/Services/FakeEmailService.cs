using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    class FakeEmailService : IEmailService
    {
        public void Send(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }
    }
}
