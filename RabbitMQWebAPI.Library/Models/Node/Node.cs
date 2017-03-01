using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQWebAPI.Library.Models.BaseModel;

namespace RabbitMQWebAPI.Library.Models.Node
{
    public class Node: Model
    {
        [JsonProperty(PropertyName = "cluster_links")]
        public List<NodeClusterLink.NodeClusterLink> cluster_links { get; internal set; }

        [JsonProperty(PropertyName = "mem_used")]
        public double mem_used { get; internal set; }

        [JsonProperty(PropertyName = "mem_used_details")]
        public Dictionary<string, double> mem_used_details { get; internal set; }

        [JsonProperty(PropertyName = "fd_used")]
        public double fd_used { get; internal set; }

        [JsonProperty(PropertyName = "fd_used_details")]
        public Dictionary<string, double> fd_used_details { get; internal set; }

        [JsonProperty(PropertyName = "sockets_used")]
        public double sockets_used { get; internal set; }

        [JsonProperty(PropertyName = "sockets_used_details")]
        public Dictionary<string, double> sockets_used_details { get; internal set; }

        [JsonProperty(PropertyName = "proc_used")]
        public double proc_used { get; internal set; }

        [JsonProperty(PropertyName = "proc_used_details")]
        public Dictionary<string, double> proc_used_details { get; internal set; }

        [JsonProperty(PropertyName = "disk_free")]
        public double disk_free { get; internal set; }

        [JsonProperty(PropertyName = "disk_free_details")]
        public Dictionary<string, double> disk_free_details { get; internal set; }

        [JsonProperty(PropertyName = "io_read_count")]
        public double io_read_count { get; internal set; }

        [JsonProperty(PropertyName = "io_read_count_details")]
        public Dictionary<string, double> io_read_count_details { get; internal set; }

        [JsonProperty(PropertyName = "io_read_bytes")]
        public double io_read_bytes { get; internal set; }

        [JsonProperty(PropertyName = "io_read_bytes_details")]
        public Dictionary<string, double> io_read_bytes_details { get; internal set; }

        [JsonProperty(PropertyName = "io_read_avg_time")]
        public double io_read_avg_time { get; internal set; }

        [JsonProperty(PropertyName = "io_read_avg_time_details")]
        public Dictionary<string, double> io_read_avg_time_details { get; internal set; }

        [JsonProperty(PropertyName = "io_write_count")]
        public double io_write_count { get; internal set; }

        [JsonProperty(PropertyName = "io_write_count_details")]
        public Dictionary<string, double> io_write_count_details { get; internal set; }

        [JsonProperty(PropertyName = "io_write_bytes")]
        public double io_write_bytes { get; internal set; }

        [JsonProperty(PropertyName = "io_write_bytes_details")]
        public Dictionary<string, double> io_write_bytes_details { get; internal set; }

        [JsonProperty(PropertyName = "io_write_avg_time")]
        public double io_write_avg_time { get; internal set; }

        [JsonProperty(PropertyName = "io_write_avg_time_details")]
        public Dictionary<string, double> io_write_avg_time_details { get; internal set; }

        [JsonProperty(PropertyName = "io_sync_count")]
        public double io_sync_count { get; internal set; }

        [JsonProperty(PropertyName = "io_sync_details")]
        public Dictionary<string, double> io_sync_count_details { get; internal set; }

        [JsonProperty(PropertyName = "io_sync_avg_time")]
        public double io_sync_avg_time { get; internal set; }

        [JsonProperty(PropertyName = "io_sync_avg_time_details")]
        public Dictionary<string, double> io_sync_avg_time_details { get; internal set; }

        [JsonProperty(PropertyName = "io_seek_count")]
        public double io_seek_count { get; internal set; }

        [JsonProperty(PropertyName = "io_seek_count_details")]
        public Dictionary<string, double> io_seek_count_details { get; internal set; }

        [JsonProperty(PropertyName = "io_seek_avg_time")]
        public double io_seek_avg_time { get; internal set; }

        [JsonProperty(PropertyName = "io_seek_avg_time_details")]
        public Dictionary<string, double> io_seek_avg_time_details { get; internal set; }

        [JsonProperty(PropertyName = "io_reopen_count")]
        public double io_reopen_count { get; internal set; }

        [JsonProperty(PropertyName = "io_reopen_count_details")]
        public Dictionary<string, double> io_reopen_count_details { get; internal set; }

        [JsonProperty(PropertyName = "mnesia_ram_tx_count")]
        public double mnesia_ram_tx_count { get; internal set; }

        [JsonProperty(PropertyName = "mnesia_ram_tx_count_details")]
        public Dictionary<string, double> mnesia_ram_tx_count_details { get; internal set; }

        [JsonProperty(PropertyName = "mnesia_disk_tx_count")]
        public double mnesia_disk_tx_count { get; internal set; }

        [JsonProperty(PropertyName = "mnesia_disk_tx_count_details")]
        public Dictionary<string, double> mnesia_disk_tx_count_details { get; internal set; }

        [JsonProperty(PropertyName = "msg_store_read_count")]
        public double msg_store_read_count { get; internal set; }

        [JsonProperty(PropertyName = "msg_store_read_count_details")]
        public Dictionary<string, double> msg_store_read_count_details { get; internal set; }

        [JsonProperty(PropertyName = "msg_store_write_count")]
        public double msg_store_write_count { get; internal set; }

        [JsonProperty(PropertyName = "msg_store_write_count_details")]
        public Dictionary<string, double> msg_store_write_count_details { get; internal set; }

        [JsonProperty(PropertyName = "queue_index_journal_write_count")]
        public double queue_index_journal_write_count { get; internal set; }

        [JsonProperty(PropertyName = "queue_index_journal_write_count_details")]
        public Dictionary<string, double> queue_index_journal_write_count_details { get; internal set; }

        [JsonProperty(PropertyName = "queue_index_write_count")]
        public double queue_index_write_count { get; internal set; }

        [JsonProperty(PropertyName = "queue_index_write_count_details")]
        public Dictionary<string, double> queue_index_write_count_details { get; internal set; }

        [JsonProperty(PropertyName = "queue_index_read_count")]
        public double queue_index_read_count { get; internal set; }

        [JsonProperty(PropertyName = "queue_index_read_count_details")]
        public Dictionary<string, double> queue_index_read_count_details { get; internal set; }

        [JsonProperty(PropertyName = "gc_num")]
        public double gc_num { get; internal set; }

        [JsonProperty(PropertyName = "gc_enum_details")]
        public Dictionary<string, double> gc_num_details { get; internal set; }


        [JsonProperty(PropertyName = "gc_bytes_reclaimed")]
        public double gc_bytes_reclaimed { get; internal set; }

        [JsonProperty(PropertyName = "gc_bytes_reclaimed_details")]
        public Dictionary<string, double> gc_bytes_reclaimed_details { get; internal set; }

        [JsonProperty(PropertyName = "context_switches")]
        public double context_switches { get; internal set; }

        [JsonProperty(PropertyName = "context_switches_details")]
        public Dictionary<string, double> context_switches_details { get; internal set; }

        [JsonProperty(PropertyName = "io_file_handle_open_attempt_count")]
        public double io_file_handle_open_attempt_count { get; internal set; }

        [JsonProperty(PropertyName = "io_file_handle_open_attempt_count_details")]
        public Dictionary<string, double> io_file_handle_open_attempt_count_details { get; internal set; }

        [JsonProperty(PropertyName = "io_file_handle_open_attempt_avg_time")]
        public double io_file_handle_open_attempt_avg_time { get; internal set; }

        [JsonProperty(PropertyName = "io_file_Handle_open_attempt_avg_time_details")]
        public Dictionary<string, double> io_file_handle_open_attempt_avg_time_details { get; internal set; }

        [JsonProperty(PropertyName = "partitions")]
        public List<string> partitions { get; internal set; }

        [JsonProperty(PropertyName = "os_pid")]
        public string os_pid { get; internal set; }

        [JsonProperty(PropertyName = "fd_total")]
        public double fd_total { get; internal set; }

        [JsonProperty(PropertyName = "sockets_total")]
        public double sockets_total { get; internal set; }

        [JsonProperty(PropertyName = "mem_limit")]
        public double mem_limit { get; internal set; }

        [JsonProperty(PropertyName = "mem_alarm")]
        public bool mem_alarm { get; internal set; }

        [JsonProperty(PropertyName = "disk_free_limit")]
        public double disk_free_limit { get; internal set; }

        [JsonProperty(PropertyName = "disk_free_alarm")]
        public bool disk_free_alarm { get; internal set; }

        [JsonProperty(PropertyName = "proc_total")]
        public double proc_total { get; internal set; }

        [JsonProperty(PropertyName = "rates_mode")]
        public string rates_mode { get; internal set; }

        [JsonProperty(PropertyName = "uptime")]
        public double uptime { get; internal set; }

        [JsonProperty(PropertyName = "run_queue")]
        public double run_queue { get; internal set; }

        [JsonProperty(PropertyName = "processors")]
        public double processors { get; internal set; }


        [JsonProperty(PropertyName = "exchange_types")]
        public List<NodeExchangeType.NodeExchangeType> exchange_types { get; internal set; }

        [JsonProperty(PropertyName = "auth_mechanisms")]
        public List<NodeAuthMechanisms.NodeAuthMechanisms> auth_mechanisms { get; internal set; }

        [JsonProperty(PropertyName = "applications")]
        public List<NodeApplication.NodeApplication> applications { get; internal set; }

        [JsonProperty(PropertyName = "contexts")]
        public List<NodeContext.NodeContext> contexts { get; internal set; }

        public string log_file { get; internal set; }
        public string sasl_log_file { get; internal set; }
        public string db_dir { get; internal set; }
        public List<string> config_files { get; internal set; }
        public int net_ticktime { get; internal set; }
        public List<string> enabled_plugins { get; internal set; }
        public string name { get; internal set; }
        public string type { get; internal set; }
        public bool running { get; internal set; }

        public override HashSet<String> Keys
        {
            get
            {
                return new HashSet<string>()
        {
            "cluster_links",
            "mem_used",
            "mem_used_details",
            "fd_used",
            "fd_used_details",
            "sockets_used",
            "sockets_used_details",
            "proc_used",
            "proc_used_details",
            "disk_free",
            "disk_free_details",
            "io_read_bytes",
            "io_read_bytes_details",
            "io_read_avg_time",
            "io_read_avg_time_details",
            "io_write_count",
            "io_write_count_details",
            "io_write_bytes",
            "io_write_bytes_details",
            "io_write_avg_time",
            "io_write_avg_time_details",
            "io_sync_count",
            "io_sync_count_details",
            "io_sync_avg_time",
            "io_sync_avg_time_details",
            "io_seek_count",
            "io_seek_count_details",
            "io_seek_avg_time",
            "io_seek_avg_time_details",
            "io_reopen_count",
            "io_reopen_count_details",
            "mnesia_ram_tx_count",
            "mnesia_ram_tx_count_details",
            "mnesia_disk_tx_count",
            "mnesia_disk_tx_count_details",
            "msg_store_read_count",
            "msg_store_read_count_details",
            "msg_store_write_count",
            "msg_store_write_count_details",
            "queue_index_journal_write_count",
            "queue_index_journal_write_count_details",
            "queue_index_write_count",
            "queue_index_write_count_details",
            "queue_index_read_count",
            "queue_index_read_count_details",
            "gc_num",
            "gc_num_details",
            "gc_bytes_reclaimed",
            "gc_bytes_reclaimed_details",
            "context_switches",
            "context_switches_details",
            "io_file_handle_open_attempt_count",
            "io_file_handle_open_attempt_count_details",
            "io_file_handle_open_attempt_avg_time",
            "io_file_handle_open_attempt_avg_time_details",
            "partitions",
            "os_pid",
            "fd_total",
            "sockets_total",
            "mem_limit",
            "mem_alarm",
            "disk_free_limit",
            "disk_free_alarm",
            "proc_total",
            "rates_mode",
            "uptime",
            "run_queue",
            "processors",
            "exchange_types",
            "auth_mechanisms",
            "applications",
            "contexts",
            "log_file",
            "sasl_log_file",
            "db_dir",
            "config_files",
            "net_ticktime",
            "enabled_plugins",
            "name",
            "type",
            "running"
        };
            }

            set { Keys = value; }
        }

        public Node()
        {
        }
    }
}
