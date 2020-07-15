import * as express from "express";
import * as dotenv from "dotenv";
import { connect, query } from "./database";
import { Endpoint } from "./endpoints";

(async () => {
  const app = express();
  dotenv.config();
  await connect();
})();
