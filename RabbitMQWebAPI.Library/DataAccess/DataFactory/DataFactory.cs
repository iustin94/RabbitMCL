using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models.Sentinel;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.DataAccess;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class DataFactory<TResultModel>: IDataFactory<TResultModel> where TResultModel: IModel, new()
    { 
        private HttpClient _client;

        public DataFactory(HttpClient client)
        {
            this._client = client;
        }

        public DataFactory() { }


        public async Task<List<TResultModel>> BuildModels(string path, ISentinelNew sentinel)
        {
            var result = await GetJsonString(path);

            JArray array = JsonConvert.DeserializeObject<JArray>(result);

            List<TResultModel> models = new List<TResultModel>();

            foreach (JObject data in array)
            {
                TResultModel model = new TResultModel();
                model = (TResultModel)sentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString()), model);

                models.Add(model);
            }

            return models;
        }

        public List<TResultModel> BuildModels(JArray info, ISentinelNew sentinel) 
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

        public async Task<string> GetJsonString(string path)
        {
            string result;

            using (_client)
            {
                using (
                    var response =
                        await _client.GetAsync(path, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }


            return result;
        }
    }
}
