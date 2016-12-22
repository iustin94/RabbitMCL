using System;
using RabbitMQClient;
using RabbitMQClientEvents;

namespace ClientApp
{
    public class ConnectionManager
    {
        public static ConnectionManager instance;

        private ConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel model;

        private List<String> IpAddresses = new List<String>();

        public static ConnectionManager getInstance(IEnumerable<String> addresses)
        {
            if (instance == null)
            {
                instance = new ConnectionManager(addresses);
            }
            return instance;
        }
        private ConnectionManager(IEnumerable<String> addresses)
        {
            this.IpAddresses = addresses;
        }

        public bool makeNewConnection()
        {
            this.connectionF;
        }

    }
