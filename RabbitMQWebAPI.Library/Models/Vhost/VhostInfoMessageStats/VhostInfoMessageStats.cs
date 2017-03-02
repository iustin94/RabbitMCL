using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Vhost.VhostInfoMessageStats
{
    public class VhostInfoMessageStats: Model
    {
        public double publish;
        public IDictionary<string, double> publish_details;

        public double publish_in;
        public IDictionary<string, double> publish_in_details;

        public double publish_out;
        public IDictionary<string, double> publish_out_details;

        public double ack;
        public IDictionary<string, double> ack_details;

        public double deliver_get;
        public IDictionary<string, double> deliver_get_details;

        public double confirm;
        public IDictionary<string, double> confirm_details;

        public double return_unroutable;
        public IDictionary<string, double> return_unroutable_details;

        public double redeliver;
        public IDictionary<string, double> redeliver_details;

        public double deliver;
        public IDictionary<string, double> deliver_details;

        public double deliver_no_ack;
        public IDictionary<string, double> deliver_no_ack_details;

        public double get;
        public IDictionary<string, double> get_details;

        public double get_no_ack;
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
            "deliver",
            "deliver_details",
            "deliver_no_ack",
            "deliver_no_ack_details",
            "get",
            "get_details",
            "get_no_ack",
            "get_no_ack_details",
        };
            }

            set { Keys = value; }
        }

        public VhostInfoMessageStats() { }

    }
}
