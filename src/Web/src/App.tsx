import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios, { AxiosResponse } from 'axios';
import { ProductsAPI } from './env';

function App() {

    useEffect(() => {
        axios.get(`${ProductsAPI}/GetProducts`)
            .then((response: AxiosResponse<any>) => {
            console.log(response.data)
        })
    }, [])

  return (
      <>
          <h1>UI Prototype</h1>
          <p>Communicating with EF ASP.NET Core Microservices.</p>
      </>
  );
}

export default App;
