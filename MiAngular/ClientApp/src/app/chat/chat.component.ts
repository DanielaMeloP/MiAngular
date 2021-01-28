import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({

  selector: 'chat-app',
  templateUrl: "./chat.component.html"

})

  //Clase de Typescript
export class ChatComponent {


  ////Funciones propias del chat
  public lstMessages: Message[];

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    http.get<Message[]>(baseUrl + "api/Chat/Message").subscribe(result => {
      this.lstMessages = result;
     // console.log("Base URL: ", baseUrl);
    }, error => console.error(error));
  }
}


interface Message {
  Id: number,
  Name: string,
  Message: string;
}
