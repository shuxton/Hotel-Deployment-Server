import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { increment,decrement, selectOrderedItemList } from "./menuSlice";
import {
  Button,
  Card,
  Icon,
  Image,
  Label,
  LabelGroup,
} from "semantic-ui-react";

export default function MenuItem({ item,index }) {
    const orderedItemList = useSelector(selectOrderedItemList)
    const dispatch = useDispatch()
    console.log(item,orderedItemList)
    
  return (
    <Card centered>
      <br />
      <Card.Header
        as="h1"
        style={{ fontWeight: "bolder" }}
        content={item.name}
      />
      <LabelGroup>
        <Label content={`Price ₹${item.price}`} color="violet" />
      </LabelGroup>

      <Image
        src={"https://i.imgur.com/FbDgRSw.jpeg"}
        style={{ width: "200px" }}
        centered
        spaced
        bordered
      />
      <Card.Description as="h4" content={item.description} />
      <br />

      <LabelGroup>
        <Label
          content="Discount ₹100"
          color="yellow"
          tag
          attached="top right"
        />
        <Label
          content={item.isVeg ? "Veg" : "Non Veg"}
          attached="top left"
          color={item.isVeg ? "green" : "red"}
        />
        <Label
          content={`Added to cart (x${orderedItemList[item.id]?orderedItemList[item.id] : 0})`}
          circular
          size="large"
          color="teal"
        />
      </LabelGroup>
      <div>
       
        <Button animated icon inverted color="red" floated="left" onClick={()=>{dispatch(decrement(item.id))}}>
        <Button.Content visible>
            <Icon name="minus" />
          </Button.Content>
          <Button.Content  hidden>
            <Icon name="minus" />
          </Button.Content>
        </Button>
        
        <Button animated icon inverted color="green" floated="right" onClick={()=>{dispatch(increment(item.id))}}>
        <Button.Content   visible>
            <Icon name="plus" />
          </Button.Content>
          <Button.Content   hidden>
            <Icon name="plus" />
          </Button.Content>
        </Button>
      </div>
    </Card>
  );
}
