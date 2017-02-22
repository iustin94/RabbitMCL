using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Exchange.ExchangeMessageStats
{
    public class ExchangeMessageStats
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

        public ExchangeMessageStats() { }

        public ExchangeMessageStats(ExchangeMessageStatsParameters parameters)
        {
            this.publish = parameters.publish;
            this.publish_details = parameters.publish_details;
            this.publish_in = parameters.publish_in;
            this.publish_in_details = parameters.publish_in_details;
            this.publish_out = parameters.publish_out;
            this.publish_out_details = parameters.publish_out_details;
            this.ack = parameters.ack;
            this.ack_details = parameters.ack_details;
            this.deliver_get = parameters.deliver_get;
            this.deliver_get_details = parameters.deliver_get_details;
            this.confirm = parameters.confirm;
            this.confirm_details = parameters.confirm_details;
            this.return_unroutable = parameters.return_unroutable;
            this.return_unroutable_details = parameters.return_unroutable_details;
            this.redeliver = parameters.redeliver;
            this.redeliver_details = parameters.redeliver_details;
        }
    }
}
