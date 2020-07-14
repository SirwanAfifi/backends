using GraphQL.Types;
using graphql_server.models;

namespace graphql_server.routes
{
    public class BlogPostType : ObjectGraphType<BlogPost>
    {
        public BlogPostType()
        {
            Name = "BlogPost";
            Field(_ => _.Id, type: 
                typeof(IdGraphType)).Description
                ("The Id of the Blog post.");
            Field(_ => _.Title).Description
                ("The title of the blog post.");
            Field(_ => _.Content).Description
                ("The content of the blog post.");
        }
    }
}