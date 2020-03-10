const mongoose = require("mongoose");

const MoviesSchema = mongoose.Schema({
  title: String,
  releaseDate: Date,
  rating: Number,
  status: String,
  actorIds: [String]
});

const Movie = mongoose.model("movies", MoviesSchema);

module.exports = Movie;
