using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using ClientApp.Model;

namespace ClientApp.Service
{
    public class ConnectionManager
    {
        private static ConnectionManager Instance;

        public ConnectionFactory Factory { get; set; }
        public IConnection Connection { get; set; }


        private ConnectionInfo info { get; set; }
        private static IEnumerable<string> Hosts { get; set; }

        public static ConnectionManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ConnectionManager();
            }
            return Instance;
        }

        private ConnectionManager()
        {
            
        }

        public bool CreateFactory(string Ip, string Username, string Password, string Virtualhost, IEnumerable<string> Hosts  )
        {
            try
            {
                if (info != null)       
                    throw new Exception("Connection info not null. Overwriting.");
        
                info = new ConnectionInfo(Username, Password,Virtualhost);

                Factory = new ConnectionFactory();
                Factory.UserName = Username;
                Factory.Password = Password;
                Factory.VirtualHost = Virtualhost;
                Factory.HostName = Ip;
                Factory.ContinuationTimeout = new TimeSpan(5);
                Factory.RequestedHeartbeat = 40;
                if (Hosts != null)
                {
                    Factory.HostnameSelector = new HostsnameSelector(Hosts.ToList());
                    Factory.AutomaticRecoveryEnabled = true;
                    Factory.TopologyRecoveryEnabled = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }       
        }


        /// <summary>
        /// Returns a connection item. If the ConnectionManager class has a list of host names set then it will use that list.
        /// </summary>
        /// <returns></returns>
        public IConnection CreateConnection(IEnumerable<string> Hosts)
        {
            if(this.Factory == null)
                throw new Exception("ConnectioManager does not have a RabbitMQ factory to use.");

            if (Hosts != null)
                return Factory.CreateConnection(Hosts.ToList());
            else
                return Factory.CreateConnection();
        }
    }
}