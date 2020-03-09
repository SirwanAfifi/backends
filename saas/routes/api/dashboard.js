const express = require("express");
const router = express.Router();

// @route   GET api/dashboard
// @desc    Test route
// @access  Public
router.get("/", (req, res) => res.send("Dashboard route"));

module.exports = router;
