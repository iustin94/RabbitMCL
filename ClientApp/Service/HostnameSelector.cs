using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Service;
using RabbitMQ.Client;

namespace ClientApp
{
    class HostsnameSelector : IHostnameSelector
    {
        private int count;
        private int _currentIndex;

        //Do I really need this?
        public HostsnameSelector(IList<String> Hosts)
        {
           
                if (Hosts.Count == 0) throw new Exception("Hosts list can not be empty");
                this.count = Hosts.Count;
                _currentIndex = -1;            
        }

        String IHostnameSelector.NextFrom(IList<String> Hosts)
        {
            using (var enumerator = Hosts.GetEnumerator())
            {
                if (_currentIndex < 0 || _currentIndex > count)
                    _currentIndex = 0;

                for (int i = 0; i <= _currentIndex; i++)
                {
                    enumerator.MoveNext();
                }

                _currentIndex++;

                return enumerator.Current;
            }
        }
    }
}
