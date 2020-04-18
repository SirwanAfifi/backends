const dotenv = require("dotenv");
dotenv.config();

const sequelize = require("./database");

// Import Models
const User = require("./models/User");
const Post = require("./models/Post");
const Comment = require("./models/Comment");

Comment.belongsTo(Post);
Post.hasMany(Comment);
Post.belongsTo(User);
User.hasMany(Post);

sequelize.sync().catch((err) => console.log(err));
