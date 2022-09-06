import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState, AppThunk } from '../../../app/store';

export interface LoggerState {
  value: string;
  status: 'idle' | 'loading' | 'failed';
}

const initialState: LoggerState = {
  value: 'Visitor',
  status: 'idle',
};

export const logger = createSlice({
  name: 'isLogged',
  initialState,
  reducers: {
    logIn: (state) => {
      state.value = 'User';
    },
    logAdmin: (state) => {
      state.value = 'Administrator';
    },
    logEmployee: (state) => {
      state.value = 'Employee';
    },
    logOut: (state) => {
      state.value = 'Visitor';
    },
  }
});

export const { logIn, logAdmin, logEmployee, logOut } = logger.actions;

// The function below is called a selector and allows us to select a value from
// the state. Selectors can also be defined inline where they're used instead of
// in the slice file. For example: `useSelector((state: RootState) => state.counter.value)`
export const selectLogged = (state: RootState) => state.isLogged.value;

// We can also write thunks by hand, which may contain both sync and async logic.
// Here's an example of conditionally dispatching actions based on current state.


export default logger.reducer;
