using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSwap.Wpf
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
