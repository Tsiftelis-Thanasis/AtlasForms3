@Modeltype AtlasForms3.Newteam
@Code
    ViewData("Title") = "εγγραφες ομαδων"
End Code
<h2>@ViewBag.Title</h2>
<hr />

@Using (Html.BeginForm("Index", "Newteam", FormMethod.Post, New With {.role = "form"}))
    @Html.AntiForgeryToken()
    @Html.Hidden("userisadmin", User.IsInRole("Admins"))

    @<div id="container">
        <table id="dmdocumentstable">
            <thead>
                <tr>
                    <th>Επιλογές</th>
                    <th>Όνομα</th>
                    <th>Ημερομηνία εγγραφής</th>                    
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>

    @<input type="hidden" id="rowid" name="rowid" />
    @<input type="submit" id="Edit" name="Edit" value="Edit" class="hidden" />

    @<div id="dialog" title="Confirmation Required" style="display:none;">
        <span>Are you sure about this?</span>
    </div>

End Using

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
            "sAjaxSource": baseUrl + '@Url.Action("GetNewteams")',
            "contentType": "application/json; charset=utf-8",
            "language": { "url": baseUrl + "/Scripts/DataTables/Greek.json" },
            "bProcessing": true,
            "aoColumns": [
                          {},
                          { "mData": "name" },                          
                          { "mData": "date", "sType": "date" },
            ],            
            "columnDefs": [
                    {
                        "targets": 0,
                        "render": function (data, type, row) {
                            if (row === undefined || row === null) return '';

                                var btnEdit = '<a href="@Url.Action("Delete", "Newteam")/' + row.id + '"><i class="fa fa-pencil-square-o fa-fw"></i>Σβήσιμο της εγγραφής</a>'
                                var btnDetails = '<a href="@Url.Action("Details", "Newteam")/' + row.id + '"><i class="fa fa-pencil-square-o fa-fw"></i>Προβολή της εγγραφής</a>'
                                var DropDownAction = '<div class="btn-group">' +
                                                '<button type="button" class="btn btn-warning btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
                                                '<i class="fa fa-gear"></i><span class="caret"></span>' +
                                                '</button>' +
                                                '<ul class="dropdown-menu">'
                                if ($("#userisadmin").val() == "True") { DropDownAction += '<li>' + btnEdit + '</li>'; }
                                DropDownAction += '<li>' + btnDetails + '</li>';
                                DropDownAction += '</ul></div>';

                                return DropDownAction;
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