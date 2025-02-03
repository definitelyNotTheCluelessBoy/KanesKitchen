using System.Text.Json;

namespace KanesKitchenClient.Services
{
    public static class Serialization
    {
        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public static IList<T> DeserializeList<T>(string json)
        {
            return JsonSerializer.Deserialize<IList<T>>(json);
        }
    }
}
