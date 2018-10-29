using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaLibrary.Model;
using TraktNet;
using TraktNet.Enums;

namespace MediaLibrary.Services
{
    public class TraktProvider : MetadataProvider<Series>
    {
        public readonly TraktClient _client;

        public TraktProvider(string id, string secret)
        {
            _client = new TraktClient(id, secret);
        }

        public async Task<IEnumerable<Series>> SearchByNameAsync(string key)
        {
            var result = await _client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Show, key);
            var series = result.Value.Select(x => new Series
                {Name = x.Show.Title, ReleaseDate = x.Show.FirstAired.GetValueOrDefault()});
            return series;
        }

        public async Task<Series> Get(string id)
        {
            var result = await _client.Shows.GetShowAsync(id);
            return new Series
            {
                Name = result.Value.Title,
                ReleaseDate = result.Value.FirstAired.GetValueOrDefault(),
            };
        }
    }
}