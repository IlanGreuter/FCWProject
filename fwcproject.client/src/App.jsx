import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [data, setData] = useState([]);

    useEffect(() => {
        populateData();
    }, []);

    return (
        <div>
            <h1 id="tableLabel">Data View</h1>
            {data && <p>
                data[0].value
            </p>}
            {!data && <p>Loading... Please wait...</p>}
        </div>
    );
    
    async function populateData() {
        const response = await fetch('data');
        if (response.ok) {
            const data = await response.json();
            setData(data);
        }
    }
}

export default App;