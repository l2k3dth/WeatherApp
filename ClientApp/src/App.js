import React, { useState, useEffect } from 'react';
import Error from './components/ErrorMessage';
import { Container, Row, Col } from 'react-bootstrap';
import Weather from './components/Weather';
import './App.css';
import LocationSearch from './components/LocationInput';
import LoaderComponent from './components/loader';
import styled from 'styled-components';


const ContentContainer = styled(Container)`
margin-top: 5%;
`;

function App() {

    const [data, setData] = useState({});
    const [isLoading, setIsloading] = useState(false);
    const [isError, setIsError] = useState(false);
    const [location, setLocation] = useState('');

    const updateLocation = (value) => {
        setLocation(value);
        setIsDirty(true);
    }

    const [isDirty, setIsDirty] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            if (location !== '') {

                setIsloading(true);
                setIsDirty(true);

                await fetch('weather?location=' + location)
                    .then(async (response) => {
                        setIsError(false);
                        setData(await response.json());
                        setIsloading(false);

                    }).catch(() => {
                        setIsError(true);
                        setIsloading(false);
                    });
            }
        }
        fetchData();
    }, [location]);

    const renderContent = () => {

        if (isError)
            return <Error ErrorMessage={"There was an error with the request"} />;

        if (data.status === 400)
            return <Error ErrorMessage={data.Errors[0].location} />;

        if (isDirty && location === '')
            return <Error ErrorMessage={"Please enter a location"} />;

        if (data.status === 404)
            return <Error ErrorMessage={data.hasOwnProperty("message") ? data.message : "Please enter a location"} />;

        if (data.status === 200)
            return <Weather weatherData={data} />;
    };

    return (
        <ContentContainer>
            <Row>
                <Col><LocationSearch handler={updateLocation} /></Col>
            </Row>
            <Row>
                {isLoading ? <LoaderComponent /> : renderContent()}
            </Row>
        </ContentContainer>
    );
};


export default App;