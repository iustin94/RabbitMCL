using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.Models.Extention;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Extentions
    {
        private ExtentionSentinel sentinel = new ExtentionSentinel();
        private DataFactory<Extention> dataFactory;

        public Extentions(HttpClient client)
        {
            dataFactory = new DataFactory<Extention>(client);
        }

        /// <summary>
        ///  Returns a IEnumerable&lt;Extention&gt; object of extensions to the management plugin.
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<Extention>> GetExtentions()
        {
            return await dataFactory.BuildModels("/api/extensions", sentinel);
        }
    }
}
