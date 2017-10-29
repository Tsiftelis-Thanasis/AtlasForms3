@ModelType IEnumerable(Of AtlasForms3.Posts)
@Code


    Dim datatableid As Integer = 0
    If Session("GlobalDataTableId") = 0 Then
        datatableid = 0
    Else
        datatableid = Session("GlobalDataTableId")
    End If

End Code

@Html.Hidden("datatableid", datatableid)

<div id="main-content" Class="style1">

<div Class="wrapper">
    <div Class="content-wrap">
          
        <div Class="row">
                                       
                <div id="divcommon" Class="widget-area-2">
                    <div Class="widget kopa-article-list-widget article-list-1">
                        <h3 Class="widget-title style2">Όλα τα άρθρα</h3>
                        <button id="clicktable">Click me</button>
                        <p  class="entry-categories style-s2">  @Html.ActionLink("Δημιουργία Άρθρου", "Create", "Posts") </p>

                        <table id="newstable">
                            <thead>
                                <tr>
                                    <th>Άρθρο</th>
                                    <th>Κατηγορία</th>
                                    <th>Όμιλος (στατιστικά)</th>
                                    <th>Κατηγορία (στατιστικά)</th>
                                    <th>Active</th>
                                    <th>Ημερομηνία δημιουργίας</th>
                                    <th>Ημερομηνία αλλαγής</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                            </table>
                    </div>
                </div>
            </div>            
        </div>  
    </div>
</div>  





@Section Scripts

<script src="https://cdn.datatables.net/plug-ins/1.10.16/api/fnDisplayRow.js" type="text/javascript"></script>

    <Script type="text/javascript" language="javascript">

        /* post datatable id      */
        function postDTid(id) {

            $("#datatableid").val(id);
            
            $.ajax({
                type: "POST",
                url: baseUrl + '@Url.Action("SetDTRowid", "Home")',
                data: "{id : " + id + "}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                },
                error: function () {
                }
            });
        }


    $(document).ready(function () {
                
        $('#newstable').DataTable({
            "sAjaxSource": baseUrl + '@Url.Action("GetAllthePosts")',           
            "contentType": "application/json; charset=utf-8",
            "language": {
                "url": baseUrl + "/Scripts/DataTables/Greek.json"
            },
            "aLengthMenu": [[10, 20, 50, 100, -1], [10, 20, 50, 100, "All"]],
            "iDisplayLength": 20,
            "bProcessing": true,
            "aaSorting": [],
            "aoColumns": [
                          {},
                          { "mData": "KathgoriaName" },     
                          { "mData": "AtlasOmilos" },  
                          { "mData": "AtlasKathgoria" },
                          { "mData": "ActivePost" },
                          { "mData": "creationDate", "sType": "date-uk" },
                          { "mData": "editDate", "sType": "date-uk" },
            ],
            "columnDefs": [
                    {
                        "targets": 0,
                        "render": function (data, type, row) {
                            if (row === undefined || row === null) return '';

                            //table.row(this).id();

                            var btnDelete = '<a click="postDTid(' + row.id + ');" href="@Url.Action("Delete", "Posts")/' + row.Id + '"><i class="fa fa-pencil-square-o fa-fw"></i>Σβήσιμο του άρθρου</a>'
                            var btnEdit = '<a click="postDTid(' + row.id + ');" href="@Url.Action("Edit", "Posts")/' + row.Id + '"><i class="fa fa-pencil-square-o fa-fw"></i>Προβολή του άρθρου</a>'
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
                               '       <a click="postDTid(' + row.id + ');" href="@Url.Action("Edit", "Posts")/' + row.Id + '"> ' +
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
            ],
            "fnRowCallback": function (nRow, aData, iDataIndex) {                
                $(nRow).attr('id',aData.Id);
            }
        });
      

        $('#newstable').on('click', 'tr', function () {
            //var id = this.id;

            var table = $('#newstable').dataTable();
            //var id = table.row(this).id();
            alert( table.row(this) );

            postDTid(id);
        });

       
      

        //if ($("#datatableid").val() > 0) {
            
        //    table.fnDisplayRow(64);
        //}


        $('#clicktable').on('click', function () {
            alert(64);
            var table = $('#newstable').dataTable();
            table.fnDisplayRow(table.fnGetNodes()[8]);
        });
   
        jQuery.extend(jQuery.fn.dataTableExt.oSort, {
            "date-uk-pre": function (a) {
                var ukDatea = a.split('/');
                return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
            },

            "date-uk-asc": function (a, b) {
                return ((a < b) ? -1 : ((a > b) ? 1 : 0));
            },

            "date-uk-desc": function (a, b) {
                return ((a < b) ? 1 : ((a > b) ? -1 : 0));
            }
        });


    });
    </Script>
End Section
