using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RabbitMQWebAPI.Library.DataAccess.DataFactory;
using RabbitMQWebAPI.Library.Models.User;
using UserSentinel = RabbitMQWebAPI.Library.Models.User.UserSentinel;

namespace RabbitMQWebAPI.Library.DataAccess
{
    public class Users
    {
        private UserSentinel sentinel = new UserSentinel();
        private DataFactory<User> dataFactory;

        public Users(HttpClient client)
        {
            dataFactory = new DataFactory<User>(client);
        }

         /// <summary>
         /// Returns a IEnumerable&lt;User&gt; with all users.
         /// </summary>
         /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await dataFactory.BuildModels("/api/users", sentinel);
        }

        /// <summary>
        /// Returns a User identified by his username.
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetUserByName(string userName)
        {
            userName = WebUtility.UrlEncode(userName);

            return await dataFactory.BuildModel(String.Format("/api/users/{0}", userName), sentinel);
        } 

        
    }
}
