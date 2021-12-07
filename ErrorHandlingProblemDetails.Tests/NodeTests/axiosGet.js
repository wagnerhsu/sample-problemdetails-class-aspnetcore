const axios = require('axios').default;
process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
axios.get("http://localhost:5126/api/companies")
    .then(response=>{
        console.log(response.headers);
        console.log(response.data);
    })
    .catch(err=>
    console.error(err));