import * as dotenv from "dotenv";
import * as mysql from "mysql";
dotenv.config();

let connection = mysql.createConnection({
  host: process.env.HOST,
  user: process.env.USER,
  password: process.env.PASS,
  database: process.env.DB,
});

const tables = connection.query(`SHOW TABLES;`);

console.log(tables);
