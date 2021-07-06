import { configureStore } from '@reduxjs/toolkit';
import counterReducer from '../features/counter/counterSlice';
import menuReducer from '../features/menu/menuSlice';

export const store = configureStore({
  reducer: {
    counter: counterReducer,
    menu: menuReducer
  },
});
