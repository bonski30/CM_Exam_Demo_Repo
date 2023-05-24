using Bogus;
using Cloudmarc.Test.Pages.ToolsQA.Models;

namespace Cloudmarc.Test.Pages.ToolsQA.TestData
{
    public class TestDataFaker
    {
        public static UserAccount GenerateNewAccountDetails()
        {
            string fName = Faker.Name.First();
            string lName = Faker.Name.Last();
            string username = Faker.Internet.UserName();
            string password = $"Password{Guid.NewGuid().ToString("N").Substring(0, 5)}123!!!";

            return new UserAccount
            {
                FirstName = fName,
                LastName = lName,
                UserName = username,
                Password = password                
            };
        }
    }
}
