using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.Models.Node
{
    public struct NodeInfoParameters
    {
        public List<NodeClusterLink.NodeClusterLink> cluster_links;
        public int mem_used;
        public Dictionary<string, int> mem_used_details;
        public int fd_used;
        public Dictionary<string, int> fd_used_details;
        public int sockets_used;
        public Dictionary<string, int> sockets_used_details;
        public int proc_used;
        public Dictionary<string, int> proc_used_details;
        public int disk_free;
        public Dictionary<string, int> disk_free_details;
        public int io_read_count;
        public Dictionary<string, int> io_read_count_details;
        public int io_read_bytes;
        public Dictionary<string, int> io_read_bytes_details;
        public int io_read_avg_time;
        public Dictionary<string, int> io_read_avg_time_details;
        public int io_write_count;
        public Dictionary<string, int> io_write_count_details;
        public int io_write_bytes;
        public Dictionary<string, int> io_write_bytes_details;
        public int io_write_avg_time;
        public Dictionary<string, int> io_write_avg_time_details;
        public int io_sync_count;
        public Dictionary<string, int> io_sync_count_details;
        public int io_sync_avg_time;
        public Dictionary<string, int> io_sync_avg_time_details;
        public int io_seek_count;
        public Dictionary<string, int> io_seek_count_details;
        public int io_seek_avg_time;
        public Dictionary<string, int> io_seek_avg_time_details;
        public int io_reopen_count;
        public Dictionary<string, int> io_reopen_count_details;
        public int mnesia_ram_tx_count;
        public Dictionary<string, int> mnesia_ram_tx_count_details;
        public int mnesia_disk_tx_count;
        public Dictionary<string, int> mnesia_disk_tx_count_details;
        public int msg_store_read_count;
        public Dictionary<string, int> msg_store_read_count_details;
        public int msg_store_write_count;
        public Dictionary<string, int> msg_store_write_count_details;
        public int queue_index_journal_write_count;
        public Dictionary<string, int> queue_index_journal_write_count_details;
        public int queue_index_write_count;
        public Dictionary<string, int> queue_index_write_count_details;
        public int queue_index_read_count;
        public Dictionary<string, int> queue_index_read_count_details;
        public int gc_num;
        public Dictionary<string, int> gc_num_details;
        public int gc_bytes_reclaimed;
        public Dictionary<string, int> gc_bytes_reclaimed_details;
        public int context_switches;
        public Dictionary<string, int> context_switches_details;
        public int io_file_handle_open_attempt_count;
        public Dictionary<string, int> io_file_handle_open_attempt_count_details;
        public int io_file_handle_open_attempt_avg_time;
        public Dictionary<string, int> io_file_handle_open_attempt_avg_time_details;
        public List<string> partitions;
        public string os_pid;
        public int fd_total;
        public int sockets_total;
        public int mem_limit;
        public bool mem_alarm;
        public int disk_free_limit;
        public bool disk_free_alarm;
        public int proc_total;
        public string rates_mode;
        public long uptime;
        public int run_queue;
        public int processors;

        public List<NodeExchangeType.NodeExchangeType> exchange_types;
        public List<NodeAuthMechanisms.NodeAuthMechanisms> auth_mechanisms;
        public List<NodeApplication.NodeApplication> applications;
        public List<NodeContext.NodeContext> contexts;

        public string log_file;
        public string sasl_log_file;
        public string db_dir;
        public List<string> config_files;
        public int net_ticktime;
        public List<string> enabled_plugins;
        public string name;
        public string type;
        public bool running;
    }
}
