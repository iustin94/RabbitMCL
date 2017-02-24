using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.DataAccess;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Binding;
using RabbitMQWebAPI.Library.Models.Queue.QueueBackingQueue;
using RabbitMQWebAPI.Library.Models.Queue.QueueGarbageCollection;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Queue
{
    public class QueueInfoSentinel : Sentinel<QueueInfo>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<string, object> parametersDictionary, IModel model)
        {
            QueueInfo parameters = new QueueInfo();
           

            QueueBackingQueueSentinel queueBackingQueueSentinel = new QueueBackingQueueSentinel();
            QueueGarbageCollectionSentinel queueBackingQueueGarbageCollectionSentinel = new QueueGarbageCollectionSentinel();

            parameters.memory = long.Parse(parametersDictionary["memory"].ToString());

            parameters.reductions = long.Parse(parametersDictionary["reductions"].ToString());
            parameters.reductions_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["reductions_details"].ToString());

            parameters.messages = long.Parse(parametersDictionary["messages"].ToString());
            parameters.messages_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["messages_details"].ToString());

            parameters.messages_ready = long.Parse(parametersDictionary["messages_ready"].ToString());
            parameters.messages_ready_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["messages_ready_details"].ToString());


            parameters.messages_unacknowledged = long.Parse(parametersDictionary["messages_unacknowledged"].ToString());
            parameters.messages_unacknowledged_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["messages_unacknowledged_details"].ToString());

            parameters.idle_since = parametersDictionary["idle_since"]?.ToString() ?? string.Empty;
            parameters.consumer_utilisation = parametersDictionary["consumer_utilisation"]?.ToString() ?? string.Empty;
            parameters.policy = parametersDictionary["policy"]?.ToString() ?? string.Empty;
            parameters.exclusive_consumer_tag = parametersDictionary["exclusive_consumer_tag"]?.ToString() ?? string.Empty;
            parameters.consumers = long.Parse(parametersDictionary["consumers"].ToString());
            parameters.recoverable_slaves = parametersDictionary["recoverable_slaves"]?.ToString() ?? string.Empty;
            parameters.state = State.EvaluateState(parametersDictionary["state"].ToString());

            parameters.garbage_collection =
                (QueueGarbageCollection.QueueGarbageCollection)queueBackingQueueGarbageCollectionSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["garbage_collection"].ToString()), new QueueGarbageCollection.QueueGarbageCollection());

            parameters.messages_ram = long.Parse(parametersDictionary["messages_ram"].ToString());
            parameters.messages_ready_ram = long.Parse(parametersDictionary["messages_ready_ram"].ToString());
            parameters.messages_unacknowledged_ram =
                long.Parse(parametersDictionary["messages_unacknowledged_ram"].ToString());
            parameters.messages_persistent = long.Parse(parametersDictionary["messages_persistent"].ToString());
            parameters.message_bytes = long.Parse(parametersDictionary["message_bytes"].ToString());
            parameters.message_bytes_ready = long.Parse(parametersDictionary["message_bytes_ready"].ToString());
            parameters.message_bytes_unacknowledged =
                long.Parse(parametersDictionary["message_bytes_unacknowledged"].ToString());
            parameters.message_bytes_ram = long.Parse(parametersDictionary["message_bytes_ram"].ToString());
            parameters.message_bytes_persistent =
                long.Parse(parametersDictionary["message_bytes_persistent"].ToString());
            parameters.head_message_timestamp = parametersDictionary["head_message_timestamp"]?.ToString() ?? string.Empty;
            parameters.disk_reads = long.Parse(parametersDictionary["disk_reads"].ToString());
            parameters.disk_writes = long.Parse(parametersDictionary["disk_writes"].ToString());
            parameters.backing_queue_status =
               (QueueBackingQueueStatus)queueBackingQueueSentinel.CreateModel(
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        parametersDictionary["backing_queue_status"].ToString()), new QueueBackingQueueStatus());

            parameters.node = parametersDictionary["node"]?.ToString() ?? string.Empty;
            parameters.arguments =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersDictionary["arguments"].ToString());
            parameters.exclusive = bool.Parse(parametersDictionary["exclusive"].ToString());
            parameters.auto_delete = bool.Parse(parametersDictionary["auto_delete"].ToString());
            parameters.durable = bool.Parse(parametersDictionary["durable"].ToString());
            parameters.vhost = parametersDictionary["vhost"]?.ToString() ?? string.Empty;
            parameters.name = parametersDictionary["name"]?.ToString() ?? string.Empty;

            return parameters;
        }

      
    }
}
