import {Interface} from "../api/interface";

mp.events.add("playerReady", () => {
  mp.gui.chat.activate(false);
  mp.gui.chat.show(false);
  Interface.cursor({ freeze: true, show: true })
});