export default abstract class Rage {
  static trigger = {
    server: (serverEvent: string, ...args: any[]) => {
      if ("mp" in window) window.mp.trigger("emit:server", serverEvent, ...args);
    },
    client: (clientEvent: string, ...args: any[]) => {
      if ("mp" in window) window.mp.trigger(clientEvent, ...args);
    }
  }

  static events = {
    add: (name: string, listener: (...args: any[]) => void) => {
      if ("mp" in window) window.mp.events.add(name, listener);
    },
    addProc: (name: string, listener: (...args: any[]) => any) => {
      if ("mp" in window) window.mp.events.addProc(name, listener);
    }
  };
  static cursor = {
    state: (show: boolean, freeze?: boolean) => Rage.trigger.client("cursor:state", show, freeze)
  };
}