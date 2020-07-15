using System.Collections.Generic;
using graphql_server.models;

namespace graphql_server.services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;
        
        public AuthorService(AuthorRepository 
            authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }
        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }
        public List<BlogPost> GetPostsByAuthor(int id)
        {
            return _authorRepository.GetPostsByAuthor(id);
        }
    }
}