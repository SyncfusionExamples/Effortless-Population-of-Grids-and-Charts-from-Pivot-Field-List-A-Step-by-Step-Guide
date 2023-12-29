var fieldlistObj = new ej.pivotview.PivotFieldList({
    dataSourceSettings: {
        url: 'https://localhost:44350/api/pivot/post',
        mode: 'Server',
        type: 'JSON',
        allowMemberFilter: true,
        rows: [{ name: 'Year' }],
        values: [{ name: 'Sold', caption: 'Units Sold' }],
        fieldMapping: [
            { name: 'Sold', type: 'Sum' },
            { name: 'Price', type: 'Sum' },
        ],
    },
    renderMode: 'Fixed',
    afterServiceInvoke: function (args) {
        data = JSON.parse(args.response).data;
        grid.dataSource = data;
        grid.columns = getColumns();
        chart.series[0].dataSource = data;
    }
});
fieldlistObj.appendTo('#PivotFieldList');

var grid = new ej.grids.Grid({
    allowSelection: true,
    allowFiltering: true,
    allowSorting: true,
    filterSettings: { type: 'Menu' },
    selectionSettings: {
        persistSelection: true,
        type: 'Multiple',
        checkboxOnly: true,
    },
    enableHover: false,
    enableHeaderFocus: true,
    height: 250
});
grid.appendTo('#Grid');

var chart = new ej.charts.Chart({
    primaryXAxis: {
        valueType: 'Category',
        labelRotation: 90,
        zoomFactor: 0.1
    },
    chartArea: { border: { width: 0 } },
    primaryYAxis: {
        title: 'Units Sold'
    },
    series: [
        {
            type: 'Column',
            xName: 'productID',
            width: 2,
            yName: 'sold',
            name: 'Sales',
        },
    ],
    zoomSettings: {
        enableScrollbar: true
    },
    title: 'Sales Analysis',
    width: '100%',
    tooltip: { enable: true, shared: true },
    legendSettings: { enableHighlight: true },
});
chart.appendTo('#Chart');

function getColumns() {
    var report = {};
    report[0] = fieldlistObj.dataSourceSettings.rows;
    report[1] = fieldlistObj.dataSourceSettings.columns;
    report[2] = fieldlistObj.dataSourceSettings.values;
    report[3] = fieldlistObj.dataSourceSettings.filters;
    var pos = 0;
    var columns = [];
    while (pos < 4) {
        if (report[pos]) {
            for (var cnt = 0; cnt < report[pos].length; cnt++) {
                var field = report[pos][cnt];
                var column = {
                    field: field.name,
                    headerText: field.caption ? field.caption : field.name,
                    width: 150,
                    textAlign: 'Center',
                };
                columns.push(column);
            }
        }
        pos++;
    }
    return columns;
}