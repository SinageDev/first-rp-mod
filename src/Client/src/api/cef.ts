export abstract class Browser {
  private static browserReady: boolean;
  private static _instance: BrowserMp;

  private static events = {
    "browserLoadingFailed": (browser: BrowserMp) => browser.reload(true),
    "input:focusChange": (state: boolean) => mp.game.invoke("setTypingInChatState", state),
    "ready:change": (state: boolean) => this.browserReady = state,
    "emit:server": (name: string, ...args: any[]) => mp.events.callRemote(name, ...args)
  }

  public static init = async () => {
    mp.events.add(this.events);
    this._instance = mp.browsers.new("http://localhost:3000/#/");
    await this.waitLoad();
  }

  public static reload = () => this._instance.reload(true)

  private static waitLoad = async () => {
    while (!this.browserReady) await mp.game.waitAsync(200);
  }

  public static execute = async (emit: string) => {
    await this.waitLoad();
    this._instance.execute(`window.Cef.${emit}`);
    mp.console.logInfo(`window.Cef.${emit}`);
  }
}

Browser.init();
export default Browser;