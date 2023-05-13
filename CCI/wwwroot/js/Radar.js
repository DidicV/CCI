function GenerateRadarChart(grades, disciplines) {

    data = [{
        type: 'scatterpolar',
        r: grades,
        theta: disciplines,
        fill: 'toself'
    }]

    layout = {
        polar: {
            radialaxis: {
                visible: true,
                range: [0, 10]
            }
        },
        width: 650,
        height: 650,
        showlegend: false
    }

    Plotly.newPlot("radar", data, layout)
}