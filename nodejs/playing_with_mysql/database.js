const Sequelize = require("sequelize");

const DB_NAME = process.env.DB_NAME;
const USER = process.env.USER;
const PWD = process.env.PWD;

const sequelize = new Sequelize(DB_NAME, USER, PWD, {
  dialect: "mysql",
  host: "localhost"
});

module.exports = sequelize;
