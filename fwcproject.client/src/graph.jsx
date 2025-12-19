import './graph.css';
import _ from 'lodash';

function graph({ points }) {
    if (!_.isArray(points)) return;

    const numPoints = 10;
    const widthUnit = 300 / numPoints;
    const fullHeight = 200;

    const coords = points.map((pt, index) => {
        return {
            x: ((numPoints - 1) - index) * widthUnit,
            y: fullHeight - (pt.value * 2),
            color: pt.value >= 90 ? "red" : "white"
        }
    });

    return <div className="graphContainer">
        <svg width={300} height={200}>
            <line x1="0" x2="300" y1={fullHeight * 0.1} y2={fullHeight * 0.1} stroke="red" />
            <line x1="0" x2="300" y1={fullHeight * 0.25} y2={fullHeight * 0.25} stroke="gray" />
            <line x1="0" x2="300" y1={fullHeight * 0.5} y2={fullHeight * 0.5} stroke="gray" />
            <line x1="0" x2="300" y1={fullHeight * 0.75} y2={fullHeight * 0.75} stroke="gray" />
            {<polyline points={coords.map(coord => `${coord.x},${coord.y}`).join(" ")} stroke="white" fill="none" />}
            {coords.map((coord) => {
                return <circle cx={coord.x} cy={coord.y} r="4" fill={coord.color} />
            })};
        </svg>
    </div>;
}

export default graph;