using System.Collections.Generic;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueue
{
    public struct QueueBackingQueueStatusParameters
    {
        public string mode;
        public double q1;
        public double q2;
        public List<string> delta;
        public double q3;
        public double q4;
        public double len;
        public string target_ram_count;
        public double next_seq_id;
        public double avg_ingress_rate;
        public double avg_egress_rate;
        public double avg_ack_ingress_rate;
        public double avg_ack_egress_rate;
    }
}
