import axios from 'axios';
import React, { useState } from 'react';
import './App.css';

const WEATHER_BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q="

function App() {
  const [input, setInput] = useState("");
  const [cityName, setCityName] = useState<string>();
  const apiKey = process.env.REACT_APP_WEATHER_API_KEY;

  return (
    <div>
      <h1>
        Weather Search
      </h1>
      
      <div>
        <label>City Name</label><br/>
        <input type="text" id="city-name" name="city-name" onChange={e => setInput(e.target.value)}/><br/>
        <button onClick={() => {
          setCityName(input);
          console.log(`${WEATHER_BASE_URL}${input}&appid=${apiKey}`);
          axios.get(`${WEATHER_BASE_URL}${input}&appid=${apiKey}`).then(res => console.log(res));
        }}>
        Search
        </button>
      </div>

      {cityName}
    </div>
  );
}

export default App;
