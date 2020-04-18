const Sequelize = require("sequelize");

const sequelize = require("../database");
const Post = sequelize.define("Post", {
  id: {
    type: Sequelize.UUID,
    primaryKey: true,
    defaultValue: Sequelize.UUIDV4,
    allowNull: false,
  },
  content: {
    type: Sequelize.TEXT,
    required: true,
  },
});
module.exports = Post;
