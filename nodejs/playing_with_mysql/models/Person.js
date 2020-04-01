const Sequelize = require("sequelize");

const sequelize = require("../database");
const Person = sequelize.define("people", {
  title: {
    type: Sequelize.DataTypes.STRING,
    primaryKey: true,
    unique: true
  },
  price: {
    type: Sequelize.DataTypes.DECIMAL,
    primaryKey: true,
    unique: true
  }
});

module.exports = Person;
