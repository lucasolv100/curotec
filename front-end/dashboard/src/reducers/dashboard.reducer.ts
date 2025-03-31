import { createReducer, on } from '@ngrx/store';
import { receiveUpdate } from '../actions/dashboard.actions';

export const initialState: string[] = [];

export const dashboardReducer = createReducer(
  initialState,
  on(receiveUpdate, (state, { data }) => [...state, data])
);