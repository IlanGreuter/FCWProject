import { useEffect, useState } from 'react';
import './App.css';
import Graph from './graph';
import _ from 'lodash';

function App() {
    const [data, setData] = useState();

    const hasData = _.size(data) > 0;
    useEffect(() => {
        const interval = setInterval(async () => {
            const response = await fetch('data');
            if (response.ok) {
                const responseData = await response.json();
                setData(responseData);
            }
        }, 5000);

        return () => clearInterval(interval);
    }, []);

    console.log((data || []).map(d => d.value));
    return (
        <div className="content">
            {hasData && <>
                <h2>Latest data:</h2>
                <h1 style={data[0].value >= 90 ? { color: 'red' } : null}>{data[0].value}</h1>
                <p>Last updated: {data[0].timestamp}</p>
                <Graph points={data} />
            </>}
            {!hasData && <p>Loading... Please wait...</p>}
        </div>
    );
}

export default App;