using System;
using System.Collections.Generic;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueue
{
    public class QueueBackingQueueStatus: Model
    {
        public string mode { get; internal set; }
        public double q1 { get; internal set; }
        public double q2 { get; internal set; }
        public List<string> delta { get; internal set; }
        public double q3 { get; internal set; }
        public double q4 { get; internal set; }
        public double len { get; internal set; }
        public string target_ram_count { get; internal set; }
        public double next_seq_id { get; internal set; }
        public double avg_ingress_rate { get; internal set; }
        public double avg_egress_rate { get; internal set; }
        public double avg_ack_ingress_rate { get; internal set; }
        public double avg_ack_egress_rate {get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
               return new HashSet<string>()
        {
            "mode",
            "q1",
            "q2",
            "delta",
            "q3",
            "q4",
            "len",
            "target_ram_count",
            "next_seq_id",
            "avg_ingress_rate",
            "avg_egress_rate",
            "avg_ack_ingress_rate",
            "avg_ack_egress_rate"
        };
            }

            set { this.Keys = value; }
        }

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
