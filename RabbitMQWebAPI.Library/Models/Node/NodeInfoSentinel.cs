using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.Node.NodeApplication;
using RabbitMQWebAPI.Library.Models.Node.NodeAuthMechanisms;
using RabbitMQWebAPI.Library.Models.Node.NodeClusterLink;
using RabbitMQWebAPI.Library.Models.Node.NodeContext;
using RabbitMQWebAPI.Library.Models.Node.NodeExchangeType;
using RabbitMQWebAPI.Library.Models.Sentinel;

namespace RabbitMQWebAPI.Library.Models.Node
{
    public class NodeInfoSentinel : Sentinel<NodeInfo, NodeInfoParameters>
    {
        public override NodeInfoParameters ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary)
        {
            NodeApplicationSentinel nodeApplicationSentinel = new NodeApplicationSentinel();
            NodeAuthMechanismsSentinel nodeAuthMechanismsSentinel = new NodeAuthMechanismsSentinel();
            NodeClusterLinkSentinel nodeClusterLinkSentinel = new NodeClusterLinkSentinel();
            NodeContextSentinel nodeContextSentinel = new NodeContextSentinel();
            NodeExchangeTypeSentinel nodeExchangeTypeSentinel = new NodeExchangeTypeSentinel();

            NodeInfoParameters parameters = new NodeInfoParameters();

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
                applicationsList.Add(nodeApplicationSentinel.CreateModel(app));
            }

            foreach (
                Dictionary<string, object> am in 
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    parametersDictionary["auth_mechanisms"].ToString()))
            {
                authMechanisms.Add(nodeAuthMechanismsSentinel.CreateModel(am));
            }

            foreach (
                Dictionary<string, object> cl in
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    parametersDictionary["cluster_links"].ToString()))
            {
                clusterLinks.Add(nodeClusterLinkSentinel.CreateModel(cl));
            }

            foreach (
                Dictionary<string, object> c in 
                JsonConvert.DeserializeObject<List<Dictionary<string,object>>>(
                    parametersDictionary["contexts"].ToString()))
            {
                contexts.Add(nodeContextSentinel.CreateModel(c));
            }

            foreach (
                Dictionary<string, object> et in 
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(
                    parametersDictionary["exchange_types"].ToString()))
            {
                exchangeTypes.Add(nodeExchangeTypeSentinel.CreateModel(et));
            }

            parameters.applications = applicationsList;
            parameters.auth_mechanisms = authMechanisms;
            parameters.cluster_links = clusterLinks;
            parameters.contexts = contexts;
            parameters.exchange_types = exchangeTypes;


            parameters.context_switches = Int32.Parse(parametersDictionary["context_switches"].ToString());
            parameters.context_switches_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["context_switches_details"].ToString());

            parameters.io_read_avg_time = Int32.Parse(parametersDictionary["io_read_avg_time"].ToString());
            parameters.log_file = parametersDictionary["log_file"].ToString();
            parameters.config_files =
                JsonConvert.DeserializeObject<List<string>>(parametersDictionary["config_files"].ToString());

            parameters.mem_used = Int32.Parse(parametersDictionary["mem_used"].ToString());
            parameters.mem_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["mem_used_details"].ToString());

            parameters.fd_used = Int32.Parse(parametersDictionary["fd_used"].ToString());
            parameters.fd_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["fd_used_details"].ToString());

            parameters.sockets_used = Int32.Parse(parametersDictionary["sockets_used"].ToString());
            parameters.sockets_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["sockets_used_details"].ToString());

            parameters.proc_used = Int32.Parse(parametersDictionary["proc_used"].ToString());
            parameters.proc_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["proc_used_details"].ToString());

            parameters.disk_free = Int32.Parse(parametersDictionary["disk_free"].ToString());
            parameters.proc_used_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["proc_used_details"].ToString());

            parameters.io_read_count = Int32.Parse(parametersDictionary["io_read_count"].ToString());
            parameters.io_read_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_read_count_details"].ToString());

            parameters.io_read_bytes = Int32.Parse(parametersDictionary["io_read_byte"].ToString());
            parameters.io_read_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_read_count_details"].ToString());

            parameters.io_read_avg_time = Int32.Parse(parametersDictionary["io_read_avg_time"].ToString());
            parameters.io_read_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_read_avg_time_details"].ToString());

            parameters.io_write_count = Int32.Parse(parametersDictionary["io_write_count"].ToString());
            parameters.io_write_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_write_count_details"].ToString());

            parameters.io_write_bytes = Int32.Parse(parametersDictionary["io_write_bytes"].ToString());
            parameters.io_write_bytes_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_write_bytes_details"].ToString());

            parameters.io_write_avg_time = Int32.Parse(parametersDictionary["io_write_avg_time"].ToString());
            parameters.io_write_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_write_avg_time"].ToString());

            parameters.io_sync_count = Int32.Parse(parametersDictionary["io_sync_count"].ToString());
            parameters.io_sync_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_sync_count"].ToString());

            parameters.io_sync_avg_time = Int32.Parse(parametersDictionary["io_sync_avg_time"].ToString());
            parameters.io_sync_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_sync_avg_time_details"].ToString());

            parameters.io_seek_count = Int32.Parse(parametersDictionary["io_seek_count"].ToString());
            parameters.io_seek_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_seek_count_details"].ToString());

            parameters.io_reopen_count = Int32.Parse(parametersDictionary["io_reopen_count"].ToString());
            parameters.io_reopen_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_reopen_count_details"].ToString());

            parameters.mnesia_ram_tx_count = Int32.Parse(parametersDictionary["mnesia_ram_tx_count"].ToString());
            parameters.mnesia_ram_tx_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["mnesia_ram_tx_count_details"].ToString());

            parameters.mnesia_disk_tx_count = Int32.Parse(parametersDictionary["mnesia_disk_tx_count"].ToString());
            parameters.mnesia_ram_tx_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["mnesia_ram_tx_count_details"].ToString());

            parameters.msg_store_read_count = Int32.Parse(parametersDictionary["msg_store_read_count"].ToString());
            parameters.msg_store_read_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["msg_store_read_count_details"].ToString());

            parameters.msg_store_write_count = Int32.Parse(parametersDictionary["msg_store_write_count"].ToString());
            parameters.msg_store_write_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["msg_store_write_count_details"].ToString());

            parameters.queue_index_journal_write_count =
                Int32.Parse(parametersDictionary["queue_index_journal_write_count"].ToString());
            parameters.queue_index_journal_write_count_details = 
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["queue_index_journal_write_count_details"].ToString());

            parameters.queue_index_write_count = Int32.Parse(parametersDictionary["queue_index_write_count"].ToString());
            parameters.queue_index_write_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["queue_index_write_count_details"].ToString());

            parameters.queue_index_read_count = Int32.Parse(parametersDictionary["queue_index_read_count"].ToString());
            parameters.queue_index_read_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["queue_index_read_count_deta"].ToString());

            parameters.gc_num = Int32.Parse(parametersDictionary["gc_enum"].ToString());
            parameters.gc_num_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["gc_enum_details"].ToString());

            parameters.gc_bytes_reclaimed = Int32.Parse(parametersDictionary["gc_bytes_reclaimed"].ToString());
            parameters.gc_bytes_reclaimed_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["gc_bytes_reclaimed_details"].ToString());

            parameters.context_switches = Int32.Parse(parametersDictionary["context_switches"].ToString());
            parameters.context_switches_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["context_switches_details"].ToString());

            parameters.io_file_handle_open_attempt_count =
                Int32.Parse(parametersDictionary["io_file_handle_open_attempt_count"].ToString());
            parameters.io_file_handle_open_attempt_count_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_file_handle_open_attempt_count_details"].ToString());

            parameters.io_file_handle_open_attempt_avg_time =
                Int32.Parse(parametersDictionary["io_file_handle_open_attempt_avg_time"].ToString());
            parameters.io_file_handle_open_attempt_avg_time_details =
                JsonConvert.DeserializeObject<Dictionary<string, int>>(
                    parametersDictionary["io_file_handle_open_attempt_avg_time_details"].ToString());


            parameters.partitions =JsonConvert.DeserializeObject<List<string>>(parametersDictionary["partitions"].ToString());
            parameters.os_pid = parametersDictionary["os_pid"].ToString();
            parameters.fd_total = Int32.Parse(parametersDictionary["fd_total"].ToString());
            parameters.sockets_total = Int32.Parse(parametersDictionary["sockets_total"].ToString());
            parameters.mem_limit = Int32.Parse(parametersDictionary["mem_limit"].ToString());
            parameters.mem_alarm = Boolean.Parse(parametersDictionary["mem_alarm"].ToString());
            parameters.disk_free_limit = Int32.Parse(parametersDictionary["disk_free_limit"].ToString());
            parameters.disk_free_alarm = Boolean.Parse(parametersDictionary["disk_free_alarm"].ToString());
            parameters.proc_total = Int32.Parse(parametersDictionary["proc_total"].ToString());
            parameters.rates_mode = parametersDictionary["rates_mode"].ToString();
            parameters.uptime = Int32.Parse(parametersDictionary["uptime"].ToString());
            parameters.run_queue = Int32.Parse(parametersDictionary["run_queue"].ToString());
            parameters.processors = Int32.Parse(parametersDictionary["processors"].ToString());

            parameters.log_file = parametersDictionary["log_file"].ToString();
            parameters.sasl_log_file = parametersDictionary["sasl_log_file"].ToString();
            parameters.db_dir = parametersDictionary["db_dir"].ToString();
            parameters.config_files =
                JsonConvert.DeserializeObject<List<string>>(parametersDictionary["config_files"].ToString());
            parameters.net_ticktime = Int32.Parse(parametersDictionary["net_ticktime"].ToString());
            parameters.enabled_plugins =
                JsonConvert.DeserializeObject<List<string>>(parametersDictionary["enabled_plugins"].ToString());
            parameters.name = parametersDictionary["name"].ToString();
            parameters.type = parametersDictionary["type"].ToString();
            parameters.running = Boolean.Parse(parametersDictionary["running"].ToString());


            return parameters;
        }

        public override Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary)
        {
            foreach (string key in NodeInfoKeys.keys)
            {
                if (!parametersDictionary.ContainsKey(key))
                    throw new DictionaryMissingArgumentException(key);
            }

            return true;
        }
    }
}
