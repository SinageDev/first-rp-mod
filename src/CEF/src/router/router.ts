import { createRouter, createWebHashHistory } from "vue-router";
import routes from "./routes"
import Rage from "@services/Rage";

window.router = createRouter({
  history: createWebHashHistory(),
  routes
});

window.router.beforeEach(() => {
  Rage.trigger.client("ready:change", false);
})

window.router.afterEach(() => {
  Rage.trigger.client("ready:change", true);
});

export default window.router;