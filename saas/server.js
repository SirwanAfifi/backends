const epxress = require("express");
const connectDB = require("./config/db");

const app = epxress();
connectDB();

app.get("/", (req, res) => {
  res.send("API is running");
});

const PORT = process.env.PORT || 5000;

app.listen(PORT, () => {
  console.log(`Server started on port ${PORT}`);
});
