using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;
using RabbitMQWebAPI.Library.Models.Node.NodeApplication;
using RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms;
using RabbitMQWebAPI.Library.Models.Node.NodeClusterLink;
using RabbitMQWebAPI.Library.Models.Node.NodeContext;
using RabbitMQWebAPI.Library.Models.Node.NodeExchangeType;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node
{
    public class NodeSentinel : Sentinel<Node>
    {
        public override IModel ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeApplicationSentinel nodeApplicationSentinel = new NodeApplicationSentinel();
            NodeAuthMechanismsSentinel nodeAuthMechanismsSentinel = new NodeAuthMechanismsSentinel();
            NodeClusterLinkSentinel nodeClusterLinkSentinel = new NodeClusterLinkSentinel();
            NodeContextSentinel nodeContextSentinel = new NodeContextSentinel();
            NodeExchangeTypeSentinel nodeExchangeTypeSentinel = new NodeExchangeTypeSentinel();

            Node model = new Node();

            List<NodeApplication.NodeApplication> applicationsList = new List<NodeApplication.NodeApplication>();
            List<NodeAuthMechanisms.NodeAuthMechanisms> authMechanisms = new List<NodeAuthMechanisms.NodeAuthMechanisms>();
            List<NodeClusterLink.NodeClusterLink> clusterLinks = new List<NodeClusterLink.NodeClusterLink>();
            List<NodeContext.NodeContext> contexts = new List<NodeContext.NodeContext>();
            List<NodeExchangeType.NodeExchangeType> exchangeTypes = new List<NodeExchangeType.NodeExchangeType>();

            foreach (
                Dictionary<string, object> app in 
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    parametersDictionary["applications"].ToString()))
            {
                applicationsList.Add((NodeApplication.NodeApplication)nodeApplicationSentinel.CreateModel(app, new NodeApplication.NodeApplication()));
            }

            foreach (
                Dictionary<string, object> am in 
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    parametersDictionary["auth_mechanisms"].ToString()))
            {
                authMechanisms.Add((NodeAuthMechanisms.NodeAuthMechanisms)nodeAuthMechanismsSentinel.CreateModel(am, new NodeAuthMechanisms.NodeAuthMechanisms()));
            }

            foreach (
                Dictionary<string, object> cl in
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    parametersDictionary["cluster_links"].ToString()))
            {
                clusterLinks.Add((NodeClusterLink.NodeClusterLink)nodeClusterLinkSentinel.CreateModel(cl, new NodeClusterLink.NodeClusterLink()));
            }

            foreach (
                Dictionary<string, object> c in 
                JsonConvert.DeserializeObject<List<Dictionary<string,object>>>(
                    parametersDictionary["contexts"].ToString()))
            {
                contexts.Add((NodeContext.NodeContext)nodeContextSentinel.CreateModel(c, new NodeContext.NodeContext()));
            }

            foreach (
                Dictionary<string, object> et in 
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    parametersDictionary["exchange_types"].ToString()))
            {
                exchangeTypes.Add((NodeExchangeType.NodeExchangeType)nodeExchangeTypeSentinel.CreateModel(et, new NodeExchangeType.NodeExchangeType()));
            }

            model.applications = applicationsList;
            model.auth_mechanisms = authMechanisms;
            model.cluster_links = clusterLinks;
            model.contexts = contexts;
            model.exchange_types = exchangeTypes;


            model.context_switches = double.Parse(parametersDictionary["context_switches"].ToString());
            model.context_switches_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["context_switches_details"].ToString());

            model.io_read_avg_time = double.Parse(parametersDictionary["io_read_avg_time"].ToString());
            model.log_file = parametersDictionary["log_file"].ToString();
            model.config_files =
                JsonConvert.DeserializeObject<List<string>>(parametersDictionary["config_files"].ToString());

            model.mem_used = double.Parse(parametersDictionary["mem_used"].ToString());
            model.mem_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["mem_used_details"].ToString());

            model.fd_used = double.Parse(parametersDictionary["fd_used"].ToString());
            model.fd_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["fd_used_details"].ToString());

            model.sockets_used = double.Parse(parametersDictionary["sockets_used"].ToString());
            model.sockets_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["sockets_used_details"].ToString());

            model.proc_used = double.Parse(parametersDictionary["proc_used"].ToString());
            model.proc_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["proc_used_details"].ToString());

            model.disk_free = double.Parse(parametersDictionary["disk_free"].ToString());
            model.proc_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["proc_used_details"].ToString());

            model.io_read_count = double.Parse(parametersDictionary["io_read_count"].ToString());
            model.io_read_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_read_count_details"].ToString());

            model.io_read_bytes = double.Parse(parametersDictionary["io_read_byte"].ToString());
            model.io_read_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_read_count_details"].ToString());

            model.io_read_avg_time = double.Parse(parametersDictionary["io_read_avg_time"].ToString());
            model.io_read_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_read_avg_time_details"].ToString());

            model.io_write_count = double.Parse(parametersDictionary["io_write_count"].ToString());
            model.io_write_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_write_count_details"].ToString());

            model.io_write_bytes = double.Parse(parametersDictionary["io_write_bytes"].ToString());
            model.io_write_bytes_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_write_bytes_details"].ToString());

            model.io_write_avg_time = double.Parse(parametersDictionary["io_write_avg_time"].ToString());
            model.io_write_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_write_avg_time"].ToString());

            model.io_sync_count = double.Parse(parametersDictionary["io_sync_count"].ToString());
            model.io_sync_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_sync_count"].ToString());

            model.io_sync_avg_time = double.Parse(parametersDictionary["io_sync_avg_time"].ToString());
            model.io_sync_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_sync_avg_time_details"].ToString());

            model.io_seek_count = double.Parse(parametersDictionary["io_seek_count"].ToString());
            model.io_seek_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_seek_count_details"].ToString());

            model.io_reopen_count = double.Parse(parametersDictionary["io_reopen_count"].ToString());
            model.io_reopen_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_reopen_count_details"].ToString());

            model.mnesia_ram_tx_count = double.Parse(parametersDictionary["mnesia_ram_tx_count"].ToString());
            model.mnesia_ram_tx_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["mnesia_ram_tx_count_details"].ToString());

            model.mnesia_disk_tx_count = double.Parse(parametersDictionary["mnesia_disk_tx_count"].ToString());
            model.mnesia_ram_tx_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["mnesia_ram_tx_count_details"].ToString());

            model.msg_store_read_count = double.Parse(parametersDictionary["msg_store_read_count"].ToString());
            model.msg_store_read_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["msg_store_read_count_details"].ToString());

            model.msg_store_write_count = double.Parse(parametersDictionary["msg_store_write_count"].ToString());
            model.msg_store_write_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["msg_store_write_count_details"].ToString());

            model.queue_index_journal_write_count =
                double.Parse(parametersDictionary["queue_index_journal_write_count"].ToString());
            model.queue_index_journal_write_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["queue_index_journal_write_count_details"].ToString());

            model.queue_index_write_count = double.Parse(parametersDictionary["queue_index_write_count"].ToString());
            model.queue_index_write_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["queue_index_write_count_details"].ToString());

            model.queue_index_read_count = double.Parse(parametersDictionary["queue_index_read_count"].ToString());
            model.queue_index_read_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["queue_index_read_count_deta"].ToString());

            model.gc_num = double.Parse(parametersDictionary["gc_enum"].ToString());
            model.gc_num_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["gc_enum_details"].ToString());

            model.gc_bytes_reclaimed = double.Parse(parametersDictionary["gc_bytes_reclaimed"].ToString());
            model.gc_bytes_reclaimed_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["gc_bytes_reclaimed_details"].ToString());

            model.context_switches = double.Parse(parametersDictionary["context_switches"].ToString());
            model.context_switches_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["context_switches_details"].ToString());

            model.io_file_handle_open_attempt_count =
                double.Parse(parametersDictionary["io_file_handle_open_attempt_count"].ToString());
            model.io_file_handle_open_attempt_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_file_handle_open_attempt_count_details"].ToString());

            model.io_file_handle_open_attempt_avg_time =
                double.Parse(parametersDictionary["io_file_handle_open_attempt_avg_time"].ToString());
            model.io_file_handle_open_attempt_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, double>>(
                    parametersDictionary["io_file_handle_open_attempt_avg_time_details"].ToString());


            model.partitions =JsonConvert.DeserializeObject<List<string>>(parametersDictionary["partitions"].ToString());
            model.os_pid = parametersDictionary["os_pid"].ToString();
            model.fd_total = double.Parse(parametersDictionary["fd_total"].ToString());
            model.sockets_total = double.Parse(parametersDictionary["sockets_total"].ToString());
            model.mem_limit = double.Parse(parametersDictionary["mem_limit"].ToString());
            model.mem_alarm = Boolean.Parse(parametersDictionary["mem_alarm"].ToString());
            model.disk_free_limit = double.Parse(parametersDictionary["disk_free_limit"].ToString());
            model.disk_free_alarm = Boolean.Parse(parametersDictionary["disk_free_alarm"].ToString());
            model.proc_total = double.Parse(parametersDictionary["proc_total"].ToString());
            model.rates_mode = parametersDictionary["rates_mode"].ToString();
            model.uptime = double.Parse(parametersDictionary["uptime"].ToString());
            model.run_queue = double.Parse(parametersDictionary["run_queue"].ToString());
            model.processors = double.Parse(parametersDictionary["processors"].ToString());

            model.log_file = parametersDictionary["log_file"].ToString();
            model.sasl_log_file = parametersDictionary["sasl_log_file"].ToString();
            model.db_dir = parametersDictionary["db_dir"].ToString();
            model.config_files =
                JsonConvert.DeserializeObject<List<string>>(parametersDictionary["config_files"].ToString());
            model.net_ticktime = Int32.Parse(parametersDictionary["net_ticktime"].ToString());
            model.enabled_plugins =
                JsonConvert.DeserializeObject<List<string>>(parametersDictionary["enabled_plugins"].ToString());
            model.name = parametersDictionary["name"].ToString();
            model.type = parametersDictionary["type"].ToString();
            model.running = Boolean.Parse(parametersDictionary["running"].ToString());


            return model;
        }
    }
}
