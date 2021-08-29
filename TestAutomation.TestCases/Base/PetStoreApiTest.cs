using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.ApiManager;
using TestAutomation.Evernote.TestCases.Base;

namespace TestAutomation.TestCases.Base
{
    public class PetStoreApiTest : BaseApiTest
    {

        protected RestHandler restHandler = new RestHandler("https://petstore.swagger.io/v2/");

    }
}
