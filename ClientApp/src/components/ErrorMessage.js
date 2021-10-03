import React from "react";
import { Col } from "react-bootstrap";
import styled from 'styled-components';

const Message = styled.h1`
margin-top:5%;
    color:#ffffff;
text-align:center;
`;

const Error = ({ ErrorMessage }) =>
        <Col>
            <Message id="error">{ErrorMessage}</Message>
        </Col>

export default Error;