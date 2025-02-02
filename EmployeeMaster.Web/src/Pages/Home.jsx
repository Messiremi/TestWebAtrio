import * as variables from '../variables.js';
export default function Home() {
	//get();
  return (
		<div>
			Home here
		</div>
	);
};
 const get = async (event) => {
	 console.log("connecting to "+variables.default.backendUrl+"/Employees/get");
    const res = await fetch(
      variables.default.backendUrl+"/Employees/get"
    );

    const data = await res.json();
    const error = data["status"];
    const message = data["msg"];

    if (error === "false") {
      console.log(error);
    } else {
      console.log(message);
    }
  };