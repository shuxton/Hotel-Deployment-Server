import { createAsyncThunk, createSlice,current } from '@reduxjs/toolkit';
import axios from 'axios';

const initialState = {
 itemList:{},
 orderedItemList:{},
 item:{
  id: '',
  name: '',
  price: 0,
  description: '',
  category: '',
  isVeg: false,
  status: 'idle',
  quantity:0
 }
};


export const getMenuItem = createAsyncThunk(
  'menu/fetchMenu',
  async () => {
    const response = await axios.get("http://localhost:2883/api/menu")
    return response.data;
  }
);

export const menuSlice = createSlice({
  name: 'menu',
  initialState,
  reducers: {
    increment: (state,action)=>{  
      if(state.orderedItemList[action.payload]) state.orderedItemList[action.payload]+=1
      else{
       state.orderedItemList[action.payload] = 1
      }

    },
    decrement: (state,action)=>{  
      if(state.orderedItemList[action.payload]) state.orderedItemList[action.payload]-=1
      else{
       state.orderedItemList[action.payload] = 0
      }    
    },    
    initialise:(state,action)=>{
     for(var key in action.payload){
       state.itemList[action.payload[key].id]=action.payload[key]
     }
     },
  },
 
  extraReducers: (builder) => {
    builder
      .addCase(getMenuItem.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(getMenuItem.fulfilled, (state, action) => {
        state.status = 'idle';
       // state.value += action.payload;
      });
  },
});

export const {increment,initialise,decrement} = menuSlice.actions

export const selectOrderedItemList = (state) => state.menu.orderedItemList
export const selectItemList = (state) => state.menu.itemList

// export const initialiseItems = () => (dispatch, getState) => {
//   const currentValue = selectMenuItem(getState());
//   if (currentValue % 2 === 1) {
//     dispatch(incrementByAmount(amount));
//   }
// };


export default menuSlice.reducer;
