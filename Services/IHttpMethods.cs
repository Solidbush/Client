namespace Client.Services
{
    public interface IHttpMethods
    {
        public Task PutAsync(string key, string value);
        public Task<string> GetAsync(string key);
    }
}
