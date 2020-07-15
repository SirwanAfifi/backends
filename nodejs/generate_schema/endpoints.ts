import { Express, Request, Response } from "express";
import { query } from "./database";

export class Endpoint {
  constructor(private app: Express, private port: number) {}

  init(tables: [], schemaName: string) {
    this.app.get("/", (req: Request, res: Response) => {
      const tableList = `
              <ul>
                ${tables
                  .map(
                    (table) =>
                      `<li><a href="/${schemaName}">${schemaName}</a></li>`
                  )
                  .join("")}
              <ul>
            `;
      res.send(tableList);
    });

    this.app.listen(this.port, () => {
      console.log(`Listining on port ${this.port}`);
    });
  }

  async generateEndpoint(endpoint: string) {
    // GET
    this.app.get(`/${endpoint}`, async (req: Request, res: Response) => {
      const showAlls = await query(`SELECT * FROM ${endpoint}`);

      res.send(showAlls);
    });

    // GET :/id
    this.app.get(
      `/${endpoint}/:id(\\d+)/`,
      async (req: Request, res: Response) => {
        const { id } = req.params;
        const PK = await query(
          `SHOW KEYS FROM ${endpoint} WHERE Key_name = 'PRIMARY'`
        );
        if (PK && PK.length > 0) {
          const showAlls = await query(
            `SELECT * FROM ${endpoint} WHERE ${PK[0].Column_name} = ${id}`
          );
          res.send(showAlls);
        } else {
          res.send({ message: "The table doesnt have a PRIMARY key" });
        }
      }
    );

    // POST
    this.app.post(`/${endpoint}`, async (req: Request, res: Response) => {
      res.send("ok");
    });

    this.app.get(`/${endpoint}/:query`, async (req: Request, res: Response) => {
      // TODO
      res.send("ok");
    });
  }
}
