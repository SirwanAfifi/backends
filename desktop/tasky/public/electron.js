const path = require("path");
const electron = require("electron");

const { app, BrowserWindow, ipcMain, Tray } = electron;

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
  tray = new Tray(iconPath);
  tray.on("click", (event, bounds) => {
    const { x, y } = bounds;
    const { height, width } = mainWindow.getBounds();

    if (mainWindow.isVisible()) {
      mainWindow.hide();
    } else {
      const yPosition = process.platform === "darwin" ? y : y - height;
      mainWindow.setBounds({
        x: x - width / 2,
        y: yPosition,
        height,
        width
      });
      mainWindow.show();
    }
  });
});
