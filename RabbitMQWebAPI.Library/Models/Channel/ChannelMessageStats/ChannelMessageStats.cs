using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats
{
    public class ChannelMessageStats : Model
    {

        [JsonProperty(PropertyName = "publish")]
        public double publish;
        [JsonProperty(PropertyName = "publish_details")]
        public IDictionary<string, double> publish_details;

        [JsonProperty(PropertyName = "publish_in")]
        public double publish_in;
        [JsonProperty(PropertyName = "publish_in_details")]
        public IDictionary<string, double> publish_in_details;

        [JsonProperty(PropertyName = "publish_out")]
        public double publish_out;
        [JsonProperty(PropertyName = "publish_out_details")]
        public IDictionary<string, double> publish_out_details;

        [JsonProperty(PropertyName = "ack")]
        public double ack;
        [JsonProperty(PropertyName = "ack_details")]
        public IDictionary<string, double> ack_details;

        [JsonProperty(PropertyName = "deliver_get")]
        public double deliver_get;
        [JsonProperty(PropertyName = "deliver_get_details")]
        public IDictionary<string, double> deliver_get_details;

        [JsonProperty(PropertyName = "confirm")]
        public double confirm;
        [JsonProperty(PropertyName = "confirm_details")]
        public IDictionary<string, double> confirm_details;

        [JsonProperty(PropertyName = "return_unroutable")]
        public double return_unroutable;
        [JsonProperty(PropertyName = "return_unroutable_details")]
        public IDictionary<string, double> return_unroutable_details;

        [JsonProperty(PropertyName = "redeliver")]
        public double redeliver;
        [JsonProperty(PropertyName = "redeliver_details")]
        public IDictionary<string, double> redeliver_details;

        [JsonProperty(PropertyName = "deliver")]
        public double deliver;
        [JsonProperty(PropertyName = "deliver_details")]
        public IDictionary<string, double> deliver_details;

        [JsonProperty(PropertyName = "deliver_no_ack")]
        public double deliver_no_ack;
        [JsonProperty(PropertyName = "deliver_no_ack_details")]
        public IDictionary<string, double> deliver_no_ack_details;

        [JsonProperty(PropertyName = "get")]
        public double get;
        [JsonProperty(PropertyName = "get_details")]
        public IDictionary<string, double> get_details;

        [JsonProperty(PropertyName = "get_no_ack")]
        public double get_no_ack;
        [JsonProperty(PropertyName = "get_no_ack_details")]
        public IDictionary<string, double> get_no_ack_details;

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
            "redeliver_details",
           };
            }

            set { Keys = value; }
        }

        public ChannelMessageStats() { }
    }
}
