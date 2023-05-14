function GenerateScatterChart(data) {


    data.forEach((item) => {
        item.line = { shape: 'spline' }
    });


    var layout = {
        title: 'Grades evolution',
        yaxis: {
            range: [0, 10.5]
        },
    };

    Plotly.newPlot('scatter', data, layout);
}