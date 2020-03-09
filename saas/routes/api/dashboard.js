const express = require("express");
const router = express.Router();

const Model = require("../../models/model");

// @route   POST api/dashboard
// @desc    Create model
// @access  Public
router.post("/", async (req, res) => {
  try {
    const { name } = req.body;
    let model = new Model({
      name
    });
    await model.save();
    res.send("Model saved");
  } catch (err) {
    console.log(err.message);
    res.status(500).send("Server error");
  }
});

module.exports = router;
