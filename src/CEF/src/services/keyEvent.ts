import {onMounted, onUnmounted} from "vue";

export function addTempKeyEvent(listener: (this: Window, ev: KeyboardEvent) => any) {
  onMounted(() => window.addEventListener("keyup", listener));
  onUnmounted(() => window.removeEventListener("keyup", listener));
}