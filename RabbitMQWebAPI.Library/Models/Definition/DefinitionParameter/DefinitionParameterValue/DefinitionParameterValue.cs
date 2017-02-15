using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Definition.DefinitionParameter.DefinitionParameterValue
{
    public class DefinitionParameterValue
    {
        public string src_uri { get; private set; }
        public string src_queue { get; private set; }
        public string dest_uri { get; private set; }
        public string dest_queue { get; private set; }
        public int prefetch_count { get; private set; }
        public int reconnect_delay { get; private set; }
        public bool add_forward_headers { get; private set; }
        public string ack_mode { get; private set; }
        public string delete_after { get; private set; }

        public DefinitionParameterValue() { }
        public DefinitionParameterValue(DefinitionParameterValueParameters parameters)
        {
            this.src_uri = parameters.src_uri;
            this.src_queue = parameters.src_queue;
            this.dest_uri = parameters.dest_uri;
            this.dest_queue = parameters.dest_queue;
            this.prefetch_count = parameters.prefetch_count;
            this.reconnect_delay = parameters.reconnect_delay;
            this.add_forward_headers = parameters.add_forward_headers;
            this.ack_mode = parameters.ack_mode;
            this.delete_after = parameters.delete_after;
        }
    }
}
