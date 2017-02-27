using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.DataAccess.DataFactory
{
    public interface IDataFactory<TResultModel>
    {
        Task<List<TResultModel>> BuildModels(string path, ISentinel sentinel);

        Task<TResultModel> BuildModel(string path, ISentinel sentinel);

        Task<string> GetJsonString(string path);
    }
}
