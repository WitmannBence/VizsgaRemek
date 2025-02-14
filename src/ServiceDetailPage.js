import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

function ServiceDetailPage(params) {

  const {id} = useParams()

  const [service, setService] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Ensure the ID is present
  useEffect(() => {
    if (!id) {
      setError("Service ID not found");
      setLoading(false);
      return;
    }

    setLoading(true); // Start loading
    setError(null); // Reset any previous error state

    // Fetch the service details by ID from the backend
    fetch(`http://localhost:5293/api/Service/ServiceBySERVICEID/`+id)
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to fetch data");
        }
        return response.json();
      })
      .then((data) => {
        console.log("Fetched service data:", data);
        setService(data); // Store the service data
        setLoading(false); // Set loading to false once the data is fetched
      })
      .catch((error) => {
        console.error("Error fetching service details:", error);
        setError(error.message); // Set the error state
        setLoading(false); // Set loading to false in case of an error
      });
  }, [id]);

  // If loading, display loading message
  if (loading) {
    return <div>Loading...</div>;
  }

  // If there's an error, display error message
  if (error) {
    return <div>Error: {error}</div>;
  }

  // If service data is available, render the details
  return (
    <div className="service-detail-page" style={{ width: "50rem", margin: "0 auto" }}>
      <div className="card" style={{ width: "100%" }}>
        <img className="card-img-top" src="..." alt="Service Image" />
        <div className="card-body">
          <h1 className="card-title">{service?.serviceName || "Service Name"}</h1>
          <p><strong>Description:</strong> {service?.description || "No description available"}</p>
          <p><strong>Category:</strong> {service?.category || "No category available"}</p>
          <p><strong>Time Cost:</strong> {service?.timeCost || "N/A"}</p>
          <p><strong>Created At:</strong> {new Date(service?.createdAt).toLocaleString() || "N/A"}</p>
          <h3>Additional Information:</h3>
          <p>{service?.additionalInfo || "No additional info available"}</p>
        </div>
      </div>
    </div>
  );
}

export default ServiceDetailPage;
