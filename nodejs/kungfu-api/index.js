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
    actors(id: ID): [Actor]
    status: Status
    # fake: Float
    # fake2: Boolean
  }

  type Query {
    movies: [Movie]
    movie(id: ID): Movie
  }

  input ActorInput {
    id: ID!
  }
  input MovieInput {
    id: ID!
    title: String
    releaseDate: Date
    rating: Int!
    status: Status
  }

  type Mutation {
    addMovie(movie: MovieInput!): [Movie]
  }
`;

// Fake data
const actors = [
  {
    id: "brad",
    name: "Bard Pitt"
  }
];

const movies = [
  {
    id: 1,
    title: "5 Deadly Venoms",
    releaseDate: new Date("10-12-1983"),
    rating: 5,
    actors: [
      {
        id: "brad"
      }
    ]
  },
  {
    id: 2,
    title: "36th Chamber",
    releaseDate: new Date("10-10-1993"),
    rating: 5,
    actors: [
      {
        id: "brad"
      }
    ]
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
  Movie: {
    actors: (obj, args, context) => {
      const actorIds = obj.actors.map(actor => actor.id);
      const filteredActors = actors.filter(actor =>
        actorIds.includes(actor.id)
      );
      return args.id
        ? filteredActors.filter(a => a.id === args.id)
        : filteredActors;
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
  }),
  Mutation: {
    addMovie(obj, { movie }, { userId }) {
      if (userId) {
        const newMoviesList = [...movies, movie];
        return newMoviesList;
      }
      return movies;
    }
  }
};

const server = new ApolloServer({
  typeDefs,
  resolvers,
  introspection: true,
  playground: true,
  // This is where we define our context
  context: ({ req }) => {
    const fakeUser = {
      userId: "sirwanAfifi"
    };
    return {
      ...fakeUser
    };
  }
});

server
  .listen({
    port: process.env.PORT || 4000
  })
  .then(({ url }) => {
    console.log(`Server started at ${url}`);
  });
