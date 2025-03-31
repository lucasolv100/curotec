// app.config.ts
import { ApplicationConfig } from '@angular/core';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { dashboardReducer } from '../reducers/dashboard.reducer';
import { DashboardEffects } from '../effects/dashboard.effects';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideStore({ dashboard: dashboardReducer }),
    provideEffects([DashboardEffects]),
  ],
};
