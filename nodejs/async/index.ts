import fetch from "node-fetch";

function display(data) {
  console.log("API Call");
}
function startTimer(data) {
  console.log("Timer");
}
const long_running_task = () => {
  const users = [];
  for (let i = 0; i < 1_000_000; i++) {
    users.push({ name: `User ${++i}` });
  }
  return users;
};
setTimeout(startTimer, 0);
const placeholder = fetch("http://localhost:3000/data");
placeholder.then(display);
long_running_task();
console.log("Global Code");
