using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueue
{
    public class QueueBackingQueueStatusSentinel : Sentinel<QueueBackingQueueStatus>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            QueueBackingQueueStatus parameters = new QueueBackingQueueStatus();

            parameters.mode = parametersDictionary["mode"] == null
                ? String.Empty
                : parametersDictionary["mode"].ToString();
            parameters.q1 = double.Parse(parametersDictionary["q1"].ToString());
            parameters.q2 = double.Parse(parametersDictionary["q2"].ToString());
            parameters.q3 = double.Parse(parametersDictionary["q3"].ToString());
            parameters.q4 = double.Parse(parametersDictionary["q4"].ToString());
            parameters.delta = JsonConvert.DeserializeObject<List<string>>(parametersDictionary["delta"].ToString());
            parameters.len = double.Parse(parametersDictionary["len"].ToString());
            parameters.target_ram_count = parametersDictionary["target_ram_count"] == null
                ? String.Empty
                : parametersDictionary["target_ram_count"].ToString();
            parameters.next_seq_id = double.Parse(parametersDictionary["next_seq_id"].ToString());
            parameters.avg_ingress_rate = double.Parse(parametersDictionary["avg_ingress_rate"].ToString());
            parameters.avg_egress_rate = double.Parse(parametersDictionary["avg_egress_rate"].ToString());
            parameters.avg_ack_egress_rate = double.Parse(parametersDictionary["avg_ack_egress_rate"].ToString());
            parameters.avg_ack_ingress_rate = double.Parse(parametersDictionary["avg_ingress_rate"].ToString());

            return parameters;
        }
    }

}