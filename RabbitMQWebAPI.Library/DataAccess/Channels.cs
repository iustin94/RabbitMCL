using System;
using System.Collections.Generic;
using System.Linq;
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


        /*TODO /api/channels
         * A list of all open channels.
         */

        public async Task<IEnumerable<Channel>> GetChannels()
        {
            return await dataFactory.BuildModels("/api/channels", sentinel);
        }

        /*TODO /api/vhosts/vhost/channels	
         * A list of all open channels in a specific vhost.
         */

        /*TODO /api/channels/channel
         * Details about an individual channel.
         */

    }
}
