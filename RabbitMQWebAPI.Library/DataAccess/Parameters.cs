using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;
using RabbitMQWebAPI.Library.Models.Parameter;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Parameters
    {
        private ParameterSentinel sentinel = new ParameterSentinel();
        private DataFactory<Parameter> dataFactory;

        public Parameters(HttpClient client)
        {
            dataFactory = new DataFactory<Parameter>(client);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Parameter&gt; with all parameters. 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Parameter>> GetParameters()
        {
            return await dataFactory.BuildModels("/api/parameters", sentinel);
        }
      
        /// <summary>
        /// Returns a IEnumerable&lt;Parameter&gt; with all parameters for a component.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Parameter>> GetParametersForComponent(string componentName)
        {
            componentName = WebUtility.UrlEncode(componentName);

            return await dataFactory.BuildModels(String.Format("/api/parameters/{0}", componentName), sentinel);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Parameter&gt; with all parameters for a component on a vhost.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Parameter>> GetParametersForComponentOnVHost(string componentName, string vhost)
        {
            componentName = WebUtility.UrlEncode(componentName);
            vhost = WebUtility.UrlEncode(vhost);

            return
                await dataFactory.BuildModels(string.Format("/api/parameters/{0}/{1}", componentName, vhost), sentinel);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Parameter&gt; with all parameters. 
        /// </summary>
        /// <returns></returns>
        public async Task<Parameter> GetParameterForComponentOnVhostByName(string componentName, string vhost,
            string name)
        {
            componentName = WebUtility.UrlEncode(componentName);
            vhost = WebUtility.UrlEncode(vhost);
            name = WebUtility.UrlEncode(name);

            return
                await
                    dataFactory.BuildModel(String.Format("/api/parameters/{0}/{1}/{2}", componentName, vhost, name),
                        sentinel);
        }
    }
}
