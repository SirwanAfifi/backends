const fs = require("fs");
fs.writeFile("target.txt", "Hello world", err => {
  if (err) {
    throw err;
  }
  console.log("File saved!");
});
