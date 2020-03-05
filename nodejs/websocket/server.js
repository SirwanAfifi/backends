const WebSocket = require("ws");

const wss = new WebSocket.Server({ port: 8080 });
const modelNames = [
  "DecisionTree",
  "AdaBoost",
  "GradientBoosting",
  "NearestNeighbor",
  "SVMLinear",
  "SVMRBF",
  "GaussianProcess",
  "RandomForest",
  "MLP",
  "Bayesian",
  "QuadraticDiscriminationAnalysis",
  "RadiusNeighbors"
];

wss.on("connection", ws => {
  setInterval(() => {
    const usage = Number((Math.random() * 10).toFixed(1));
    const ram = (Math.random() * 4).toFixed(1);
    const data = {
      title: modelNames[~~(Math.random() * modelNames.length)],
      usage,
      ram
    };
    ws.send(JSON.stringify(data));
  }, 1000);
});
