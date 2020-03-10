const { gql } = require("apollo-server");

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
    id: ID
    title: String
    releaseDate: Date
    rating: Int
    status: Status
  }

  type Mutation {
    addMovie(movie: MovieInput!): [Movie]
  }
`;

module.exports = typeDefs;
