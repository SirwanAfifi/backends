import * as mysql from "mysql2";
import * as util from "util";

let connection = mysql.createConnection({
  host: process.env.HOST,
  user: process.env.USER,
  password: process.env.PASS,
  database: process.env.DB,
});

const connect = util.promisify(connection.connect).bind(connection);
const query = util.promisify(connection.query).bind(connection);

export { connect, query };
