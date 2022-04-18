const PROXY_CONFIG = [
  {
    context: [
      "/api/**",
    ],
    target: "https://localhost:44326",
    secure: false,
    changeOrigin: true
  }
]

module.exports = PROXY_CONFIG;
