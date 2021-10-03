import React from 'react';
import styled from 'styled-components';

const Card = styled.div`
        background-color:#4a5e99a1;
        height:100px;
        width:300px;        
        text-align:center;
        color:#ffffff;
        box-shadow: 0 4px 8px 0 rgb(0 0 0 / 30%);
    `;

const Container = styled.div`
    display:flex;
    justify-content:center;
    padding:20px;
    flex: 1 0 25%;
    `;

const Title = styled.h2`
    padding-top:10px;
    `;

const SubTitle = styled.h4`
    `;


const DataTile = ({ title, value }) =>

    <Container>
        <Card>
            <Title>{title}</Title>
            <SubTitle>{value}</SubTitle>
        </Card>
    </Container>

export default DataTile;
