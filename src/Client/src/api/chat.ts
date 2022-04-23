import Browser from "./cef";

export default abstract class Chat {
  static sendMessage(text: string) {
    Browser.execute(`chat.sendMessage('${text}')`);
  }
}

mp.events.add({
  "chat:message": (text: string) => mp.events.callRemote("Chat:Message", text),
  "chat:command": (command: string, ...args: any[]) => mp.events.callRemote("Chat:TryCommand", command, JSON.stringify(args)),
  "chat:sendMessage": Chat.sendMessage
});