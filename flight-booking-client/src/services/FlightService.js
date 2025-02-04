import axios from "axios";

const API_URL = "http://localhost:5056/flights";

export const getFlights = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error("Error while fetching flights", error);
    return [];
  }
};
