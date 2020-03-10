const { PubSub } = require("apollo-server");
const { GraphQLScalarType } = require("graphql");
const { Kind } = require("graphql/language");
const Movie = require("./model");

const pubsub = new PubSub();
const MOVIE_ADDED = "MOVIE_ADDED";

const resolvers = {
  Subscription: {
    movieAdded: {
      subscribe: () => pubsub.asyncIterator([MOVIE_ADDED])
    }
  },

  Query: {
    movies: async () => {
      return await Movie.find({});
    },
    movie: (obj, { id }, context, info) => {
      return Movie.findById(id) || {};
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
    async addMovie(obj, { movie }, { userId }) {
      if (userId) {
        const newMovie = await Movie.create(movie);
        pubsub.publish(MOVIE_ADDED, { movieAdded: newMovie });
      }
      return await Movie.find({});
    }
  }
};

module.exports = resolvers;
