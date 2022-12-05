using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApiClient.Data.Exceptions
{
    class ErrorLogin : Exception
    {
        public ErrorLogin(string message) : base(message)
        {
        }

    }
}