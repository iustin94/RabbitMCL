using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Channel.MessageStats
{
    public static class MessageStatsKeys
    {
        public static HashSet<string> keys = new HashSet<string>()
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
            "get",
            "get_no_ack",
            "get_no_ack_details",
        };
    }
}
