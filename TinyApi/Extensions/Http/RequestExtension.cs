using Microsoft.AspNetCore.Http;
using System.Linq;

namespace TinyApi.Extensions.Http
{
    public static class RequestExtension
    {
        public static string GetHeader(this HttpRequest request, string key)
        {
            return request.Headers.FirstOrDefault(x => x.Key == key).Value.FirstOrDefault();
        }
    }
}
