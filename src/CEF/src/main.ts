import { createApp } from 'vue'
import App from './App.vue'
import router from "./router/router"
import {createPinia} from "pinia";

createApp(App).use(createPinia()).use(router).mount('#app')

declare global {
  interface Window {
    router: any;
    mp: any;
    Cef: any;
  }
  interface mp {
    trigger: (name: string, ...args: any[]) => void;
  }
}