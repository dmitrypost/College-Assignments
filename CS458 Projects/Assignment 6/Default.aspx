<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_6.Resources.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SlickGrid example 1: Basic grid</title>
    <link href="Resources/slick.grid.css" rel="stylesheet" />
    <link href="Resources/css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <script src="Resources/lib/jquery-1.7.min.js"></script>
    <link href="Resources/slick.pager.css" rel="stylesheet" />
    <script src="Resources/lib/jquery.event.drag-2.2.js"></script>
    <script src="Resources/slick.core.js"></script>
    <script src="Resources/slick.grid.js"></script>
    <script src="Resources/slick.dataview.js"></script>
    <script src="Resources/slick.remotemodel.js"></script>
    <script src="Resources/slick.formatters.js"></script>
    <script src="Resources/slick.editors.js"></script>
    <script src="Resources/slick.pager.js"></script>
    <script src="Resources/Slick.RowSelectionModel.js"></script>
    <link href="Resources/Main.css" rel="stylesheet" />
    <script src="Populate%20Courses%20Taken.js"></script>
    <script src="Populate%20Students.js"></script>
    <script>
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <div id="Debugtxt"></div>
        <div>
            test
         
        </div>
        <div id="inlineFilterPanel" style=" background: #dddddd; padding: 3px; color: black;">
            Filter by last name
            <input type="text" id="txtSearch"/>
        </div>

        <table style="width: 1200px;">
            <tr>
                <td>
                    <div id="StudentsGrid" style="width:600px;height:500px;"></div>
                    <div id="StudentPager" style="width:100%;height:20px;"></div>
                </td>

                <td>
                    <div id="CoursesGrid" style="width:600px;height:500px;"></div>
                    <div id="CoursesPager" style="width:100%;height:20px;"></div>
                </td>
          
            </tr>
            
            
        </table>
     
    </form>
</body>
</html>
