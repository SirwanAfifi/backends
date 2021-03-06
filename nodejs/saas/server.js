const epxress = require("express");
const connectDB = require("./config/db");

const app = epxress();
connectDB();

app.use(epxress.json({ extended: false }));

app.get("/", (req, res) => {
  res.send("API is running");
});

app.use("/api/dashboard", require("./routes/api/dashboard"));

const PORT = process.env.PORT || 5000;

app.listen(PORT, () => {
  console.log(`Server started on port ${PORT}`);
});
