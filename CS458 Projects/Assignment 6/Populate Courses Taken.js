
function SelectedStudent(studentID) {
    $.ajax(
    {
        type: "POST",
        url: "Default.aspx/GetCoursesTaken",
        contentType: "application/json; charset=utf-8",
        data: "{'studentID':'" + studentID + "' }", //get the student id of selected student in other grdCoursesTakenGrid
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


    var CoursesTakenColumns = [

        { id: "Course", name: "Course", field: "CourseID", width: 200, behavior: "select" },
        { id: "Grade", name: "Grade", field: "Grade", width: 200 },
    ];

    var grdCoursesTakenGrid;
    var dvCoursesTakenDataView;
    var ctData;

    function PopulateStudents(results) {
        ctData = JSON.parse(results);
        //create an id for each item in the data...
        
        for (var i = 0; i < ctData.length; i++) {
            //alert(ctData[i].Grade + ctData[i].ID);
            ctData[i].id = i;
            //Do something
        }

        
        dvCoursesTakenDataView = new Slick.Data.DataView();
        
        grdCoursesTakenGrid = new Slick.Grid("#CoursesGrid", dvCoursesTakenDataView, CoursesTakenColumns, options);
        

        // initialize the model after all the events have been hooked up
        dvCoursesTakenDataView.beginUpdate();
        dvCoursesTakenDataView.setItems(ctData);
        dvCoursesTakenDataView.endUpdate();
        var CTpager = new Slick.Controls.Pager(dvCoursesTakenDataView, grdCoursesTakenGrid, $("#CoursesTakenPager"));

        // wire up model events to drive the grdCoursesTakenGrid
        dvCoursesTakenDataView.onRowCountChanged.subscribe(function (e, args) {
            grdCoursesTakenGrid.updateRowCount();
            grdCoursesTakenGrid.render();
        });

        dvCoursesTakenDataView.onRowsChanged.subscribe(function (e, args) {
            grdCoursesTakenGrid.invalidateRows(args.rows);
            grdCoursesTakenGrid.render();
        });

        dvCoursesTakenDataView.onPagingInfoChanged.subscribe(function (e, pagingInfo) {
            var isLastPage = pagingInfo.pageNum == pagingInfo.totalPages - 1;
            var enableAddRow = isLastPage || pagingInfo.pageSize == 0;
            var options = grdCoursesTakenGrid.getOptions();

            if (options.enableAddRow != enableAddRow) {
                grdCoursesTakenGrid.setOptions({ enableAddRow: enableAddRow });
            }
        });

        dvCoursesTakenDataView.setPagingOptions({ pageSize: 200 });


    }
};

