import { fileURLToPath, URL } from 'node:url'
import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'
import fs from "fs";

export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    port: 4001,
    https: {
      key: fs.readFileSync("./https/certificate.key"),
      cert: fs.readFileSync("./https/certificate.pem"),
    },
  },
})
