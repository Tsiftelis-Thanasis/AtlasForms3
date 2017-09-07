@Modeltype AtlasForms3.HomeController
@Code
    ViewData("Title") = "Φωτογραφίες"
End Code
<h2>@ViewBag.Title</h2>
<hr />

    @Html.Hidden("userisadmin", User.IsInRole("Admins"))

    <div id="container">
        <table id="dmdocumentstable">
            <thead>
                <tr>                    
                    <th>Φωτογραφία</th>                    
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>


    <input type="hidden" id="rowid" name="rowid" />
    <input type="submit" id="Edit" name="Edit" value="Edit" class="hidden" />

    <div id="dialog" title="Confirmation Required" style="display:none;">
        <span>Are you sure about this?</span>
    </div>

@Section Scripts
    <script type="text/javascript" language="javascript">
    $(document).ready(function () {

        $('#rowid').val('');

        $("#dialog").dialog({
            autoOpen: false,
            modal: true,
            width: 'auto',
            height: 'auto',
            open: function (event, ui) { $(".ui-dialog-titlebar-close", $(this).parent()).hide(); }
        });

        $('#dmdocumentstable').DataTable({
            "sAjaxSource": baseUrl + '@Url.Action("GetFwtografies")',
            "contentType": "application/json; charset=utf-8",
            "language": { "url": baseUrl + "/Scripts/DataTables/Greek.json" },
            "bProcessing": true,
            "aoColumns": [
                          {},
                          { "mData": row }
            ],
            "columnDefs": [
                    {
                        "targets": 0,
                        "render": function (data, type, row) {
                            if (row === undefined || row === null) return '';

                                 var btnDelete = '<a href="@Url.Action("Delete", "Posts")/' + row.Id + '"><i class="fa fa-pencil-square-o fa-fw"></i>Σβήσιμο του άρθρου</a>'
                            var btnEdit = '<a href="@Url.Action("Edit", "Posts")/' + row.Id + '"><i class="fa fa-pencil-square-o fa-fw"></i>Προβολή του άρθρου</a>'
                            var dd = '<div><div class="btn-group">' +
                                            '<button type="button" class="btn btn-warning btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
                                            '<i class="fa fa-gear"></i><span class="caret"></span>' +
                                            '</button>' +
                                            '<ul class="dropdown-menu">'
                            dd += '<li>' + btnEdit + '</li>';
                            dd += '<li>' + btnDelete + '</li>';
                            dd += '</ul></div>';

                            dd += ' <article class="entry-item"> ' +
                               ' <div class="entry-content"> ' +
                               '   <div class="content-top"> ' +
                               '       <a href="@Url.Action("Edit", "Posts")/' + row.Id + '"> ' +
                               '           <h4 class="entry-title"> <b>' + row.PostTitle + ' </b> </h4> ' +
                               '       </a> ' +
                               '   </div> ' +
                               '   <p>' + row.PostSummary + ' .... </p> ' +
                               ' </div>    ' +
                               ' </a> ' +
                               ' </article> ';



                            return dd;
                        }

                    }
                ]
            });

            $('#dmdocumentstable').on("click", "a[rowid]", function (e) {
                e.preventDefault();
                var action = '';
                var rowid = $(this).attr("rowid");
                var rowText = $(this).attr("rowText");
                var rclass = $(this).attr("class");
                var buttons = {};

                buttons['Cancel'] = function () { $(this).dialog("close"); }
                $("#dialog").dialog('option', 'title', action).dialog('option', 'buttons', buttons).dialog("open").css("font-size", "14px");
                return false;
            });

        });
    </script>
End Section