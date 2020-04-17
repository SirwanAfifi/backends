const dotenv = require("dotenv");
dotenv.config();

const sequelize = require("./database");

// Import Models
const User = require("./models/User");
const Post = require("./models/Post");

Post.belongsTo(User); // Adds FK userId in Post

sequelize
  .sync()
  .then((result) => console.log(result))
  .catch((err) => console.log(err));
