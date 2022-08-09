import { IconButton, TextField } from '@mui/material';
import SearchIcon from "@mui/icons-material/Search";
import axios from 'axios';
import { CurrentResponse } from 'openweathermap-ts/dist/types';
import React, { useState } from 'react';
import './App.css';
import { useEffect } from 'react';

const WEATHER_BASE_URL = "https://api.openweathermap.org/data/2.5/weather?units=metric&q="

function App() {
  const [input, setInput] = useState("");
  const [searched, setSearched] = useState<string>("Try out Auckland or hamilton,nz to start with :)");
  const [weather, setWeather] = useState<CurrentResponse | undefined>(undefined);

  // the process.env sometimes die off. 
  // This ensures we get it once and no longer depend on it.
  const [apiKey, setApiKey] = useState("");
  useEffect(() => {
    setApiKey(process.env.REACT_APP_WEATHER_API_KEY!);
  }, [])

  const search = async () => {
    setSearched("Searching...");
    await axios.get(`${WEATHER_BASE_URL}${input}&appid=${apiKey}`).then(res => setWeather(res.data));
    setSearched("Search failed. Maybe try another name?");
  };

  return (
    <div className="container d-flex flex-column" style={{marginTop: "100px"}}>
      <h1 style={{textAlign: "center"}}>
        Weather Search
      </h1>
      <div 
          style={{textAlign: "center"}}>
        <TextField
          id="search-bar"
          className="text my-3"
          value={input}
          onChange={(prop: any) => {
            setInput(prop.target.value);
          }}
          label="Enter a city Name..."
          variant="outlined"
          placeholder="Search... maybe Auckland?"
          size="small"
        />
        <IconButton
          aria-label="search"
          onClick={search}
        >
          <SearchIcon style={{ fill: "blue" }} />
        </IconButton>
      </div>
      {weather === undefined ? 
        <p style={{textAlign: "center"}}>
          {searched}
        </p> : <div className="card" style={{position: "relative", minHeight: "180px"}}>
          <h3 className="card-header">{weather.name}, {weather.sys.country}</h3>
          <div className="card-body d-flex flex-row justify-content-between"> 
          <div>
            <h5 className="card-title mb-1">{weather.main.temp}&deg;C</h5>
            <h6 className="card-subtitle mb-2 text-muted">
              Feels like {weather.main.feels_like}&deg;C
              <br/>
              {weather.main.temp_min}&deg;~{weather.main.temp_max}&deg;
            </h6>
            <hr />
            <b>Humidity: {weather.main.humidity}%</b>
          </div>
          {weather.weather.length > 0 && <div style={{textAlign: "center"}}>
            <img alt="" src={`http://openweathermap.org/img/wn/${weather.weather[0].icon}@2x.png`} width="100px"/>
            <br/>
            <b>{weather.weather[0].main}</b>
          </div>}
          </div>
        </div>
      }
    </div>
  );
}

export default App;
