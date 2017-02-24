using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Exchange.ExchangeMessageStats
{
    public class ExchangeMessageStats: Model
    {
        [JsonProperty(PropertyName = "publish")]
        public int publish;

        [JsonProperty(PropertyName = "publish_details")]
        public IDictionary<string, int> publish_details;

        [JsonProperty(PropertyName = "publish_in")]
        public int publish_in;

        [JsonProperty(PropertyName = "publish_in_details")]
        public IDictionary<string, int> publish_in_details;

        [JsonProperty(PropertyName = "publish_out")]
        public int publish_out;

        [JsonProperty(PropertyName = "publish_out_details")]
        public IDictionary<string, int> publish_out_details;

        [JsonProperty(PropertyName = "ack")]
        public int ack;

        [JsonProperty(PropertyName = "ack_details")]
        public IDictionary<string, int> ack_details;

        [JsonProperty(PropertyName = "deliver_get")]
        public int deliver_get;

        [JsonProperty(PropertyName = "deliver_get_details")]
        public IDictionary<string, int> deliver_get_details;

        [JsonProperty(PropertyName = "confirm")]
        public int confirm;
        
        [JsonProperty(PropertyName = "confirm_details")]
        public IDictionary<string, int> confirm_details;

        [JsonProperty(PropertyName = "return_unroutable")]
        public int return_unroutable;

        [JsonProperty(PropertyName = "return_unroutable_details")]
        public IDictionary<string, int> return_unroutable_details;

        [JsonProperty(PropertyName = "redeliver")]
        public int redeliver;

        [JsonProperty(PropertyName = "redeliver_details")]
        public IDictionary<string, int> redeliver_details;

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "publish",
            "publish_details",
            "publish_in",
            "publish_in_details",
            "publish_out",
            "publish_out_details",
            "ack",
            "ack_details",
            "deliver_get",
            "deliver_get_details",
            "confirm",
            "confirm_details",
            "return_unroutable",
            "return_unroutable_details",
            "redeliver",
            "redeliver_details"
        };
            }

            set { Keys = value; }
        }

        public ExchangeMessageStats() { }
    }
}
