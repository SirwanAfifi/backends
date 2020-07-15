using GraphQL;
using GraphQL.Types;

namespace graphql_server.routes
{
    public class GraphQLDemoSchema:Schema, ISchema
    {
        public GraphQLDemoSchema(IDependencyResolver 
            resolver):base(resolver)
        {
            Query = resolver.Resolve<AuthorQuery>();
        }
    }
}