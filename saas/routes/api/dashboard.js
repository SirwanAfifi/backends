const express = require("express");
const router = express.Router();

const mongoose = require("mongoose");
const createNewModel = require("../../utils");

// @route   GET api/dashboard
// @desc    Fetch model types
// @access  Public
router.get("/", async (req, res) => {
  try {
    const fieldTypes = Object.keys(mongoose.SchemaTypes);
    res.send(fieldTypes);
  } catch (err) {
    console.log(err.message);
    res.status(500).send("Server error");
  }
});

// @route   POST api/dashboard
// @desc    Create model
// @access  Public
router.post("/", createNewModel);

module.exports = router;
