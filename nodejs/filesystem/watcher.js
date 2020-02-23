const fs = require("fs");

fs.watch("target.txt", e => console.log("Target changed!", e));

console.log("Now watching target.txt for changes...");
