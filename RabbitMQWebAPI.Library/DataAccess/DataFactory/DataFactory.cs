using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Error;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.DataAccess.DataFactory
{
    public class DataFactory<TResultModel>: IDataFactory<TResultModel> where TResultModel: IModel, new()
    { 
        private HttpClient _client;
        private ErrorSentinel errorSentinel = new ErrorSentinel();

        public DataFactory(HttpClient client)
        {
            this._client = client;
        }

      

        public async Task<List<TResultModel>> BuildModels(string path, ISentinel sentinel)
        {

            List<TResultModel> models = new List<TResultModel>();

            var result = await GetJsonString(path);


            Error errorModel= null;

            try
            {
                errorModel =
                    (Error)
                    errorSentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(result),
                        new Error());
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            if (errorModel!= null)
            {
                throw new Exception("Call to RabbitMQ api has failed."+ errorModel.ToString());
            }
            else
            {
               
                TResultModel model = new TResultModel();
                JArray array = JsonConvert.DeserializeObject<JArray>(result);
                foreach (JObject data in array)
                {
                    model = new TResultModel();
                    model = (TResultModel)sentinel.CreateModel(JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString()), model);

                    models.Add(model);
                }
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
