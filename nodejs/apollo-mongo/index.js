const { ApolloServer } = require("apollo-server");
const typeDefs = require("./typeDefs");
const resolvers = require("./resolvers");
const connectDB = require("./db");

(async () => {
  await connectDB();
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
})();
