namespace InMemoryCaching.Cache
{
    public interface ICustomMemoryCache
    {
        T GetValue<T>(string key);

        void SetValue(string key, object value);
    }
}
