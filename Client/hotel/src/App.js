import React from 'react';
import { Counter } from './features/counter/Counter';
import './App.css';
import Menu from './features/menu/Menu';
import { Container } from 'semantic-ui-react';
import PageHeader from './features/common/PageHeader';

function App() {
  return (
   <Container fluid>
        <Counter />
       <PageHeader/>
       
        <Menu/>
        </Container>
      
  );
}

export default App;
