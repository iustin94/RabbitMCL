using System;
using System.Collections.Generic;
using RabbitMQ.Client;
using ClientApp.Model;

namespace ClientApp
{
    public class ConnectionManager
    {
        private static ConnectionManager Instance;

        private ConnectionFactory ConnectionFactory;
        public IConnection Connection;
        public IModel Channel;

        private ConnectionInfo info;
        private IEnumerable<String> IpAddresses
        {
            set { this.IpAddressesEnumerator = value.GetEnumerator(); }
        }
        private IEnumerator<String> IpAddressesEnumerator { get; set; }

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

        public bool SetConnectionCredentials(string Username, string Password, string Virtualhost, int Port, IEnumerable<string> IpAddresses )
        {
            try
            {
                if (info != null)
                {
                    throw new Exception("Connection info not null. Overwriting.");
                }
                info = new ConnectionInfo(Username, Password,Virtualhost, Port);

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }       
        }

        /// <summary>
        /// Cicle to the next ip address and create new connection with it.
        /// </summary>
        /// <returns></returns>
        public bool CicleToFirstOrNextHost()
        {
            try
            {
                if (this.info == null)
                {
                    throw new Exception(
                        "Connection credentials not present.Set connection credentials before attempting to connect");
                }
                else
                {

                    //Move next might cause the enumerator to jump over the first host the first time it's called

                    if (IpAddressesEnumerator.MoveNext() != true)
                    {
                        IpAddressesEnumerator.Reset();
                    }
                    else IpAddressesEnumerator.MoveNext();


                    ConnectionFactory = new ConnectionFactory()
                    {
                        HostName = IpAddressesEnumerator.Current,
                        UserName = info.Username,
                        Password = info.Password,
                        VirtualHost = info.VirtualHost,
                        Port = info.Port,
                        AutomaticRecoveryEnabled = true,
                        RequestedHeartbeat = 5,
                        ContinuationTimeout = new TimeSpan(5000)
                    };

                    Connection = ConnectionFactory.CreateConnection();
                    Channel = Connection.CreateModel();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}