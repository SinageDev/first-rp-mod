import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import * as path from "path"
const srcFolder = path.join(__dirname, './src/');

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue({
    reactivityTransform: true
  })],
  resolve: {
    alias: {
      "@views": path.join(srcFolder, "./views"),
      "@services": path.join(srcFolder, "./services"),
      "@assets": path.join(srcFolder, "./assets"),
      "@images": path.join(srcFolder, "./assets/images/")
    }
  },
  css: {
    preprocessorOptions: {
      stylus: {
        imports: [path.resolve(__dirname, 'src/assets/stylus/*.styl')]
      }
    }
  }
})
