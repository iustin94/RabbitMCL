namespace RabbitMQWebAPI.Library.Models.Node.NodeExchangeType
{
    public class NodeExchangeType
    {
        public string name { get; private set; }
        public string description { get; private set; }
        public bool enabled { get; private set; }

        public NodeExchangeType() { }

        public NodeExchangeType(NodeExchangeTypeParameters parameters)
        {
            this.name = parameters.name;
            this.description = parameters.description;
            this.enabled = parameters.enabled;
        }
    }
}
