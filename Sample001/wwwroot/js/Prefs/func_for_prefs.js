function setup_head(dtitles) {
    var tr_for_th = insert_element("t-base01", "tr", "add-last", "tr0");
    tr_for_th.classList.add("columns");
    dtitles.forEach((title, index) => {
        // Labels
        var lb = insert_element("btn-zone", "label", "add-last", "lb-" + index);
        lb.textContent = title;
        // checkbuttons
        var cb = insert_element(lb.id, "input", "add-first", "cb-" + index);
        cb.type = "checkbox";
        cb.checked = "checked";
        cb.classList.add("cb_elems");

        // table-headers
        var th = insert_element(tr_for_th.id, "th", "add-last");
        th.append(title);
        th.classList.add("elems");
    });
    var ptag = insert_element("btn-zone", "p", "add-last", "p0");
    var submit_button = insert_element(ptag.id, "input", "add-last", "change_table");
    submit_button.type = "button";
    submit_button.value = "表示列変更";
    submit_button.onclick = select_row;
}

function setup_table_values(vals) {
    vals.forEach((column, i) => {
        var tr_for_td = insert_element("tr" + i, "tr", "after", "tr" + (i + 1));
        tr_for_td.classList.add("columns");
        column.forEach((elem, j) => {
            var td = insert_element(tr_for_td.id, "td", "add-last");
            td.append(elem);
            td.classList.add("elems");
        });
    });
}

function select_row() {
    var checkflgs = document.getElementsByClassName("cb_elems");
    var tablecolumns = document.getElementsByClassName("columns");

    [...tablecolumns].forEach(column => {
        var tableelems = column.getElementsByClassName("elems");
        [...tableelems].forEach((elems, index) => {
            checkflgs[index].checked ? elems.style.display = "table-cell" : elems.style.display = "none";
        });
    });
}