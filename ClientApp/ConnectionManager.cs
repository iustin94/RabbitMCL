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

        private ConnectionFactory factory;
        public IConnection Connection ;
        public IModel Channel;

        private ConnectionInfo info;
        private IEnumerable<String> Hosts;

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

        public bool SetConnectionCredentials(string Ip, string Username, string Password, string Virtualhost, IEnumerable<string> Hosts = null )
        {
            try
            {
                if (info != null)       
                    throw new Exception("Connection info not null. Overwriting.");
        
                info = new ConnectionInfo(Username, Password,Virtualhost);

                factory = new ConnectionFactory();
                factory.UserName = Username;
                factory.Password = Password;
                factory.VirtualHost = Virtualhost;
                factory.HostName = Ip;

                if (Hosts != null)
                {
                    factory.AutomaticRecoveryEnabled = true;
                    factory.HostnameSelector = ;
                }
                Connection = factory.CreateConnection();
                Channel = Connection.CreateModel();

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