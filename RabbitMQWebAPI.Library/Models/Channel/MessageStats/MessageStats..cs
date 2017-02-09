using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQWebAPI.Library.Models.Channel.MessageStats
{
    public class MessageStats
    {
        public int publish;
        public IDictionary<string, int> publish_details;

        public int publish_in;
        public IDictionary<string, int> publish_in_details;

        public int publish_out;
        public IDictionary<string, int> publish_out_details;

        public int ack;
        public IDictionary<string, int> ack_details;

        public int deliver_get;
        public IDictionary<string, int> deliver_get_details;

        public int confirm;
        public IDictionary<string, int> confirm_details;

        public int return_unroutable;
        public IDictionary<string, int> return_unroutable_details;

        public int redeliver;
        public IDictionary<string, int> redeliver_details;

        public int deliver;
        public IDictionary<string, int> deliver_details;

        public int deliver_no_ack;
        public IDictionary<string, int> deliver_no_ack_details;

        public int get;
        public IDictionary<string, int> get_details;

        public int get_no_ack;
        public IDictionary<string, int> get_no_ack_details;

        public MessageStats(MessageStatsParameters parameters)
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
            this.deliver = parameters.deliver;
            this.deliver_details = parameters.deliver_details;
            this.deliver_no_ack = parameters.deliver_no_ack;
            this.deliver_no_ack_details = parameters.deliver_no_ack_details;
            this.get = parameters.get;
            this.get_details = parameters.get_details;
            this.get_no_ack = parameters.get_no_ack;
            this.get_no_ack_details = parameters.get_no_ack_details;
        }
    }
}
