
$(document).ready(function () {
    $.ajax(
    {
        type: "POST",
        url: "Default.aspx/GetStudents",
        contentType: "application/json; charset=utf-8",
        data: {},
        dataType: "json",
        success: function (response) {
            //<!-- alert(response.d); -->
            PopulateStudents(response.d);
            $("#Debugtxt").innerHTML = response.d;
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
});

var StudentsColumns = [

    { id: "FirstName", name: "First Name", field: "FirstName", width: 200, behavior: "select" },
    { id: "LastName", name: "Last Name", field: "LastName", width: 200 },
    { id: "MiddleInitial", name: "Middle Initial", field: "MiddleInitail", width: 200 },
    { id: "Phone", name: "Phone", field: "Phone", width: 200 },
    { id: "Email", name: "Email", field: "Email", width: 200 },
    { id: "GPA", name: "GPA", field: "GPA", width: 200, }
];

var options = {
    enableCellNavigation: true,
    enableColumnReorder: false
};

var grid;
var dataView;
var data;
var searchString = "";


function toggleFilterRow() {
    grid.setTopPanelVisibility(!grid.getOptions().showTopPanel);
}

function PopulateStudents(results) {
    data = JSON.parse(results);

    //if (IsJsonString(results)) { alert("valid") }
    dataView = new Slick.Data.DataView({ inlineFilters: true });
    grid = new Slick.Grid("#StudentsGrid", dataView, StudentsColumns, options);


    // initialize the model after all the events have been hooked up
    dataView.beginUpdate();
    dataView.setItems(data, "Email");
    dataView.setFilterArgs({
        searchString: searchString
    });

    dataView.endUpdate();
    var pager = new Slick.Controls.Pager(dataView, grid, $("#StudentPager"));

    // move the filter panel defined in a hidden div into grid top panel
    $("#inlineFilterPanel")
        .appendTo(grid.getTopPanel())
        .show();


    // wire up model events to drive the grid
    dataView.onRowCountChanged.subscribe(function (e, args) {
        grid.updateRowCount();
        grid.render();
    });

    dataView.onRowsChanged.subscribe(function (e, args) {
        grid.invalidateRows(args.rows);
        grid.render();
    });

    dataView.onPagingInfoChanged.subscribe(function (e, pagingInfo) {
        var isLastPage = pagingInfo.pageNum == pagingInfo.totalPages - 1;
        var enableAddRow = isLastPage || pagingInfo.pageSize == 0;
        var options = grid.getOptions();

        if (options.enableAddRow != enableAddRow) {
            grid.setOptions({ enableAddRow: enableAddRow });
        }
    });

    // wire up the search textbox to apply the filter to the model
    $("#txtSearch").keyup(function (e) {
        Slick.GlobalEditorLock.cancelCurrentEdit();

        // clear on Esc
        if (e.which == 27) {
            this.value = "";
        }

        searchString = this.value;
        updateFilter();
    });

    function updateFilter() {
        dataView.setFilterArgs({

            searchString: searchString
        });
        dataView.refresh();
    }


    dataView.setPagingOptions({ pageSize: 200 })

    //allows the row to be visible.
    grid.highlightActiveRow = function () {
        var currentCell;
        var $canvas = $(this.getCanvasNode());

        currentCell = this.getActiveCell();

        $canvas.find(".slick-row").removeClass("active");
        if (currentCell) {
            
            $canvas.find(".slick-row[row=" + currentCell.row + "]").addClass("active");
        }
    };

    grid.onActiveCellChanged.subscribe(function () {
        this.highlightActiveRow();
        //will tell ajax to pull the records for this student... and populate the courses taken grid.
        SelectedStudent(grid.getDataItem(grid.getActiveCell().row).Email);
    });
    
    grid.setSelectionModel(new Slick.RowSelectionModel());
};


