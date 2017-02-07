using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models
{
    class MessageStats
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

        public int confirms;
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

        public MessageStats(int publish, IDictionary<string, int> publishDetails, int publishIn, IDictionary<string, int> publishInDetails, int publishOut, IDictionary<string, int> publishOutDetails, int ack, IDictionary<string, int> ackDetails, int deliverGet, IDictionary<string, int> deliverGetDetails, int confirms, IDictionary<string, int> confirmDetails, int returnUnroutable, IDictionary<string, int> returnUnroutableDetails, int redeliver, IDictionary<string, int> redeliverDetails, int deliver, IDictionary<string, int> deliverDetails, int deliverNoAck, IDictionary<string, int> deliverNoAckDetails, int get, IDictionary<string, int> getDetails, int getNoAck, IDictionary<string, int> getNoAckDetails)
        {
            this.publish = publish;
            publish_details = publishDetails;
            publish_in = publishIn;
            publish_in_details = publishInDetails;
            publish_out = publishOut;
            publish_out_details = publishOutDetails;
            this.ack = ack;
            ack_details = ackDetails;
            deliver_get = deliverGet;
            deliver_get_details = deliverGetDetails;
            this.confirms = confirms;
            confirm_details = confirmDetails;
            return_unroutable = returnUnroutable;
            return_unroutable_details = returnUnroutableDetails;
            this.redeliver = redeliver;
            redeliver_details = redeliverDetails;
            this.deliver = deliver;
            deliver_details = deliverDetails;
            deliver_no_ack = deliverNoAck;
            deliver_no_ack_details = deliverNoAckDetails;
            this.get = get;
            get_details = getDetails;
            get_no_ack = getNoAck;
            get_no_ack_details = getNoAckDetails;
        }
    }
}
}
