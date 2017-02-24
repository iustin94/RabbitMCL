using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.DataAccess.DataFactory
{
    public interface IDataFactory<TResultModel>
   {
        List<TResultModel> BuildModels(JArray info, ISentinel sentinel);

        Task<string> GetJsonString(string path);
    }
}
