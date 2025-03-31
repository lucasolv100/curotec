import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SignalRService } from '../services/signalr.service';
import { DashboardComponent } from './dashboard.component';

@Component({
  selector: 'app-root',
  imports: [DashboardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  title = "test"
  constructor(private signalR: SignalRService) {}

  ngOnInit() {
    this.signalR.startConnection();
  }
}
