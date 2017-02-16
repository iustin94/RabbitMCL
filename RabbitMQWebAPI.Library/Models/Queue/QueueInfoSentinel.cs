using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.DataAccess;
using RabbitMQWebAPI.Library.Interfaces;
using RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueueStatus;
using RabbitMQWebAPI.Library.Models.Queue.QueueGarbageCollection;

namespace RabbitMQWebAPI.Library.Models.Queue
{
    public class QueueInfoSentinel : Sentinel<QueueInfo, QueueInfoParameters>
    {
        public override QueueInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            QueueInfoParameters parameters = new QueueInfoParameters();
            
            QueueBackingQueueSentinel queueBackingQueueSentinel = new QueueBackingQueueSentinel();
            QueueGarbageCollectionSentinel queueBackingQueueGarbageCollectionSentinel = new QueueGarbageCollectionSentinel();

            parameters.memory = Int32.Parse(parametersDictionary["memory"].ToString());

            parameters.reductions = Int32.Parse(parametersDictionary["reductions"].ToString());
            parameters.recutions_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["reductions_details"].ToString());

            parameters.messages = Int32.Parse(parametersDictionary["messages"].ToString());
            parameters.messages_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["message_details"].ToString());

            parameters.messages_ready = Int32.Parse(parametersDictionary["messages_ready"].ToString());
            parameters.messages_ready_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["messages_ready_details"].ToString());


            parameters.messages_unacknowledged = Int32.Parse(parametersDictionary["messages_unacknowledged"].ToString());
            parameters.messages_unacknowledged_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["messages_unacknowledged_details"].ToString());

            parameters.idle_since = parametersDictionary["idle_since"].ToString();
            parameters.consumer_utilisation = parametersDictionary["consumer_utilisation"].ToString();
            parameters.policy = parametersDictionary["policy"].ToString();
            parameters.exclusive_consumer_tag = parametersDictionary["exclusive_consumer_tag"].ToString();
            parameters.consumers = Int32.Parse(parametersDictionary["consumers"].ToString());
            parameters.recoverable_slaves = parametersDictionary["recoverable_slaves"].ToString();
            parameters.state = State.EvaluateState(parametersDictionary["state"].ToString());

            parameters.garbage_collection =
                queueBackingQueueGarbageCollectionSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["garbage_collection"].ToString()));

            parameters.messages_ram = Int32.Parse(parametersDictionary["messages_ram"].ToString());
            parameters.messages_ready_ram = Int32.Parse(parametersDictionary["messages_ready_ram"].ToString());
            parameters.messages_unacknowledged_ram =
                Int32.Parse(parametersDictionary["messages_unacknowledged_ram"].ToString());
            parameters.messages_persistent = Int32.Parse(parametersDictionary["messages_parameters"].ToString());
            parameters.message_bytes = Int32.Parse(parametersDictionary["message_bytes"].ToString());
            parameters.message_bytes_ready = Int32.Parse(parametersDictionary["message_bytes_ready"].ToString());
            parameters.message_bytes_unacknowledged =
                Int32.Parse(parametersDictionary["message_bytes_unacknowledged"].ToString());
            parameters.message_bytes_ram = Int32.Parse(parametersDictionary["message_bytes_ram"].ToString());
            parameters.message_bytes_persistent =
                Int32.Parse(parametersDictionary["message_bytes_persistent"].ToString());
            parameters.head_message_timestamp = parametersDictionary["head_message_timestamp"].ToString();
            parameters.disk_reads = Int32.Parse(parametersDictionary["disk_reads"].ToString());
            parameters.disk_writes = Int32.Parse(parametersDictionary["disk_writes"].ToString());
            parameters.backing_queue_status =
                queueBackingQueueSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["backing_queue_status"].ToString()));

            parameters.node = parametersDictionary["node"].ToString();
            parameters.arguments =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            parameters.exclusive = Boolean.Parse(parametersDictionary["exclusive"].ToString());
            parameters.auto_delete = Boolean.Parse(parametersDictionary["auto_delete"].ToString());
            parameters.durable = Boolean.Parse(parametersDictionary["durable"].ToString());
            parameters.vhost = parametersDictionary["vhost"].ToString();
            parameters.name = parametersDictionary["name"].ToString();

            return parameters;
        }


        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in QueueInfoKeys.keys)
            {
             if(!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
