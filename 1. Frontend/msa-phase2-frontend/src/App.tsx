import axios from 'axios';
import { CurrentResponse } from 'openweathermap-ts/dist/types';
import React, { useState } from 'react';
import './App.css';

const WEATHER_BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q="

function App() {
  const [input, setInput] = useState("");
  const [searched, setSearched] = useState<boolean>(false);
  const [weather, setWeather] = useState<CurrentResponse | undefined>(undefined);

  const search = () => {
    axios.get(`${WEATHER_BASE_URL}${input}&appid=${process.env.REACT_APP_WEATHER_API_KEY}`).then(res => setWeather(res.data));
    
    setSearched(true);
  };

  return (
    <div>
      <h1>
        Weather Search
      </h1>
      
      <div>
        <label>City Name</label><br/>
        <input type="text" id="city-name" name="city-name" onChange={e => setInput(e.target.value)}/><br/>
        <button type="submit" onClick={search}>
        Search
        </button>
      </div>
      {weather === undefined ? 
        (searched ? 
          <p>Search failed. Maybe try another name?</p> : 
          <p>Try out Auckland or hamilton,nz to start with :)</p>
        ) : <div>
          {weather.name}, {weather.sys.country}
          <br/>
          Humidity: {weather.main.humidity}%
        </div>
      }
      {searched}
    </div>
  );
}

export default App;
