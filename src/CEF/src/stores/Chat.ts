import {defineStore} from "pinia";

interface IMessage {
  text: string;
}

interface IChatState {
  show: boolean;
  messageList: IMessage[];
}

export const useChatStore = defineStore("Chat", {
  state: (): IChatState => ({
    show: false,
    messageList: []
  }),
  actions: {
    sendMessage(text: string) {
      this.messageList.push({ text });
    }
  }
});