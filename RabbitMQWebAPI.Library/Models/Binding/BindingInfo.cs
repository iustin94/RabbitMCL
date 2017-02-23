using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Binding
{
    /// <summary>
    /// Container for information on Bindings entity retrieved from the RabbitAPI.
    /// </summary>
    public class BindingInfo : Model
    {
        public override HashSet<string> Keys
        {
            get
            {
                return new HashSet<string>()
                {
                  "source",
            "vhost",
            "destination",
            "destination_type",
            "routing_key",
            "arguments",
            "properties_key" };
            }
            set { Keys = value; }
        }

        [JsonProperty(PropertyName = "source")]
        public string source { internal set; get; }

        [JsonProperty(PropertyName = "vhost")]
        public string vhost { internal set; get; }

        [JsonProperty(PropertyName = "destination")]
        public string destination { internal set; get; }

        [JsonProperty(PropertyName = "destination_type")]
        public string destination_type { internal set; get; }

        [JsonProperty(PropertyName = "routing_key")]
        public string routing_key { internal set; get; }

        [JsonProperty(PropertyName = "arguments")]
        public IDictionary<string, string> arguments { internal set; get; }

        [JsonProperty(PropertyName = "properties_key")]
        public string properties_key { internal set; get; }

        public BindingInfo(BindingInfoParameters parameters)
        {
            this.arguments = parameters.arguments;
            this.destination = parameters.destination;
            this.destination_type = parameters.destination_type;
            this.properties_key = parameters.properties_key;
            this.routing_key = parameters.routing_key;
            this.source = parameters.source;
            this.vhost = parameters.vhost;
        }

        public BindingInfo() { }

        public override string ToString()
        {
            string str = "{" + "\n"+
                         "source:" + source + "\n" +
                         "vhost:" + vhost + "\n" +
                         "destination" + destination + "\n" +
                         "destination_type" + destination + "\n" +
                         "routing_key"+ routing_key + "\n" +
                         "arguments"+ arguments + "\n" +
                         "properties_key" +properties_key+ "\n" +
                "}" + "\n";

            return str;
        }
    }
}
