import React, { useState, useEffect } from "react";
import "./App.css";

function App() {
  const [data, setData] = useState([]);

  function Get() {
    fetch("https://localhost:7025/api/Service/AllService")
      .then((response) => response.json())
      .then((data) => {
        setData(data);
        console.log(data);
      });
  }

  useEffect(() => {
    Get();
  }, []);

  return (
    <div className="servicespage">
      {data.map((service) => (
        <Card
          key={service.serviceId}
          serviceName={service.serviceName}
          timeCost={service.timeCost}
          description={service.description}
          category={service.category}
          createdAt={service.createdAt}
        />
      ))}
    </div>
  );
}

function Card({ serviceName, timeCost, description, category, createdAt }) {
  return (
    <div className="card">
      <h2>{serviceName}</h2>
      <p><strong>Description:</strong> {description}</p>
      <p><strong>Category:</strong> {category}</p>
      <p><strong>:</strong> {timeCost} </p>
      <p><strong>Created At:</strong> {new Date(createdAt).toLocaleString()}</p>
    </div>
  );
}

export default App;
