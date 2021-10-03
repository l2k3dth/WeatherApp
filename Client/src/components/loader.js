import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import styled, { keyframes } from 'styled-components';


const LoaderContainer = styled.div`
margin-top:5%;
width:100%;
  display: flex;
justify-content:center;
`;

const loaderAnimation = keyframes`
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
`;

const Loader = styled.div`

    border: 16px solid #f3f3f3;
    border-radius: 50%;
    border-top: 16px solid #3498db;
    width: 120px;
    height: 120px;
    -webkit-animation: spin 2s linear infinite; /* Safari */
    animation: ${loaderAnimation} 2s linear infinite;
`;

const LoaderComponent = () =>
    <Container>
        <Row>
            <Col>
                <LoaderContainer>
                    <Loader />
                </LoaderContainer>
            </Col>
        </Row>

    </Container>


export default LoaderComponent;