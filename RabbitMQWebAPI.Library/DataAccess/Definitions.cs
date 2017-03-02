using RabbitMQWebAPI.Library.Models.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Definitions
    {
        private DefinitionSentinel sentinel = new DefinitionSentinel();
        private DataFactory<Definition> dataFactory;

        public Definitions(HttpClient client)
        {
            dataFactory = new DataFactory<Definition>(client);
        }

        /// <summary>
        /// Returns a IEnumerable&lt;Definition&gt; with all definitions on a vhost.
        /// </summary>
        /// <param name="vhostName"></param>
        /// <returns></returns>

        public async Task<Definition> GetDefinitionsOnVhost(string vhostName)
        {
            vhostName = WebUtility.UrlEncode(vhostName);

            return await dataFactory.BuildModel(String.Format("/api/definitions/{0}", vhostName), sentinel);
        }

        /*TODO /api/definitions
         *The server definitions - exchanges, queues, bindings, users, virtual hosts, permissions and parameters. Everything apart from messages. 
         *POST to upload an existing set of definitions. Note that:
         *    The definitions are merged. Anything already existing on the server but not in the uploaded definitions is untouched.
         *    Conflicting definitions on immutable objects (exchanges, queues and bindings) will cause an error.
         *    Conflicting definitions on mutable objects will cause the object in the server to be overwritten with the object from the definitions.
         *    In the event of an error you will be left with a part-applied set of definitions.
         *    For convenience you may upload a file from a browser to this URI (i.e. you can use multipart/form-data as well as application/json) in 
         *    which case the definitions should be uploaded as a form field named "file".
         */

        /// <summary>
        /// Returns a IEnumerable&lt;Definition&gt; with all definitions.
        /// </summary>
        /// <param name="vhostName"></param>
        /// <returns></returns>

        public async Task<Definition> GetDefinitions()
        {
            return await dataFactory.BuildModel("/api/definitions",sentinel);
        }
    }

}
