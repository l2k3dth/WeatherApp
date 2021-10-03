import React from 'react';
import { Container, Row, Col } from "react-bootstrap";
import DataTile from './DataTile';
import WeatherIcon from './WeatherIcon';
import styled from 'styled-components';

const WeatherContainer = styled(Container)`
    top:20%;
    display:flex;
    flex-wrap:wrap;
    justify-content:space-around;
    `;


const LocationTitle = styled.h1`
    font-size:4.4em;
    color:white;
    `;

const formatDate = (timestamp) => {
    let date = new Date(timestamp * 1000);
    return `${date.getHours()}:${String(date.getMinutes()).padStart(2, "0")}`;
};

const Weather = ({ weatherData }) =>

    <WeatherContainer fluid="md">
        <Row>
            <Col><LocationTitle id="location-title">{weatherData.location}</LocationTitle></Col>
        </Row>
        <Row>
            <Col><WeatherIcon icon={weatherData.icon} description={weatherData.description} /></Col>
            <Col><DataTile title={"Temp"} value={`${weatherData.temprature.current}${String.fromCharCode(8451)}`} /></Col>
            <Col><DataTile title={"Temp Max"} value={`${weatherData.temprature.maximum}${String.fromCharCode(8451)}`} /></Col>
            <Col><DataTile title={"TempMin"} value={`${weatherData.temprature.minimum}${String.fromCharCode(8451)}`} /></Col>
            <Col><DataTile title={"Pressure"} value={`${Math.round(weatherData.pressure)}`} /></Col>
            <Col><DataTile title={"Humidity"} value={`${Math.round(weatherData.humidity)}`} /></Col>
            <Col><DataTile title={"Sunrise"} value={formatDate(weatherData.sunrise)} /></Col>
            <Col><DataTile title={"Sunset"} value={formatDate(weatherData.sunset)} /></Col>
        </Row>
    </WeatherContainer>

export default Weather;
