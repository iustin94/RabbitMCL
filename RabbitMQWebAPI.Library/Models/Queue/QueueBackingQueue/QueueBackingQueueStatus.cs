using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueueStatus
{
    public class QueueBackingQueueStatus
    {
        public string mode { get; private set; }
        public int q1 { get; private set; }
        public int q2 { get; private set; }
        public List<string> delta { get; private set; }
        public int q3 { get; private set; }
        public int q4 { get; private set; }
        public int len { get; private set; }
        public string target_ram_count { get; private set; }
        public int next_seq_id { get; private set; }
        public int avg_ingress_rate { get; private set; }
        public int avg_egress_rate { get; private set; }
        public int avg_ack_ingress_rate { get; private set; }
        public int avg_ack_egress_rate {get; private set; }

        public QueueBackingQueueStatus() { }

        public QueueBackingQueueStatus(QueueBackingQueueStatusParameters parameters)
        {
            this.mode = parameters.mode;
            this.q1 = parameters.q1;
            this.q2 = parameters.q2;
            this.q3 = parameters.q3;
            this.q4 = parameters.q4;
            this.delta = parameters.delta;
            this.len = parameters.len;
            this.target_ram_count = parameters.target_ram_count;
            this.next_seq_id = parameters.next_seq_id;
            this.avg_ingress_rate = parameters.avg_ingress_rate;
            this.avg_egress_rate = parameters.avg_egress_rate;
            this.avg_ack_egress_rate = parameters.avg_ack_egress_rate;
            this.avg_ack_ingress_rate = parameters.avg_ingress_rate;
        }
    }
}
