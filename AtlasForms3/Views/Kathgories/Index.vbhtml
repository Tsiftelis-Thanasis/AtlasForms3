@ModelType AtlasForms3.Kathgories
@Code
    ViewData("Title") = "Κατηγοριες"
End Code
<h2>@ViewBag.Title</h2>
<hr />


<p> Θα πρέπει να γινεται επικοινωνία! 
    @Html.ActionLink("Δημιουργία νεας Κατηγορίας", "Create")
</p>

@Using (Html.BeginForm("Index", "Kathgories", FormMethod.Post, New With {.role = "form"}))
    @Html.AntiForgeryToken()

    @<div id="container">
        <table id="kathgoriesdatatable">
            <thead>
                <tr>
                    <th>Επιλογές</th>
                    <th>Κατηγορία</th>
                    <th>Ενεργή</th>
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
        

        $('#kathgoriesdatatable').DataTable({
            "sAjaxSource": baseUrl + '@Url.Action("GetKathgoriesList")',
            "contentType": "application/json; charset=utf-8",
            "language": { "url": baseUrl + "/Scripts/DataTables/Greek.json" },
            "bProcessing": true,
            "aoColumns": [
                          {},
                          { "mData": "KathgoriaName" },
                          { "mData": "ActiveKathgoria" },
            ],
            "columnDefs": [
                    {
                        "targets": 0,
                        "render": function (data, type, row) {
                            if (row === undefined || row === null) return '';

                                var btnEdit = '<a href="@Url.Action("Edit", "Kathgories")/' + row.Kathgoriesid + '"><i class="fa fa-pencil-square-o fa-fw"></i>Αλλαγή της κατηγορίας</a>'
                                var DropDownAction = '<div class="btn-group">' +
                                                '<button type="button" class="btn btn-warning btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
                                                '<i class="fa fa-gear"></i><span class="caret"></span>' +
                                                '</button>' +
                                                '<ul class="dropdown-menu">'
                                DropDownAction += '<li>' + btnEdit + '</li>';
                                DropDownAction += '</ul></div>';

                                return DropDownAction;
                        }

                    }
                ]
            });

        $('#kathgoriesdatatable').on("click", "a[rowid]", function (e) {
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