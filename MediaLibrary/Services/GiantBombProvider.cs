using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MediaLibrary.Model;
using Newtonsoft.Json;

namespace MediaLibrary.Services
{
    public class GiantBombProvider : MetadataProvider<Game>
    {
        private readonly string _apiKey;
        private HttpClient _client;

        public GiantBombProvider(string apiKey, string apiUrl)
        {
            _apiKey = apiKey;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(apiUrl),
                DefaultRequestHeaders = { UserAgent = { ProductInfoHeaderValue.Parse("test") } }
            };
        }
        //We are going to do a test query. This can be done in a browser by entering a URL into the address bar. Fill in your key with the URL below to load up some Metroid Prime 3 data (Hey, I'm playing it now!),
        //
        //http://www.giantbomb.com/api/game/3030-4725/?api_key=[YOUR-KEY]
        //
        //If your API key is working, you should get a bunch of text back(XML data) that has info on Metroid Prime 3.
        //
        //Let's do another test,
        //
        //    http://www.giantbomb.com/api/game/3030-4725/?api_key=[YOUR-KEY]&format=json&field_list=genres,name
        //
        //This illustrates a few things about the query structure.
        //
        //    http://www.giantbomb.com/api/[RESOURCE-TYPE]/[RESOURCE-ID]/?api_key=[YOUR-KEY]&format=[RESPONSE-DATA-FORMAT]&field_list=[COMMA-SEPARATED-LIST-OF-RESOURCE-FIELDS]
        public async Task<Game> Get(string id)
        {
            var response = await _client.GetAsync($"game/{id}?api_key={_apiKey}&format=json");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync();
            throw new System.NotImplementedException();
        }

        //Doing a search is very similar to accessing content.
        // 
        // http://www.giantbomb.com/api/search?api_key=[YOUR-KEY]&format=[RESPONSE-DATA-FORMAT]&query=[YOUR-SEARCH]&resources=[SOME-TYPES]
        // 
        // Example:
        // http://www.giantbomb.com/api/search/?api_key=[YOUR-KEY]&format=json&query="metroid prime"&resources=game
        // 
        // 
        public async Task<IEnumerable<Game>> SearchByNameAsync(string name)
        {
            var response =
                await _client.GetAsync($"search/?api_key={_apiKey}&format=json&query=\"{name}\"&resources=game");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<GiantBombResponse>(content);
            return responseObject.Results;
        }
    }
}