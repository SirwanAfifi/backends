const { ApolloServer, gql } = require("apollo-server");

const typeDefs = gql`
  enum Status {
    WATCHED
    INETERESTED
    NOT_INETERESTED
    UNKNOWN
  }

  type Actor {
    id: ID
    name: String
  }

  type Movie {
    id: ID!
    title: String
    releaseDate: String
    rating: Int!
    actors: [Actor]
    status: Status
    # fake: Float
    # fake2: Boolean
  }

  type Query {
    movies: [Movie]
    movie(id: ID): Movie
  }
`;

// Fake data
const movies = [
  {
    id: 1,
    title: "5 Deadly Venoms",
    releaseDate: "10-10-1983",
    rating: 5
  },
  {
    id: 2,
    title: "36th Chamber",
    releaseDate: "10-10-1993",
    rating: 5
  }
];

const resolvers = {
  Query: {
    movies: () => {
      return movies;
    },
    movie: (obj, { id }, context, info) => {
      return movies.find(m => m.id === id) || {};
    }
  }
};

const server = new ApolloServer({
  typeDefs,
  resolvers
});

server.listen().then(({ url }) => {
  console.log(`Server started at ${url}`);
});
