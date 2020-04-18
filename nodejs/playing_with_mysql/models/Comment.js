const Sequelize = require("sequelize");

const sequelize = require("../database");
const Comment = sequelize.define("Comment", {
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
  commenter_username: {
    type: Sequelize.STRING,
    required: true,
  },
  commenter_email: {
    type: Sequelize.STRING,
    required: true,
  },
  status: {
    type: Sequelize.ENUM,
    values: ["approved", "rejected", "in review"],
  },
});
module.exports = Comment;
