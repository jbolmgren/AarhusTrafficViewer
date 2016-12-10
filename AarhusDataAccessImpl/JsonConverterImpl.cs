namespace AarhusDataAccessImpl
{


    public interface IJsonConverter
    {
        T Deserialize<T>(string json);
    }

    public class JsonConverterImpl : IJsonConverter
    {
        public T Deserialize<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}