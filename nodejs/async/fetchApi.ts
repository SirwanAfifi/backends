function fetch(url: string) {
  return new Promise((resolve, reject) => {
    const xhr = new XMLHttpRequest();

    xhr.onload = function () {
      resolve(new Response(xhr.response));
    };

    xhr.open("GET", url);
  });
}
