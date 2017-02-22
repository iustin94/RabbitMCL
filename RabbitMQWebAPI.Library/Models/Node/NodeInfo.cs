using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RabbitMQWebAPI.Library.Models.Node
{
    public class NodeInfo
    {
        [JsonProperty(PropertyName = "cluster_links")]
        public List<NodeClusterLink.NodeClusterLink> cluster_links { get; private set; }

        [JsonProperty(PropertyName = "mem_used")]
        public int mem_used { get; private set; }

        [JsonProperty(PropertyName = "mem_used_details")]
        public Dictionary<string, int> mem_used_details { get; private set; }

        [JsonProperty(PropertyName = "fd_used")]
        public int fd_used { get; private set; }

        [JsonProperty(PropertyName = "fd_used_details")]
        public Dictionary<string, int> fd_used_details { get; private set; }

        [JsonProperty(PropertyName = "sockets_used")]
        public int sockets_used { get; private set; }

        [JsonProperty(PropertyName = "sockets_used_details")]
        public Dictionary<string, int> sockets_used_details { get; private set; }

        [JsonProperty(PropertyName = "proc_used")]
        public int proc_used { get; private set; }

        [JsonProperty(PropertyName = "proc_used_details")]
        public Dictionary<string, int> proc_used_details { get; private set; }

        [JsonProperty(PropertyName = "disk_free")]
        public int disk_free { get; private set; }

        [JsonProperty(PropertyName = "disk_free_details")]
        public Dictionary<string, int> disk_free_details { get; private set; }

        [JsonProperty(PropertyName = "io_read_count")]
        public int io_read_count { get; private set; }

        [JsonProperty(PropertyName = "io_read_count_details")]
        public Dictionary<string, int> io_read_count_details { get; private set; }

        [JsonProperty(PropertyName = "io_read_bytes")]
        public int io_read_bytes { get; private set; }

        [JsonProperty(PropertyName = "io_read_bytes_details")]
        public Dictionary<string, int> io_read_bytes_details { get; private set; }

        [JsonProperty(PropertyName = "io_read_avg_time")]
        public int io_read_avg_time { get; private set; }

        [JsonProperty(PropertyName = "io_read_avg_time_details")]
        public Dictionary<string, int> io_read_avg_time_details { get; private set; }

        [JsonProperty(PropertyName = "io_write_count")]
        public int io_write_count { get; private set; }

        [JsonProperty(PropertyName = "io_write_count_details")]
        public Dictionary<string, int> io_write_count_details { get; private set; }

        [JsonProperty(PropertyName = "io_write_bytes")]
        public int io_write_bytes { get; private set; }

        [JsonProperty(PropertyName = "io_write_bytes_details")]
        public Dictionary<string, int> io_write_bytes_details { get; private set; }

        [JsonProperty(PropertyName = "io_write_avg_time")]
        public int io_write_avg_time { get; private set; }

        [JsonProperty(PropertyName = "io_write_avg_time_details")]
        public Dictionary<string, int> io_write_avg_time_details { get; private set; }

        [JsonProperty(PropertyName = "io_sync_count")]
        public int io_sync_count { get; private set; }

        [JsonProperty(PropertyName = "io_sync_details")]
        public Dictionary<string, int> io_sync_count_details { get; private set; }

        [JsonProperty(PropertyName = "io_sync_avg_time")]
        public int io_sync_avg_time { get; private set; }

        [JsonProperty(PropertyName = "io_sync_avg_time_details")]
        public Dictionary<string, int> io_sync_avg_time_details { get; private set; }

        [JsonProperty(PropertyName = "io_seek_count")]
        public int io_seek_count { get; private set; }
        
        [JsonProperty(PropertyName = "io_seek_count_details")]
        public Dictionary<string, int> io_seek_count_details { get; private set; }

        [JsonProperty(PropertyName = "io_seek_avg_time")]
        public int io_seek_avg_time { get; private set; }
        
        [JsonProperty(PropertyName = "io_seek_avg_time_details")]
        public Dictionary<string, int> io_seek_avg_time_details { get; private set; }

        [JsonProperty(PropertyName = "io_reopen_count")]
        public int io_reopen_count { get; private set; }

        [JsonProperty(PropertyName = "io_reopen_count_details")]
        public Dictionary<string, int> io_reopen_count_details { get; private set; }

        [JsonProperty(PropertyName = "mnesia_ram_tx_count")]
        public int mnesia_ram_tx_count { get; private set; }

        [JsonProperty(PropertyName = "mnesia_ram_tx_count_details")]
        public Dictionary<string, int> mnesia_ram_tx_count_details { get; private set; }

        [JsonProperty(PropertyName = "mnesia_disk_tx_count")]
        public int mnesia_disk_tx_count { get; private set; }

        [JsonProperty(PropertyName = "mnesia_disk_tx_count_details")]
        public Dictionary<string, int> mnesia_disk_tx_count_details { get; private set; }

        [JsonProperty(PropertyName = "msg_store_read_count")]
        public int msg_store_read_count { get; private set; }

        [JsonProperty(PropertyName = "msg_store_read_count_details")]
        public Dictionary<string, int> msg_store_read_count_details { get; private set; }

        [JsonProperty(PropertyName = "msg_store_write_count")]
        public int msg_store_write_count { get; private set; }
        
        [JsonProperty(PropertyName ="msg_store_write_count_details")]
        public Dictionary<string, int> msg_store_write_count_details { get; private set; }

        [JsonProperty(PropertyName = "queue_index_journal_write_count")]
        public int queue_index_journal_write_count { get; private set; }

        [JsonProperty(PropertyName = "queue_index_journal_write_count_details")]
        public Dictionary<string, int> queue_index_journal_write_count_details { get; private set; }

        [JsonProperty(PropertyName = "queue_index_write_count")]
        public int queue_index_write_count { get; private set; }

        [JsonProperty(PropertyName = "queue_index_write_count_details")]
        public Dictionary<string, int> queue_index_write_count_details { get; private set; }

        [JsonProperty(PropertyName = "queue_index_read_count")]
        public int queue_index_read_count { get; private set; }

        [JsonProperty(PropertyName = "queue_index_read_count_details")]
        public Dictionary<string, int> queue_index_read_count_details { get; private set; }

        [JsonProperty(PropertyName = "gc_num")]
        public int gc_num { get; private set; }

        [JsonProperty(PropertyName = "gc_enum_details")]
        public Dictionary<string, int> gc_num_details { get; private set; }


        [JsonProperty(PropertyName = "gc_bytes_reclaimed")]
        public int gc_bytes_reclaimed { get; private set; }

        [JsonProperty(PropertyName = "gc_bytes_reclaimed_details")]
        public Dictionary<string, int> gc_bytes_reclaimed_details { get; private set; }

        [JsonProperty(PropertyName = "context_switches")]
        public int context_switches { get; private set; }

        [JsonProperty(PropertyName = "context_switches_details")]
        public Dictionary<string, int> context_switches_details { get; private set; }

        [JsonProperty(PropertyName = "io_file_handle_open_attempt_count")]
        public int io_file_handle_open_attempt_count { get; private set; }

        [JsonProperty(PropertyName = "io_file_handle_open_attempt_count_details")]
        public Dictionary<string, int> io_file_handle_open_attempt_count_details { get; private set; }

        [JsonProperty(PropertyName = "io_file_handle_open_attempt_avg_time")]
        public int io_file_handle_open_attempt_avg_time { get; private set; }

        [JsonProperty(PropertyName = "io_file_Handle_open_attempt_avg_time_details")]
        public Dictionary<string, int> io_file_handle_open_attempt_avg_time_details { get; private set; }

        [JsonProperty(PropertyName = "partitions")]
        public List<string> partitions { get; private set; }

        [JsonProperty(PropertyName = "os_pid")]
        public string os_pid { get; private set; }

        [JsonProperty(PropertyName = "fd_total")]
        public int fd_total { get; private set; }

        [JsonProperty(PropertyName = "sockets_total")]
        public int sockets_total { get; private set; }
        
        [JsonProperty(PropertyName = "mem_limit")]
        public int mem_limit { get; private set; }

        [JsonProperty(PropertyName = "mem_alarm")]
        public bool mem_alarm { get; private set; }

        [JsonProperty(PropertyName = "disk_free_limit")]
        public int disk_free_limit { get; private set; }

        [JsonProperty(PropertyName = "disk_free_alarm")]
        public bool disk_free_alarm { get; private set; }

        [JsonProperty(PropertyName = "proc_total")]
        public int proc_total { get; private set; }

        [JsonProperty(PropertyName = "rates_mode")]
        public string rates_mode { get; private set; }
        
        [JsonProperty(PropertyName = "uptime")]
        public long uptime { get; private set; }
        
        [JsonProperty(PropertyName = "run_queue")]
        public int run_queue { get; private set; }
        
        [JsonProperty(PropertyName = "processors")]
        public int processors { get; private set; }


        [JsonProperty(PropertyName = "exchange_types")]
        public List<NodeExchangeType.NodeExchangeType> exchange_types { get; private set; }

        [JsonProperty(PropertyName = "auth_mechanisms")]
        public List<NodeAuthMechanisms.NodeAuthMechanisms> auth_mechanisms { get; private set; }

        [JsonProperty(PropertyName = "applications")]
        public List<NodeApplication.NodeApplication> applications { get; private set; }
        public List<NodeContext.NodeContext> contexts { get; private set; }

        public string log_file { get; private set; }
        public string sasl_log_file { get; private set; }
        public string db_dir { get; private set; }
        public List<string> config_files { get; private set; }
        public int net_ticktime { get; private set; }
        public List<string> enabled_plugins { get; private set; }
        public string name { get; private set; }
        public string type { get; private set; }
        public bool running { get; private set; }

        public NodeInfo() { }

        public NodeInfo(NodeInfoParameters parameters) { 
            this.cluster_links = parameters.cluster_links;
            this.mem_used = parameters.mem_used;
            this.mem_used_details = parameters.mem_used_details;
            this.fd_used = parameters.fd_used;
            this.fd_used_details = parameters.fd_used_details;
            this.sockets_used = parameters.sockets_used;
            this.sockets_used_details = parameters.sockets_used_details;
            this.proc_used = parameters.proc_used;
            this.proc_used_details = parameters.proc_used_details;
            this.disk_free = parameters.disk_free;
            this.disk_free_details = parameters.disk_free_details;
            this.io_read_count = parameters.io_read_count;
            this.io_read_count_details = parameters.io_read_count_details;
            this.io_read_bytes = parameters.io_read_bytes;
            this.io_read_bytes_details = parameters.io_read_bytes_details;
            this.io_read_avg_time = parameters.io_read_avg_time;
            this.io_read_avg_time_details = parameters.io_read_avg_time_details;
            this.io_write_count = parameters.io_write_count;
            this.io_write_count_details = parameters.io_write_count_details;
            this.io_write_bytes = parameters.io_write_bytes;
            this.io_write_bytes_details = parameters.io_write_bytes_details;
            this.io_write_avg_time = parameters.io_write_avg_time;
            this.io_write_avg_time_details = parameters.io_write_avg_time_details;
            this.io_sync_count = parameters.io_sync_count;
            this.io_sync_count_details = parameters.io_sync_count_details;
            this.io_sync_avg_time = parameters.io_sync_avg_time;
            this.io_sync_avg_time_details = parameters.io_sync_avg_time_details;
            this.io_seek_count = parameters.io_seek_count;
            this.io_seek_count_details = parameters.io_seek_count_details;
            this.io_seek_avg_time = parameters.io_seek_avg_time;
            this.io_seek_avg_time_details = parameters.io_seek_avg_time_details;
            this.io_reopen_count = parameters.io_reopen_count;
            this.io_reopen_count_details = parameters.io_reopen_count_details;
            this.mnesia_ram_tx_count = parameters.mnesia_ram_tx_count;
            this.mnesia_ram_tx_count_details = parameters.mnesia_ram_tx_count_details;
            this.mnesia_disk_tx_count = parameters.mnesia_disk_tx_count;
            this.mnesia_disk_tx_count_details = parameters.mnesia_disk_tx_count_details;
            this.msg_store_read_count = parameters.msg_store_read_count;
            this.msg_store_read_count_details = parameters.msg_store_read_count_details;
            this.msg_store_write_count = parameters.msg_store_write_count;
            this.msg_store_write_count_details = parameters.msg_store_write_count_details;
            this.queue_index_journal_write_count = parameters.queue_index_journal_write_count;
            this.queue_index_journal_write_count_details = parameters.queue_index_journal_write_count_details;
            this.queue_index_write_count = parameters.queue_index_write_count;
            this.queue_index_write_count_details = parameters.queue_index_write_count_details;
            this.queue_index_read_count = parameters.queue_index_read_count;
            this.queue_index_read_count_details = parameters.queue_index_read_count_details;
            this.gc_num = parameters.gc_num;
            this.gc_num_details = parameters.gc_num_details;
            this.gc_bytes_reclaimed = parameters.gc_bytes_reclaimed;
            this.gc_bytes_reclaimed_details = parameters.gc_bytes_reclaimed_details;
            this.context_switches = parameters.context_switches;
            this.context_switches_details = parameters.context_switches_details;
            this.io_file_handle_open_attempt_count = parameters.io_file_handle_open_attempt_count;
            this.io_file_handle_open_attempt_count_details = parameters.io_file_handle_open_attempt_count_details;
            this.io_file_handle_open_attempt_avg_time = parameters.io_file_handle_open_attempt_avg_time;
            this.io_file_handle_open_attempt_avg_time_details = parameters.io_file_handle_open_attempt_avg_time_details;
            this.partitions = parameters.partitions;
            this.os_pid = parameters.os_pid;
            this.fd_total = parameters.fd_total;
            this.sockets_total = parameters.sockets_total;
            this.mem_limit = parameters.mem_limit;
            this.mem_alarm = parameters.mem_alarm;
            this.disk_free_limit = parameters.disk_free_limit;
            this.disk_free_alarm = parameters.disk_free_alarm;
            this.proc_total = parameters.proc_total;
            this.rates_mode = parameters.rates_mode;
            this.uptime = parameters.uptime;
            this.run_queue = parameters.run_queue;
            this.processors = parameters.processors;
            this.exchange_types = parameters.exchange_types;
            this.auth_mechanisms = parameters.auth_mechanisms;
            this.applications = parameters.applications;
            this.contexts = parameters.contexts;
            this.log_file = parameters.log_file;
            this.sasl_log_file = parameters.sasl_log_file;
            this.db_dir = parameters.db_dir;
            this.config_files = parameters.config_files;
            this.net_ticktime = parameters.net_ticktime;
            this.enabled_plugins = parameters.enabled_plugins;
            this.name = parameters.name;
            this.type = parameters.type;
            this.running = parameters.running;
        }
    }
}
