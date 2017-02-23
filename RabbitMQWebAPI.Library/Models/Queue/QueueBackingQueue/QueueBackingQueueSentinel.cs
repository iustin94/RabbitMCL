using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueue
{
    public class QueueBackingQueueSentinel : SentinelNew<QueueBackingQueueStatus>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary, IModel model)
        {
            QueueBackingQueueStatus parameters = new QueueBackingQueueStatus();

            parameters.mode = parametersDictionary["mode"] == null
                ? String.Empty
                : parametersDictionary["mode"].ToString();
            parameters.q1 = Int32.Parse(parametersDictionary["q1"].ToString());
            parameters.q2 = Int32.Parse(parametersDictionary["q2"].ToString());
            parameters.q3 = Int32.Parse(parametersDictionary["q3"].ToString());
            parameters.q4 = Int32.Parse(parametersDictionary["q4"].ToString());
            parameters.delta = JsonConvert.DeserializeObject<List<string>>(parametersDictionary["delta"].ToString());
            parameters.len = Int32.Parse(parametersDictionary["len"].ToString());
            parameters.target_ram_count = parametersDictionary["target_ram_count"] == null
                ? String.Empty
                : parametersDictionary["target_ram_count"].ToString();
            parameters.next_seq_id = Int32.Parse(parametersDictionary["next_seq_id"].ToString());
            parameters.avg_ingress_rate = Int32.Parse(parametersDictionary["avg_ingress_rate"].ToString());
            parameters.avg_egress_rate = Int32.Parse(parametersDictionary["avg_egress_rate"].ToString());
            parameters.avg_ack_egress_rate = Int32.Parse(parametersDictionary["avg_ack_egress_rate"].ToString());
            parameters.avg_ack_ingress_rate = Int32.Parse(parametersDictionary["avg_ingress_rate"].ToString());

            return parameters;
        }
    }

}