import React from 'react'
import { useState, useEffect } from 'react'
import { getFlights } from './services/flightService'

export default function FlightList() {
    const [flights, setFlights] = useState([])
    useEffect(() => {
        async function fetchFlights() {
            const flights = await getFlights()
            setFlights(flights)
        }
        fetchFlights()
    }, [])
  return (
    <div>
        <h1>Flight List</h1>
        <ul>
            {flights.map(flights => 
            <li key={flights.id}> {flight.airline} → {flight.destination} (${flight.price})</li>
            )}
        </ul>
    </div>
  )
}
