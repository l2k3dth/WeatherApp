import React, { useState } from 'react';
import styled from 'styled-components';

const SearchTerm = styled.input`
  text-align: center;
  width: 100%;
  padding: 5px;
  height: 40px;
  outline: none;
  color: #ffffff;
  background:none;
  border-style: unset;
  border-bottom: 1px solid #00B4CC;
margin-left: 9%;
::placeholder {
color: #ffffff;
  opacity: 1; /* Firefox */
}
:focus::placeholder {
  color: transparent;
}
    `;

const Search = styled.div`
width: 100%;
  position: relative;
  display: flex;
    `;


const SearchButton = styled.button`
  margin-left:5%;
  background: #3d4458;
  text-align: center;
  color:white;
  cursor: pointer;
border-style: double;
  box-shadow: 0 4px 8px 0 rgb(0 0 0 / 30%);
  :active{
   background:#000000;
    box-shadow: none;
  color: #ffffff;

};
:hover{
 box-shadow: 0 8px 8px 0 rgb(0 0 0 / 70%);
color: #ffffff;
}
`;

const SearchIcon = styled.i`
    width: 40px;
`;

const submit = (value, handler, setState) => {
    setState('');
    handler(value);
}

const LocationSearch = ({ handler }) => {

    const [location, setLocation] = useState('');

    return (
            <Search>
            <SearchTerm type="text" value={location} id="location-input" placeholder="Enter Location" onChange={(e) => setLocation(e.target.value)} key="search location" />
            <SearchButton type="submit" id="search-button" onClick={() => submit(location, handler, setLocation)}><span> <SearchIcon className="fa fa-search"></SearchIcon> </span>

                </SearchButton>
            </Search>
    );
}

export default LocationSearch;

