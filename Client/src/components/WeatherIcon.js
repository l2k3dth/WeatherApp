import React from 'react';
import styled from 'styled-components';
import {Container} from "react-bootstrap";



const IconContainer = styled(Container)`
display:flex;
justify-content:center;
padding:20px;
flex: 1 0 25%;
    `;

const Image = styled.img`

`;

const Card = styled.div`
align-items: center;

display:flex;
justify-content:center;
background-color:#9b9b9b42;
height:100px;
width:300px;
box-shadow: 0 4px 8px 0 rgb(0 0 0 / 30%);
    `;
const Subtitle = styled.h2`
font-size:1.5em;
color:#FFFFFF;
margin-right:5px;
    `;
    

const WeatherIcon = ({ icon, description }) => 
        <IconContainer>
            <Card>
                <Image src={"http://openweathermap.org/img/wn/" + icon + "@2x.png"} />
             <Subtitle>{description}</Subtitle> 
             </Card>
            </IconContainer>

export default WeatherIcon;
