using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Interfaces;

namespace RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueueStatus
{
    public class QueueBackingQueueSentinel : Sentinel<QueueBackingQueueStatus, QueueBackingQueueStatusParameters>
    {
        public override QueueBackingQueueStatusParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            QueueBackingQueueStatusParameters parameters = new QueueBackingQueueStatusParameters();

            parameters.mode = parametersDictionary["mode"].ToString();
            parameters.q1 = Int32.Parse(parametersDictionary["q1"].ToString());
            parameters.q2 = Int32.Parse(parametersDictionary["q2"].ToString());
            parameters.q3 = Int32.Parse(parametersDictionary["q3"].ToString());
            parameters.q4 = Int32.Parse(parametersDictionary["q4"].ToString());
            parameters.delta = JsonConvert.DeserializeObject<List<string>>(parametersDictionary["delta"].ToString());
            parameters.len = Int32.Parse(parametersDictionary["len"].ToString());
            parameters.target_ram_count = parametersDictionary["target_ram_count"].ToString();
            parameters.next_seq_id = Int32.Parse(parametersDictionary["next_seq_id"].ToString());
            parameters.avg_ingress_rate = Int32.Parse(parametersDictionary["avg_ingress_rate"].ToString());
            parameters.avg_egress_rate = Int32.Parse(parametersDictionary["avg_egress_rate"].ToString());
            parameters.avg_ack_egress_rate = Int32.Parse(parametersDictionary["avg_ack_egress_rate"].ToString());
            parameters.avg_ack_ingress_rate = Int32.Parse(parametersDictionary["avg_ingress_rate"].ToString());

            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in QueueBackingQueueStatusKeys.keys)
            {
                if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
