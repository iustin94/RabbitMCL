using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.ChannelMessageStats
{
    public struct ChannelMessageStatsParameters
    {
        public int publish;
        public Dictionary<string, int> publish_details;

        public int publish_in;
        public Dictionary<string, int> publish_in_details;

        public int publish_out;
        public Dictionary<string, int> publish_out_details;

        public int ack;
        public Dictionary<string, int> ack_details;

        public int deliver_get;
        public Dictionary<string, int> deliver_get_details;

        public int confirm;
        public Dictionary<string, int> confirm_details;

        public int return_unroutable;
        public Dictionary<string, int> return_unroutable_details;

        public int redeliver;
        public Dictionary<string, int> redeliver_details;

        public int deliver;
        public Dictionary<string, int> deliver_details;

        public int deliver_no_ack;
        public Dictionary<string, int> deliver_no_ack_details;

        public int get;
        public Dictionary<string, int> get_details;

        public int get_no_ack;
        public Dictionary<string, int> get_no_ack_details;

    }
}
