import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SignalRService } from '../services/signalr.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  template: `<div *ngFor="let item of updates$ | async">{{ item }}</div>`,
  imports: [CommonModule]
})
export class DashboardComponent implements OnInit {
  updates$!: Observable<string[]>;
  items = ['Item A', 'Item B', 'Item C'];

  constructor(private store: Store<{ dashboard: string[] }>, private signalR: SignalRService) {}

  ngOnInit() {
    this.signalR.startConnection();
    this.updates$ = this.store.select('dashboard');
    this.updates$.subscribe(val => console.log('Dashboard store subscription:', val));
  }
}