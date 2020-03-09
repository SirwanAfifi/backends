const createNewModel = async (req, res, next) => {
  try {
    const Schema = mongoose.Schema;
    mongoose.model(req.body.modelName, new Schema(req.body.model));
    res.send("Created new model.");
  } catch (err) {
    res.send(err);
  }
};

module.exports = createNewModel;
