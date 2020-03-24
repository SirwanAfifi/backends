const dotenv = require("dotenv");
dotenv.config();

const sequelize = require("./database");

// Import Models
const Product = require("./models/product");

sequelize
  .sync()
  .then(result => console.log(result))
  .catch(err => console.log(err));
