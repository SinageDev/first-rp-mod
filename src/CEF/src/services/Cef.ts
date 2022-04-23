import { useChatStore } from "../stores/Chat";

export const Cef = {
  chat: useChatStore()
}

window.Cef = Cef;
