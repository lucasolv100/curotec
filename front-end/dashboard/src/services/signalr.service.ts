import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class SignalRService {
  private hubConnection: signalR.HubConnection | null = null;
  private updateSubject = new Subject<string>();
  public updates$: Observable<string> = this.updateSubject.asObservable();

  private readonly hubUrl = 'http://localhost:5067/dashboardHub';

  startConnection(): void {
    if (this.hubConnection) return;

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.hubUrl)
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('connection success'))
      .catch(err => console.error('error:', err));

    this.hubConnection.on('ReceiveUpdate', (data: string) => {
      console.log('updates:', data);
      this.updateSubject.next(data);
    });
  }

  stopConnection(): void {
    if (this.hubConnection) {
      this.hubConnection.stop();
      this.hubConnection = null;
    }
  }
}
