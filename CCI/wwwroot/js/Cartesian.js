function GenerateCartesianChart(mediaX, mediaY, students, titleX, titleY) {

    var trace1 = {
        x: mediaX,
        y: mediaY,
        mode: 'markers',
        type: 'scatter',
        text: students
    };

    var data = [trace1];

    var layout = {
        xaxis: {
            rangemode: 'tozero',
            range: [0, 10],
            title: titleX
        },
        yaxis: {
            rangemode: 'tozero',
            range: [0, 10],
            title: titleY
        },
        title: 'Union of two disciplines'
    };

    Plotly.newPlot('cartesian', data, layout);
}