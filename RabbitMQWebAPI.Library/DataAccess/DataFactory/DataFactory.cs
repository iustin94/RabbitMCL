using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.DataAccess.DataFactory
{
    public class DataFactory<TResultModel>: IDataFactory<TResultModel> where TResultModel: IModel, new()
    { 
        private HttpClient _client;

        public DataFactory(HttpClient client)
        {
            this._client = client;
        }

        public DataFactory() { }


        public async Task<List<TResultModel>> BuildModels(string path, ISentinel sentinel)
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

        public async Task<TResultModel> BuildModel(string path, ISentinel sentinel)
        {
            var result = await GetJsonString(path);

            JObject obj = JsonConvert.DeserializeObject<JObject>(result);

            TResultModel model =
                (TResultModel)
                sentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(obj.ToString()), new TResultModel());

            return model;
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
