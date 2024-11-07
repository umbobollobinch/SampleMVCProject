function insert_text(targetId, text, where) {
    var loc_tag = document.getElementById(targetId);
    loc_tag.insertAdjacentHTML(where, text);
}

function insert_element(targetId, elem, where, id = null) {
    var target = document.getElementById(targetId);
    var tag = document.createElement(elem);
    if (id != null) {
        tag.id = id
    }

    // switch must need "break"; - If you forget a break then the script will run from the case where the criterion is met 
    // and will run the cases after that regardless if a criterion was met. - (from MDN Web Docs)
    // so the lack of "break" causes execution of "default" case.
    switch (where) {
        case "before":
            target.before(tag);
            break;
        case "after":
            target.after(tag);
            break;
        case "add-first":
            target.insertBefore(tag, target.firstChild);
            break;
        case "add-last":
            target.appendChild(tag);
            break;
        default:
            target.appendChild(tag);
    }
    return tag
}

function show_chart(t_id, e_result) {
    let te = document.getElementById(t_id);
    let new_chart = document.createElement("canvas");
    new_chart.id = "chart01";
    new_chart.width = 400;
    new_chart.height = 300;

    var colona_chart = new Chart(new_chart, {
        type: "line",
        data: {
            datasets: [{
                label: "number of patients",
                data: e_result
            }]
        },
        options: {
            parsing: {
                xAxisKey: 'date',
                yAxisKey: 'num'
            },
            responsive: false
        }
    });

    te.before(new_chart);
}