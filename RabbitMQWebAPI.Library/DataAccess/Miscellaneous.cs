using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQWebAPI.Library.DataAccess
{
    class Miscellaneous
    {
        /*TODO /api/overview	
         * Various random bits of information that describe the whole system.
         */

        /*TODO /api/cluster-name	
         * Name identifying this RabbitMQ cluster.
         */

        /*TODO /api/nodes
         * A list of nodes in the RabbitMQ cluster.
         */

        /*TODO /api/nodes/name	
         * An individual node in the RabbitMQ cluster. Add "?memory=true" to 
         * get memory statistics, and "?binary=true" to get a breakdown of binary memory use (may be expensive if there are many small binaries in the system).
         */

        /*TODO /api/extensions	
         * A list of extensions to the management plugin.
         */

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

        /*TODO /api/whoami
         * 	Details of the currently authenticated user.
         */

        /*TODO /api/aliveness-test/vhost
         * Declares a test queue, then publishes and consumes a message. Intended for use by monitoring tools. If everything is working correctly, 
         * will return HTTP status 200 with body:	
         */

        /*TODO /api/healthchecks/node	
         * Runs basic healthchecks in the current node. Checks that the rabbit application is running, channels and queues can be listed successfully, 
         * and that no alarms are in effect. If everything is working correctly, will return HTTP status 200 with body:{"status":"ok"}
         * If something fails, will return HTTP status 200 with the body of
         *{"status":"failed","reason":"string"}

         */

        /*TODO /api/healthchecks/node/node	
         * Runs basic healthchecks in the given node. Checks that the rabbit application is running, list_channels and list_queues return, and that no alarms are raised. If everything is working correctly, will return HTTP status 200 with body:
         ';*{"status":"ok"}
         *If something fails, will return HTTP status 200 with the body of
         *{"status":"failed","reason":"string"}
         */
    }
}
