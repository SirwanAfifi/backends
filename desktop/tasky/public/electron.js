const path = require("path");
const electron = require("electron");

const AppTray = require("../app/app_tray");
const { app, BrowserWindow } = electron;

const isDev = require("electron-is-dev");

let mainWindow;
let tray;

app.on("ready", () => {
  mainWindow = new BrowserWindow({
    height: 500,
    width: 300,
    frame: false,
    resizable: false,
    show: false
  });

  mainWindow.loadURL(
    isDev
      ? "http://localhost:3000"
      : `file://${path.join(__dirname, "../build/index.html")}`
  );

  mainWindow.on("blur", () => {
    mainWindow.hide();
  });

  const iconName = process.platform === "win32" ? "icon.png" : "icon.png";
  const iconPath = path.join(__dirname, `./${iconName}`);
  tray = new AppTray(iconPath, mainWindow);
});
