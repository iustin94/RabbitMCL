using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Exchange
{
    public class ExchangeInfo
    {
        [JsonProperty(PropertyName = "message_stats")]
        public ExchangeMessageStats.ExchangeMessageStats message_stats { get; private set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; private set; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public string type { get; private set; }

        [JsonProperty(PropertyName = "durable")]
        public bool durable { get; private set; }

        [JsonProperty(PropertyName = "auto_delete")]
        public bool auto_delete { get; private set; }

        [JsonProperty(PropertyName = "internal")]
        public bool _internal { get; private set; }

        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string, string> arguments { get; private set; }

        public ExchangeInfo() { }

        public ExchangeInfo(ExchangeInfoParameters parameters)
        {
            this.message_stats = parameters.message_stats;
            this.name = parameters.name;
            this.vhost = parameters.vhost;
            this.type = parameters.type;
            this.durable = parameters.durable;
            this.auto_delete = parameters.auto_delete;
            this._internal = parameters._internal;
            this.arguments = parameters.arguments;
        }
    }
}
