function GenerateFrequencyChart(grades) {

    var trace = {
        x: grades,
        type: 'histogram',
        histfunc: 'count'
    };

    var layout = {
        title: 'Histogram with Frequency',
        xaxis: { title: 'Value', tickformat: 'd' },
        yaxis: { title: 'Frequency' },
        bargap: 0.1 
    };

    var data = [trace];

    Plotly.newPlot('frequency', data, layout);
}