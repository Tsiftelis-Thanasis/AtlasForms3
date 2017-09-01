@ModelType IEnumerable(Of AtlasForms3.Posts)
@Code


End Code

<div id="main-content" Class="style1">

    <div Class="wrapper">
        <div Class="content-wrap">
            <div Class="row">
                @*<div Class="kopa-main-col">*@
                                       
                    <div id="divcommon" Class="widget-area-2">
                        <div Class="widget kopa-article-list-widget article-list-1">
                            <h3 Class="widget-title style2">ολα τα αρθρα</h3>
                            <table id="newstable">
                                <thead>
                                    <tr>
                                        <th>Άρθρο</th>
                                        <th>Κατηγορία</th>
                                        <th>Όμιλος (στατιστικά)</th>
                                        <th>Κατηγορία (στατιστικά)</th>
                                        <th>Active</th>
                                        <th>Αλλαγή απο</th>
                                        <th>Ημερομηνία</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                             </table>
                        </div>
                    </div>
                </div>
                
                <div Class="sidebar widget-area-11">

                    <div Class="widget kopa-ads-widget">
                        <a href="http://www.blue-ice.gr/"> <img src="~/Content/images/blueiceok.png" alt=""></a>
                    </div>

                    <div Class="widget kopa-ads-widget">
                        <a href="https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"> <img src="~/Content/images/risko.jpg" alt=""></a>
                    </div>

                    <div Class="widget kopa-ads-widget">
                        <a href="http://www.atlassportswear.gr/"> <img src="~/Content/images/atlassportwear.png" alt=""></a>
                    </div>
                
                </div>
                
            </div>
            <!-- row -->

        </div>
        <!-- content-wrap -->


    </div>
    <!-- wrapper -->

@*</div>*@
<!-- main-content -->




@Section Scripts
    <Script type="text/javascript" language="javascript">
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
            "aoColumns": [
                          {},
                          { "mData": "KathgoriaName" },     
                          { "mData": "AtlasOmilos" },  
                          { "mData": "AtlasKathgoria" },
                          { "mData": "ActivePost" },
                          { "mData": "editBy"},
                          { "mData": "editDate", "sType": "date-uk" },
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
