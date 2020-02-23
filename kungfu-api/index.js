const { ApolloServer, gql } = require("apollo-server");
const { GraphQLScalarType } = require("graphql");
const { Kind } = require("graphql/language");

const typeDefs = gql`
  scalar Date

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
    releaseDate: Date
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
    releaseDate: new Date("10-12-1983"),
    rating: 5
  },
  {
    id: 2,
    title: "36th Chamber",
    releaseDate: new Date("10-10-1993"),
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
  },
  Date: new GraphQLScalarType({
    name: "Date",
    description: "It's a date, deal with it",
    parseValue(value) {
      // value from the client
      return new Date(value);
    },
    serialize(value) {
      // value sent to the client
      return value.getTime();
    },
    parseLiteral(ast) {
      if (ast.kind === Kind.INT) {
        return new Date(ast.value);
      }
      return null;
    }
  })
};

const server = new ApolloServer({
  typeDefs,
  resolvers,
  introspection: true,
  playground: true
});

server
  .listen({
    port: process.env.PORT || 4000
  })
  .then(({ url }) => {
    console.log(`Server started at ${url}`);
  });
