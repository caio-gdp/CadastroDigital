export class CssHelper {
  static changeFColor(obj: string){
    var element = <HTMLElement>document.getElementById(obj);
    element.style.color = "#3399FF";
  }

  static changeBColor(obj: string){
    var element = <HTMLElement>document.getElementById(obj);
    element.style.color = "gray";
  }
}
