using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Policy;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Policies
    {
        private PolicySentinel sentinel = new PolicySentinel();
        private DataFactory<Policy> dataFactory;

        public Policies(HttpClient client)
        {
            dataFactory = new DataFactory<Policy>(client);
        }

        /// <summary>
        /// Return a IEnumerable&lt;Policy&gt; of all policies.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            return await dataFactory.BuildModels("/api/policies", sentinel);
        }

        /// <summary>
        /// Return a IEnumerable&lt;Policy&gt; of all policies in a given virtual host.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Policy>> GetPoliciesOnVhost(string vhost)
        {
            vhost = WebUtility.UrlEncode(vhost);

            return await dataFactory.BuildModels(String.Format("/api/policies/{0}", vhost), sentinel);
        }

        /// <summary>
        /// Return a specific Policy object on a vhost by name.
        /// </summary>
        /// <returns></returns>
        public async Task<Policy> GetPolicyOnVhostByName(string vhost, string policyName)
        {
            vhost = WebUtility.UrlEncode(vhost);
            policyName = WebUtility.UrlEncode(policyName);

            return await dataFactory.BuildModel(String.Format("/api/policies/{0}/{1}", vhost, policyName), sentinel);
        }
    }
}
