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
                        color: "#e1e1e1"
                    }
                }
            }
        }
    });
};

