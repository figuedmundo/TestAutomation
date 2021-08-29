using Newtonsoft.Json;

namespace TestAutomation.ApiManager
{
    public class JsonHandler
    {
        public static string Serialize<T>(T jsonObject)
        {
            return JsonConvert.SerializeObject(jsonObject);
        }

        public static T Deserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
