const epxress = require("express");
const { ApolloServer, gql } = require("apollo-server-express");

const typeDefs = gql`
  type Query {
    hello: String
  }
`;
const resolvers = {
  Query: {
    hello: () => "Hello World!"
  }
};
const PORT = 3000;

const apolloServer = new ApolloServer({ typeDefs, resolvers });

const app = epxress();
apolloServer.applyMiddleware({ app, path: "/api/graphql" });

app.listen(PORT, () => {
  console.log(`🚀 Listening on port ${PORT}`);
});
