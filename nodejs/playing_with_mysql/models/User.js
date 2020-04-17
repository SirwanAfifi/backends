const Sequelize = require("sequelize");

const sequelize = require("../database");
const User = sequelize.define("User", {
  id: {
    primaryKey: true,
    type: Sequelize.UUID,
    defaultValue: Sequelize.UUIDV4,
  },
  firstName: Sequelize.STRING,
  lastName: Sequelize.STRING,
  userName: Sequelize.STRING,
  passowrd: Sequelize.STRING,
});
module.exports = User;
