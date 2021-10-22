namespace Boyner.API.CrossCuttingConcerns
{
    public interface ICacheManager
    {
        T Gett<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
