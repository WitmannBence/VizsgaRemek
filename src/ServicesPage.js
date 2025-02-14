import React, { useState, useEffect } from "react";
import "./App.css";
import Card from "./Components/Card";

function ServicesPage() {
  const [data, setData] = useState([]);

  function Get() {
    fetch("http://localhost:5293/api/Service/AllService")
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
    <div className="servicespage full-screen">
      {data.map((service) => (
        <Card
          key={service.serviceId}
          serviceId={service.serviceId} // Pass serviceId to Card
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

export default ServicesPage;
