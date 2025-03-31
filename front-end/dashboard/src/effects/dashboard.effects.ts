import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { SignalRService } from '../services/signalr.service';
import { createEffect } from '@ngrx/effects';
import { receiveUpdate } from '../actions/dashboard.actions';
import { map } from 'rxjs/operators';
import { EMPTY } from 'rxjs';

@Injectable()
export class DashboardEffects {
    listenToUpdates$;
  
    constructor(private signalR: SignalRService) {
      this.listenToUpdates$ = createEffect(() =>
        this.signalR.updates$.pipe(map(data => receiveUpdate({ data })))
      );
    }
  }