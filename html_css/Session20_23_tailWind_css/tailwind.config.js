/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}", "./node_modules/flowbite/**/*.js"],
  theme: {
    // custom ở chỗ extend này nè
    extend: {
      container: {
        center: true
      },
      backgroundColor: {
        mainColor: "#A2D2DF",
        secondColor: "#F6EACB",
        bodyColor: "#151937"
      }, textColor: {
        mainColor: "F6EACB",
        profileColor: "#9334e9"
      }, borderColor: {
        profileColor: "#9334e9"
      }, backgroundImage: {
        'gradient-text': "linear-gradient(to left, #FFCBA0, #DD5789, #9B5BE6);"
      }
    },
  },
  plugins: [require('flowbite/plugin')],
}

