import {reactive, ref} from "vue";

export enum NotifyType {
  error,
  done
}

export class Notify {
  public static readonly Notifies: Notify[] = reactive([]);
  public Type: NotifyType;
  public Text: string;
  private Ms: number;
  public Complete = ref(0);
  private Interval: NodeJS.Timer;

  constructor(type: NotifyType, text: string, ms = 5000) {
    this.Type = type;
    this.Text = text;
    this.Ms = ms;

    this.Interval = setInterval(() => {
      this.Complete.value++;
      if(this.Complete.value == 100) {
        clearInterval(this.Interval);
        const index = Notify.Notifies.indexOf(this);
        if(index === -1) return;
        Notify.Notifies.splice(index, 1);
      }
    }, ms/100);
  }

  public static Send(type: NotifyType, text: string, ms = 5000) {
    if(this.Notifies.length >= 3) this.Notifies.shift();
    const notify = new Notify(type, text, ms);
    if(Array.isArray(notify)) this.Notifies.push(...notify);
    else this.Notifies.push(notify);
  }
}