using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace ClientApp
{
    class HostsnameSelector : IHostnameSelector
    {
        private int count;
        private int _currentIndex;

        public HostsnameSelector(IList<String> options)
        {
            this.count = options.Count;
            _currentIndex = -1;
        }

        String IHostnameSelector.NextFrom(IList<String> options)
        {
            using (var enumerator = options.GetEnumerator())
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
