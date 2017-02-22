using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RabbitMQWebAPI.Library.Models;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.DataAccess
{
    interface IDataFactory
    {
        List<TResultModel> BuildModels<TResultModel>(JArray info, ISentinelNew sentinel) where TResultModel : IModel, new();
    }
}
