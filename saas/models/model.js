const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const ModelSchema = Schema({
  name: {
    type: String,
    required: true
  }
});

const Model = mongoose.model("models", ModelSchema);
module.exports = Model;
