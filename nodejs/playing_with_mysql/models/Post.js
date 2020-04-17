const Sequelize = require("sequelize");

const sequelize = require("../database");
const Post = sequelize.define("Post", {
  id: {
    primaryKey: true,
    type: Sequelize.UUID,
    defaultValue: Sequelize.UUIDV4,
  },
  title: Sequelize.STRING,
  content: Sequelize.TEXT,
});
module.exports = Post;
