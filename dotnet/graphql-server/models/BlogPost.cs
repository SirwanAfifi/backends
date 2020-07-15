namespace graphql_server.models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }
    }
}