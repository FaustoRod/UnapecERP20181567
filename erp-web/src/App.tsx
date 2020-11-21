import React, { Fragment } from "react";
import logo from "./logo.svg";
import "./App.css";
import { NavBar } from "./features/navbar/NavBar";
import { Button, Container } from "semantic-ui-react";
import { ConceptoPagoForm } from "./features/concepto_pago/ConceptoPagoForm";

function App() {
  return (
    <Container fluid>
      <Fragment>
        <NavBar />
        <Container style={{marginTop: "5em"}}>
          <ConceptoPagoForm />
        </Container>
      </Fragment>
    </Container>
  );
}

export default App;
