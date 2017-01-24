using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using ClientApp.Model;

namespace ClientApp
{
    public class ConnectionManager
    {
        private static ConnectionManager Instance;

        public ConnectionFactory Factory;

        private ConnectionInfo info;


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

        public bool SetConnectionCredentials(string Ip, string Username, string Password, string Virtualhost, IEnumerable<string> Hosts  )
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
                Factory.RequestedHeartbeat = 20;

                if (Hosts != null)
                {
                    Factory.HostnameSelector = new HostsnameSelector(Hosts.ToList());
                    Factory.AutomaticRecoveryEnabled = true;
                    Factory.TopologyRecoveryEnabled = true;
                    Factory.NetworkRecoveryInterval = TimeSpan.FromSeconds(5);
                }

                return true;
            }
            catch (Exception ex)
            {
                
                Console.Write(ex.Message);
                return false;
            }       
        }
        
    }
}