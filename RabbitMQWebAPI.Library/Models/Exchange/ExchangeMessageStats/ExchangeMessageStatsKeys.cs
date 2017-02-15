using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Exchange.ExchangeMessageStats
{
    public static class ExchangeMessageStatsKeys
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
            "redeliver_details"
        };
    }
}
