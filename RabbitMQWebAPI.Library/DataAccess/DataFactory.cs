using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models.Sentinel;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public abstract class DataFactory : IDataFactory
    {
        public List<TResultModel> BuildModels<TResultModel>(JArray info, ISentinelNew sentinel) where TResultModel : IModel, new()
        {

            List<TResultModel> models = new List<TResultModel>();

            foreach (JObject data in info)
            {
                TResultModel model = new TResultModel();
                model = (TResultModel)sentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString()), model);

                models.Add(model);
            }

            return models;
        }
    }
}
