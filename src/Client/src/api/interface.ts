interface InterfaceState {
  hud?: boolean;
  radar?: boolean;
  cash?: boolean;
}

export abstract class Interface {
  private static _cursor?: number;
  private static set cursor_timer(value: number | undefined) {
    if(this._cursor != undefined) clearInterval(this._cursor);
    this._cursor = value;
  }

  public static hud: boolean;
  public static radar: boolean;
  public static cash: boolean;

  public static cursor({freeze, show}: {freeze?: boolean; show: boolean}): void {
    if(freeze != undefined) {
      mp.gui.cursor.show(freeze, show);
      if(!freeze) this.cursor_timer = undefined;
      else this.cursor_timer = setInterval(() => mp.gui.cursor.show(freeze, show), 200);
    } else mp.gui.cursor.visible = show;
  }

  public static state(display: InterfaceState) {
    if(display.hud != undefined) mp.game.ui.displayHud(display.hud);
    if(display.radar != undefined) mp.game.ui.displayRadar(display.radar);
    if(display.cash != undefined) mp.game.ui.displayCash(display.cash);
  }
}

mp.events.add({
  "cursor:state": (show: boolean, freeze: boolean) => Interface.cursor({ show, freeze })
});