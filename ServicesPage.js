import React from 'react'

export default function ServicesPage() {

    function Get() {

        fetch('https://localhost:7025/api/User')
        .then(response => response.json())
        .then(data => {setdata(data);console.log(data);})
        
      }

      return (
        <div>
        {data.map(function(player){
          return(
          <Card
          get = {Get}
          />
        
          )
        }
      )
      
    }
    </div>
    )}
