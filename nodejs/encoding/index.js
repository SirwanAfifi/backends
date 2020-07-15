const uint8arr = new TextEncoder().encode("Hello I'm Sirwan Afifi");
console.log(new TextDecoder("utf8").decode(uint8arr));
