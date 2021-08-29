namespace TestAutomation.TestCases.Utils
{
    public class UserData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public void New()
        {
            var person = new Bogus.Person("en");
            FirstName = person.FirstName;
            LastName = person.LastName;
            UserName = person.UserName;
            Password = person.Random.AlphaNumeric(8) + "Test123!";
        }
    }
}
