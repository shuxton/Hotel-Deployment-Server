import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import {Grid, Segment,Label} from 'semantic-ui-react'
import MenuItem from './MenuItem';
import {getMenuItem, initialise} from './menuSlice'

export default function Menu(){
  const dispatch = useDispatch()
  const [itemList,setItemList] = useState([]);
  
  useEffect(()=>{
dispatch(getMenuItem()).then((item)=>{
  setItemList(Object.values(item.payload))
    dispatch(initialise(item.payload))
  });
  },[dispatch])
    return(
      <Segment textAlign="center">
      <Label attached="top" color="teal" content={ "Menu"}/>
      <Grid stackable stretched columns={3}>
        {itemList.map((item,index) => ( 
          <Grid.Column key={item.id} textAlign='center'>
          <MenuItem key={item.id} index={index} item={item} />
          </Grid.Column>
        ))}
      </Grid>
      </Segment>
    )
}