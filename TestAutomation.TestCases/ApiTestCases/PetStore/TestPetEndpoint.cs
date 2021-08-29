using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using TestAutomation.ApiManager.PetStore.Payload;
using TestAutomation.Framework.Utils;
using TestAutomation.TestCases.Base;
using TestAutomation.TestCases.Utils;

namespace TestAutomation.TestCases.ApiTestCases.PetStore
{
    public class TestPetEndpoint : PetStoreApiTest
    {
        [Test]
        public void TestCreatePet()
        {
            var petRequest = new Pet
            {
                Name = "tested",
                Status = "available"
            };

            var response = restHandler.Post<Pet>("pet", petRequest);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Id, Is.GreaterThan(0));
        }

        [Test]
        public void TestGetPet()
        {
            var petRequest = new Pet
            {
                Name = RandomHandler.Faker.Random.String2(10),
                Status = Status.Available
            };

            var createPetResponse = restHandler.Post<Pet>("pet", petRequest);

            var response = restHandler.Get<Pet>($"pet/{createPetResponse.Data.Id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Name, Is.EqualTo(petRequest.Name));
        }

        [Test]
        public void TestGetPetBySoldStatus()
        {
            var petRequest = new Pet
            {
                Name = RandomHandler.Faker.Random.String2(10),
                Status = Status.Sold
            };

            var createPetResponse = restHandler.Post<Pet>("pet", petRequest);
            
            SeleniumActions.Sleep(3);
            var response = restHandler.Get<List<Pet>>($"pet/findByStatus?status={Status.Sold}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Find(p => p.Id == createPetResponse.Data.Id), Is.Not.Null, "Pet not found in the Pet Array list with sold status");
            Assert.That(response.Data.Find(p => p.Id == createPetResponse.Data.Id).Name, Is.EqualTo(petRequest.Name));
        }
    }
}
