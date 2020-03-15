const electron = require("electron");

const { app, BrowserWindow, ipcMain } = electron;

const isDev = require("electron-is-dev");

let mainWindow;

app.on("ready", () => {
  mainWindow = new BrowserWindow({});

  mainWindow.loadURL(
    isDev
      ? "http://localhost:3000"
      : `file://${path.join(__dirname, "../build/index.html")}`
  );
});
