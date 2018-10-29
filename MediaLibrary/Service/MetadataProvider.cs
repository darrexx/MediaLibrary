using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaLibrary.Services
{
    public interface MetadataProvider<Model>
    {
        Task<IEnumerable<Model>> SearchByNameAsync(string key);

        Task<Model> Get(string id);

    }
}