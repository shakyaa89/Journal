//window.renderMoodChart = (canvasId, labels, values, type) => {
//    const ctx = document.getElementById(canvasId);
//    if (!ctx) return;

//    if (ctx.chart) {
//        ctx.chart.destroy();
//    }

//    ctx.chart = new Chart(ctx, {
//        type: "pie",
//        data: {
//            labels: labels,
//            datasets: [{
//                data: values
//            }]
//        },
//        options: {
//            responsive: true,
//            maintainAspectRatio: false
//        }
//    });
//};



window.renderMoodChart = (canvasId, labels, values, type) => {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    if (ctx.chart) {
        ctx.chart.destroy();
    }

    ctx.chart = new Chart(ctx, {
        type: "pie",
        data: {
            labels: labels,
            datasets: [{
                data: values,
                backgroundColor: [
                    "#4ade80", 
                    "#eab308",
                    "#ef4444" 
                ]
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    labels: {
                        color: "#898989"
                    }
                }
            }
        }
    });
};

window.renderTagsChart = function (canvasId, labels, values) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    new Chart(canvas, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Tag Usage',
                    data: values,
                    backgroundColor: '#4ade80',
                }
            ]
        },
        options: {
            indexAxis: 'y',
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                x: {
                    beginAtZero: true,
                    ticks: {
                        precision: 0
                    }
                },
                y: {
                    ticks: {
                        autoSkip: false
                    }
                }
            },
            plugins: {
                legend: {
                    display: false
                }
            }
        }
    });
};



window.renderWordCountTrend = (canvasId, labels, values) => {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    if (ctx.chart) {
        ctx.chart.destroy();
    }

    ctx.chart = new Chart(ctx, {
        type: "line",
        data: {
            labels: labels, 
            datasets: [{
                label: "Average words per entry",
                data: values,   
                tension: 0.3,
                fill: false,
                borderWidth: 2,
                pointRadius: 3,
                borderColor: "#4ade80",
                pointBackgroundColor: "#4ade80"
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    labels: {
                        color: "#898989"
                    }
                }
            },
            scales: {
                x: {
                    ticks: {
                        color: "#898989"
                    }
                },
                y: {
                    ticks: {
                        color: "#898989"
                    },
                    beginAtZero: true
                }
            }
        }
    });
};


