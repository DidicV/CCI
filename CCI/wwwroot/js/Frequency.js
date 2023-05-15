function GenerateFrequencyChart(grades) {



    // Create an array to store the frequency of each grade
    var frequency = new Array(11).fill(0);

    // Count the frequency of each grade
    grades.forEach(function (grade) {
        frequency[grade]++;
    });

    var trace = {
        x: Array.from({ length: 10 }, (_, i) => i + 1),
        y: frequency.slice(1),
        type: 'bar'
    };

    var layout = {
        title: 'Histogram with Frequency',
        xaxis: { title: 'Grade' },
        yaxis: { title: 'Frequency' }
    };

    var data = [trace];

    Plotly.newPlot('frequency', data, layout);


}