using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsvPad.UI.Web.Forms.Logic
{
    public class MessageException : Exception
    {
        public MessageException(string message) : base(message)
        {

        }
    }
}