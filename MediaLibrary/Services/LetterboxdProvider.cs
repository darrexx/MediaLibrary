using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using MediaLibrary.Model;

namespace MediaLibrary.Services
{
    public class LetterboxdProvider : MetadataProvider<Movie>
    {
        private readonly string _apiUrl;
        private readonly string _apiKey;

        public LetterboxdProvider(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
        }

        public Task<IEnumerable<Movie>> SearchByNameAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        private object Sign(string method, string url, string body = null)
        {
            if (method == null) throw new ArgumentException("Method has to be not null");
            if (url == null) throw new ArgumentException("url has to be not null");

            method = method.ToUpper();
            string stringToSalt;
            if (body == null)
            {
                stringToSalt = $"{method}\u0000{url}\u0000";
            }
            else
            {
                stringToSalt = $"{method}\u0000{url}\u0000{body}";
            }

            throw new NotImplementedException();
        }

        private static byte[] HashHmac(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        private string CreateUrl(string path, Dictionary<string, string> parameters)
        {
            var uriBuilder = new UriBuilder(_apiUrl);
            uriBuilder.Path = path;

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query["nonce"] = Guid.NewGuid().ToString();
            query["apikey"] = _apiKey;
            query["timestamp"] = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

            foreach (var parameter in parameters)
            {
                query[parameter.Key] = parameter.Value;
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.ToString();
        }
    }
}