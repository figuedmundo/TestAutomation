using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.ApiManager.PetStore.Payload
{
    public class ApiResponse
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
