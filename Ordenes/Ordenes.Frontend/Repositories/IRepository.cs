namespace Ordenes.Frontend.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> GetAsync<T>(String url);
        Task<HttpResponseWrapper<object>> PostAsync<T>(String url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PutAsync<T, TActionResponse>(string url, T model);
    }
}
