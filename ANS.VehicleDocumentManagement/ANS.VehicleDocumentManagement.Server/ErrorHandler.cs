using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANS.VehicleDocumentManagement.Server
{
    public class ErrorHandler
    {
        public string ErrorMessage { get; set; }
        public String ErrorDescription { get; set; }
        public ErrorHandler(string pErrorMessage, string pErrorDesc)
        {
            ErrorMessage = pErrorMessage;
            ErrorDescription = pErrorDesc;
        }
    }
}
