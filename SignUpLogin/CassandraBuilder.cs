using Cassandra;

namespace SignUpLogin
{
    public class CassandraBuilder
    {
        public Cluster myCluster;
        public CassandraBuilder() {
            myCluster = Cluster.Builder()
                .AddContactPoint("172.17.0.3")
                .Build();
        }
    }
}
