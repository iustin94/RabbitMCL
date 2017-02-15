using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueueStatus
{
    public struct QueueBackingQueueStatusParameters
    {
        public string mode;
        public int q1;
        public int q2;
        public List<string> delta;
        public int q3;
        public int q4;
        public int len;
        public string target_ram_count;
        public int next_seq_id;
        public int avg_ingress_rate;
        public int avg_egress_rate;
        public int avg_ack_ingress_rate;
        public int avg_ack_egress_rate;
    }
}
