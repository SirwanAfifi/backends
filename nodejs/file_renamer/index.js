const fs = require("fs");
var path = require("path");
const dotenv = require("dotenv");
dotenv.config();

const dirName = process.env.DIR_PATH;

const items = [];

fs.readFileSync(`${dirName}/0.txt`)
  .toString()
  .split("\n")
  .map((name, index) => {
    const fileName = path.join(
      `${index}. ${name
        .replace(/[.,\/#!$%\^&\*;:{}=\-_`~()]/g, "")
        .replace("\r", "")
        .trim()}.mp4`
    );
    items.push(fileName);
  });

fs.readdir(dirName, (err, files) => {
  if (err) {
    throw new Error("Error");
  }

  const fileNames = files.slice(1).sort((a, b) => {
    const fileNameA = a.split("lesson")[1].split(".mp4")[0];
    const fileNameB = b.split("lesson")[1].split(".mp4")[0];

    return fileNameA - fileNameB;
  });

  fileNames.map((item, index) => {
    fs.renameSync(path.join(dirName, item), path.join(dirName, items[index]));
    console.log("Done");
  });
});
