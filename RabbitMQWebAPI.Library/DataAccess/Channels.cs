using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;
using RabbitMQWebAPI.Library.Models.Channel;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Channels
    {

        private ChannelSentinel sentinel;
        private DataFactory<Channel> dataFactory;

        public Channels() { }

        public Channels(HttpClient client)
        {
            dataFactory = new DataFactory<Channel>(client);
            sentinel = new ChannelSentinel();
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Channel&gt; with all the channels.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Channel>> GetChannels()
        {
            return await dataFactory.BuildModels("/api/channels", sentinel);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Channel&gt; object with all the channels on the specified virtual host
        /// </summary>
        /// <param name="vhost"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Channel>> GetChannelsOnVhost(string vhost)
        {
            vhost = WebUtility.UrlEncode(vhost);

            return await dataFactory.BuildModels(String.Format("/api/vhosts/{0}/channels", vhost), sentinel);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Channel
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public async Task<Channel> GetChannel(string channelName)
        {
            channelName = WebUtility.UrlEncode(channelName);

            return await dataFactory.BuildModel(String.Format("/api/channels/{0}", channelName), sentinel);
        }
    }
}
