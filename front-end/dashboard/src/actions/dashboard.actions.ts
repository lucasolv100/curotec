import { createAction, props } from '@ngrx/store';

export const receiveUpdate = createAction('[Dashboard] Receive Update', props<{ data: string }>());