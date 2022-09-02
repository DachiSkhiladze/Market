import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState, AppThunk } from '../../app/store';

export interface CounterState {
  value: boolean;
  status: 'idle' | 'loading' | 'failed';
}

const initialState: CounterState = {
  value: true,
  status: 'idle',
};

export const counterSlice = createSlice({
  name: 'isLoading',
  initialState,
  reducers: {
    increment: (state) => {
      state.value = true;
    },
    decrement: (state) => {
      state.value = false;
    },
    incrementByAmount: (state, action: PayloadAction<boolean>) => {
      state.value = action.payload;
    },
  }
});

export const { increment, decrement, incrementByAmount } = counterSlice.actions;

// The function below is called a selector and allows us to select a value from
// the state. Selectors can also be defined inline where they're used instead of
// in the slice file. For example: `useSelector((state: RootState) => state.counter.value)`
export const selectLoad = (state: RootState) => state.isLoading.value;

// We can also write thunks by hand, which may contain both sync and async logic.
// Here's an example of conditionally dispatching actions based on current state.


export default counterSlice.reducer;
