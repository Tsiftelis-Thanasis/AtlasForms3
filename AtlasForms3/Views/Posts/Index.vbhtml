@ModelType IEnumerable(Of AtlasForms3.Posts)
@Code

    Dim pdb As New AtlasBlogEntities
    Dim pdb2 As New AtlasStatisticsEntities

    Dim kathgoriaid As Integer = If(ViewBag.Kathgoria Is Nothing, 0, ViewBag.Kathgoria)
    Dim atlaskathgoriaid As Integer = If(ViewBag.AtlasKathgoria Is Nothing, 0, ViewBag.AtlasKathgoria)
    Dim atlaskathgorianame As String = (From k In pdb2.KathgoriesTable
                                        Where k.Id = atlaskathgoriaid
                                        Select k.KathgoriaName).FirstOrDefault

    Dim innerTitle As String = ""

    '1   Διοργανώτρια Αρχή
    '3   Γενικά Νέα
    '6   MVP
    '7   Καλύτερες φάσεις
    '11  Νέα
    '12  Ομάδες
    '13  Τιμωρίες
    '14  Πρόγραμμα
    '15  Βαθμολογίες
    '17  Διαφημίσεις


    If kathgoriaid = 11 Then
        ViewData("Title") = "Τελευταία νέα " '& katName
        innerTitle = "τελευταια νεα " & atlaskathgorianame
    End If
    If kathgoriaid = 12 Then
        ViewData("Title") = "Ομάδες " '& katName
        innerTitle = "ομαδες " '& katName
    End If
    If kathgoriaid = 13 Then
        ViewData("Title") = "Τιμωρίες " '& katName
        innerTitle = "τιμωριες " '& katName
    End If
    If kathgoriaid = 14 Then
        ViewData("Title") = "Πρόγραμμα " '& katName
        innerTitle = "προγραμμα " '& katName
    End If
    If kathgoriaid = 15 Then
        ViewData("Title") = "Βαθμολογία " '& katName
        innerTitle = "βαθμολογια " '& katName
    End If
    If kathgoriaid = 0 Then
        ViewData("Title") = "Λίστα με όλα τα νεα" '& katName
        innerTitle = "Λίστα με όλα τα νεα " '& katName
    End If


    Dim programmaid As Integer = 0

    If atlaskathgoriaid > 0 Then
        programmaid = (From t In pdb.BlogPostandKathgoriaTable
                       Join t2 In pdb.BlogPostsTable On t2.Id Equals t.PostId
                       Where t2.Activepost = True And t.AtlasKathgoriaId = atlaskathgoriaid And t.KathgoriaId = 14
                       Select t.PostId).FirstOrDefault
    End If

    Dim UserisAuthenticated As Integer = If(User.Identity Is Nothing, 0, If(User.Identity.IsAuthenticated, 1, 0))


    Dim oGetTeamsbyKathgoria As New List(Of Object)
    If ViewBag.kathgoria = 12 Then
        oGetTeamsbyKathgoria = ViewBag.GetTeamsbyKathgoriaList
    End If

    Dim oGetWeeklyGamesList = ViewBag.GetWeeklyGamesList


End Code


@Html.Hidden("atlasomilosid", ViewBag.AtlasOmilos)
@Html.Hidden("kathgoriaid", ViewBag.Kathgoria)
@Html.Hidden("atlaskathgoriaid", atlaskathgoriaid)
@Html.Hidden("atlaskathgorianame", atlaskathgorianame)

<div id="main-content" Class="style1">


    @code

        If atlaskathgoriaid > 0 Then
            @<p class="entry-categories style-s"><a href="/Home/Index/?ak=@atlaskathgoriaid">Νέα</a>
    
            @*@If kathgoriaid = 0 Then
                @<a style="background: #ef6018; !important" href="/Posts/Index/?ak=@atlaskathgoriaid"><span style="font-size: 12px; !important">Αναλυτικά όλα τα νέα</span></a>
            Else
                @<a href="/Posts/Index/?ak=@atlaskathgoriaid"><span style="font-size: 12px; !important">Αναλυτικά όλα τα νέα</span></a>
            End If*@

            @If kathgoriaid = 12 Then
                @<a style="background: #ef6018; !important" href = "/Posts/Index/?ak=@atlaskathgoriaid&k=12"><span style="font-size: 12px; !important">Ομαδες</span></a>
            Else
                @<a href="/Posts/Index/?ak=@AtlasKathgoriaid&k=12"><span style="font-size: 12px; !important">Ομαδες</span></a>
            End If

            @If kathgoriaid = 15 Then
                @<a style="background: #ef6018; !important" href = "/Posts/Index/?ak=@atlaskathgoriaid&k=15"><span style="font-size: 12px; !important">Βαθμολογια</span></a>
            Else
                @<a href = "/Posts/Index/?ak=@atlaskathgoriaid&k=15"><span style="font-size: 12px; !important">Βαθμολογια</span></a>
            End If
               
            @If UserisAuthenticated > 0 Then
                If programmaid > 0 Then
                    @If kathgoriaid = 14 Then
                        @<a style = "background: #ef6018; !important" href="/Posts/Details/@programmaid"> <span style="font-size: 12px; !important">Προγραμμα</span></a>
                    Else
                        @<a href="/Posts/Details/@programmaid"> <span style="font-size: 12px; !important">Προγραμμα</span></a>
                    End If
                Else
                    @If kathgoriaid = 14 Then
                        @<a style="background: #ef6018; !important"> <span style="font-size: 12px; !important">Προγραμμα</span></a>
                    Else
                        @<a><span style="font-size: 12px; !important">Προγραμμα</span></a>
                    End If
                End If
            End If

            @If kathgoriaid = 13 Then
               @<a style = "background: #ef6018; !important" href = "/Posts/Index/?ak=@atlaskathgoriaid&k=13"><span style="font-size: 12px; !important">Τιμωριες</span></a>
            Else
               @<a href="/Posts/Index/?ak=@atlaskathgoriaid&k=13"><span style="font-size: 12px; !important">Τιμωριες</span></a> 
            End If
                   
            </p>
        End If

    End Code

    <div Class="wrapper">
        
            
        <section Class="kopa-area kopa-area-1 mb-30" id="divresultsandstandings" style="display: none;">

           
            <div Class="content-wrap">
               
                 @code
                     If atlaskathgoriaid > 0 Then

                           @<div Class="row">
                                 
                        <div id = "divresults1" Class="widget-area-12"  style="display: none;">
                        <div Class="widget kopa-result-widget">
                            <h3 Class="widget-title style6">@atlaskathgorianame - εβδομαδιαια αποτελεσματα</h3>
                            <div Class="widget-content">
                                <div Class="span-bg">
                                    <span Class="c-tg"></span>
                                </div>
                                @*<div Class="owl-carousel owl-carousel-2">*@

                                @for Each wg In oGetWeeklyGamesList
                                    @<div Class="item">
                                        <div Class="r-item">                                          

                                            <a Class="r-side left" href="http://atlasstatistics.gr/Teams/Details/@wg.t1id">
                                                <div Class="r-thumb">
                                                    <img src = "@wg.t1logo" alt="">
                                                </div>
                                                <div Class="r-content">
                                                    <h5> @wg.t1name </h5>
                                                </div>
                                            </a>
                                            <a Class="r-side right" href="http://atlasstatistics.gr/Teams/Details/@wg.t2id">
                                                <div Class="r-thumb">
                                                    <img src="@wg.t2logo" alt="">
                                                </div>
                                                <div Class="r-content">
                                                    <h5> @wg.t2name </h5>
                                                </div>
                                            </a>

                                            <a Class="r-num" href="http://atlasstatistics.gr/Games/Details/@wg.gameid">
                                                @*@if wg.t1points > wg.t2points Then
                                                    @<span Class="r-color">
                                                    Else
                                                    @<span>
                                                    End If
                                                @wg.t1points</span>
                                                @<span>-</span>
                                                    <span> wg.t2points</span>*@

                                                @*<span Class="r-color">*@
                                                <span>@wg.t1points</span>
                                                <span>-</span>
                                                <span>@wg.t2points</span>
                                            </a>
                                        </div>
                                    </div>
                                Next
                                @*</div>*@

                            </div>
                        </div>
                    </div>

                        <div id = "divstandcommon1" Class="widget-area-13"  style="display: none;">

                            <div Class="widget kopa-charts-widget">
                                <h3 Class="widget-title style6"><span>βαθμολογια @atlaskathgorianame</span></h3>
                                <div Class="widget-content">
                                    <header>
                                        <div Class="t-col">Α/Α</div>
                                        <div Class="t-col width1">ομαδα</div>
                                        <div Class="t-col">Αγ.</div>
                                        <div Class="t-col">βαθμ.</div>
                                    </header>
                                    <ul Class="clearfix" id="team1ranking">
                                 
                                    </ul>                                
                                </div>
                            </div>                       

                        </div>                                    

                     </div>

                     End If
                End code


               
            </div>

        </section>
        


        <div Class="content-wrap">
            <div Class="row">
                <div Class="kopa-main-col"> @*<div Class="kopa-main">*@
                                                

                @code
                    If atlaskathgoriaid > 0 Then
                        @<div id="divteamskat1" style="display: none;">
                            <div class="row">
                                <div class="kopa-main">
                                    <h3 class="widget-title style12">ομαδες κατηγορίας @atlaskathgorianame<span class="ttg"></span></h3>
                                    <div class="widget kopa-entry-list">
                                        <ul class="row clearfix" id="ulteamskat1">

                                            
                                            @*url: baseUrl + '@Url.Action("GetTeamsbyKathgoria", "Home")',*@
                                            @*data: "{kid: " + $("#atlaskathgoriaid").val() + "}",*@

                                            @for Each t In oGetTeamsbyKathgoria

                                                 @<li Class="col-md-4 col-sm-4 col-xs-4 ms-item2 pull-left">
                                                       <article Class="entry-item">
                                                            <a Class="entry-categories" href="#">@t.KathgoriaName<span class="ttg"></span></a>
                                                            <div Class="entry-thumb">
                                                                <a href = "http://atlasstatistics.gr/Teams/Details/@t.Id" target="_blank"><img src="@t.TeamLogo" alt="" style="height:120px;width:120px;"></a>                                                        
                                                            </div> 
                                                            <div Class="entry-content">
                                                                <div Class="content-top">
                                                                    <h4 Class="entry-title" itemscope="" itemtype="http://schema.org/Event">
                                                                        <a itemprop = "name" href="http://atlasstatistics.gr/Teams/Details/@t.Id" target="_blank">@t.TeamName</a>
                                                                    </h4> 
                                                                </div> 
                                                            </div> 
                                                        </article> 
                                                    </li>

                                            Next

                                           

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    End If
                 End Code
                
                <div id="divteams" class="widget kopa-entry-list" style="display: none;">
                    <h3 class="widget-title style12">@innerTitle<span class="ttg"></span></h3>
                    <table id="teamstable">
                        <tr>
                            <td>
                                <ul class="clearfix"></ul>
                            </td>
                        </tr>
                    </table>
                </div>

                <div id="divcommon" Class="widget-area-2" style="display: none;">
                    <div Class="widget kopa-article-list-widget article-list-1">
                        <h3 Class="widget-title style2">@innerTitle</h3>
                        <table id="newstable">
                            <tr>
                                <td>
                                    <ul class="clearfix"></ul>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>


            </div>

        <div Class="sidebar widget-area-11">
            <div Class="widget kopa-tab-1-widget kopa-point-widget">
                <a href = "http://www.blue-ice.gr/"><img src="~/Content/images/blueiceok.png" alt=""></a>
                <a href = "https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"><img src="~/Content/images/risko.jpg" alt=""></a>
                <a href = "http://www.atlassportswear.gr/"><img src="~/Content/images/atlassportwear.png" alt=""></a>
            </div>
        </div>

        </div>


        </div>

    </div>

</div>



@Section Scripts
    <Script type="text/javascript" language="javascript">
    $(document).ready(function () {

        //'1   Διοργανώτρια Αρχή
        //'3   Γενικά Νέα
        //'6   MVP
        //'7   Καλύτερες φάσεις
        //'11  Νέα
        //'12  Ομάδες
        //'13  Τιμωρίες
        //'14  Πρόγραμμα
        //'15  Βαθμολογίες
        //'17  Διαφημίσεις

        //if ($('#kathgoriaid').val() != 11) { //Νέα
        //    $("#divstandings1").hide();
        //    $("#divstandings2").hide();
        //}

        //$("#divfixture").hide();
        //$("#divteams").hide();

        if ($('#kathgoriaid').val() == 11) { //Νέα
            $("#divcommon").show();
            //$("#divteams").hide();
        //    $("#divteamskat1").hide();
        //    $("#divteamskat2").hide();
        } else if ($('#kathgoriaid').val() == 12) { //Ομάδες
            $("#divteamskat1").show();
        //    $("#divcommon").hide();
        //    $("#divstandings1").hide();
        //    $("#divstandings2").hide();
        } else if ($('#kathgoriaid').val() == 13) {//Τιμωρίες
            $("#divcommon").show();
            //$("#divteams").hide();
        //    $("#divteamskat1").hide();
        //    $("#divteamskat2").hide();
        } else if ($('#kathgoriaid').val() == 14) { //Πρόγραμμα
            $("#divcommon").show();
            //$("#divteams").hide();
       //     $("#divteamskat1").hide();
       //     $("#divteamskat2").hide();
        } else if ($('#kathgoriaid').val() == 15) { //βαθμολογια
            $("#divresultsandstandings").show();
            $("#divresults1").show();
            $("#divstandcommon1").show();
        //    $("#divstandings1").hide();
        //    $("#divstandings2").hide();
            //$("#divteams").hide();
        //    $("#divteamskat1").hide();
        //    $("#divteamskat2").hide();
        //    $("#divcommon").hide();
        } else if ($('#kathgoriaid').val() == 0) { //όλα τα νέα!
            $("#divcommon").show();
         }
        
      
        if ($("#divcommon").is(":visible")) {
            $('#newstable').DataTable({
                "sAjaxSource": baseUrl + '@Url.Action("GetLastNewsByBothCategories")',
                "fnServerParams": function (aoData) {
                    aoData.push({
                        "name": "AtlasOmilosid",
                        "value": $('#atlaskathgoriaid').val()
                    })
                    aoData.push({
                        "name": "nCount",
                        "value": 100
                    })
                    aoData.push({
                        "name": "KathgoriaId",
                        "value": $('#kathgoriaid').val()
                    })
                    aoData.push({
                        "name": "IsKathgoria",
                        "value": 1
                    })
                    aoData.push({
                        "name": "IsAtlasKathgoria",
                        "value": 1
                    })
                },
                "contentType": "application/json; charset=utf-8",
                "language": {
                    "url": baseUrl + "/Scripts/DataTables/Greek.json"
                },
                "aLengthMenu": [[5, 10, 20, 50, -1], [5, 10, 20, 50, "All"]],
                "iDisplayLength": 5,
                "bProcessing": true,
                "aoColumns": [{}],
                "columnDefs": [
                        {
                            "targets": 0,
                            "render": function (data, type, row) {
                                if (row === undefined || row === null) return '';

                                var dd = '<li>'+
                                    ' <article class="entry-item"> ' +
                                    '   <div class="entry-thumb"> ' +
                                    '       <a href="@Url.Action("Details", "Posts")/' + row.Id + '"> ' +
                                    '           <img src="' + row.PostPhoto + '" alt="">' +
                                    '       </a> ' +
                                    ' </div> ' +
                                    ' <div class="entry-content"> ' +
                                    '   <div class="content-top"> ' +
                                    '       <a href="@Url.Action("Details", "Posts")/' + row.Id + '"> ' +
                                    '           <h4 class="entry-title"> <b>' + row.PostTitle + ' </b> </h4> ' +
                                    '       </a> ' +
                                    '   </div> ' +
                                    '   <p>' + row.PostSummary + ' .... </p> ' +
                                    '   <footer> ' +
                                    '       <p class="entry-author"> από ' + row.editBy + '</p> ' +
                                    '   </footer> ' +
                                    ' </div>    ' +
                                    ' </a> ' +
                                    ' </article> '+
                                    '</li>';

                                return dd;
                            }

                        }
                ]
            });
        }

        //append bathmologia 1
          if ($("#divstandcommon1").is(":visible")) {
              if ($("#atlaskathgoriaid").val() > 0) {
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetRankingsStats", "Home")',
                    data: "{kathgoriaid: " + $("#atlaskathgoriaid").val() + "}",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        if (result.length > 0) {
                            var r = 1;
                            $.each(result, function () {
                                tbrow = '<li> ' +
                                       '    <div Class="t-col">' + r + '</div> ' +
                                       '    <div Class="t-col width1">' + this.sname + '</div> ' +
                                       '    <div Class="t-col">' + this.totalplayed + '</div> ' +
                                       '    <div Class="t-col">' + this.bathmoi + '</div> ' +
                                       '</li>';
                                r += 1;
                                $("#team1ranking").append(tbrow);
                            });

                        }
                    },
                    error: function (result) {
                        //alert("Δεν έχετε διαλέξει όλες τις επιλογές!");
                    }
                });
            }
        }



        @*//GetTeamsbyKathgoria 1
        if ($("#divteamskat1").is(":visible")) {

            var choiceContainer = $("#ulteamskat1");
            choiceContainer.empty();

            $.ajax({
                type: "POST",
                url: baseUrl + '@Url.Action("GetTeamsbyKathgoria", "Home")',
                data: "{kid: " + $("#atlaskathgoriaid").val() + "}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {

                    if (result.data.length > 0) {

                        $.each(result.data, function () {
                            var d = '<li class="col-md-4 col-sm-4 col-xs-4 ms-item2 pull-left">' +
                                   '<article class="entry-item"> ' +
                                   '<a class="entry-categories" href="#">' + this.KathgoriaName + '<span class="ttg"></span></a> ' +
                                   '<div class="entry-thumb"> ' +
                                   '<a href="http://atlasstatistics.gr/Teams/Details/' + this.Id + '" target="_blank"><img src="' + this.TeamLogo + '" alt=""  style="height:120px;width:120px;"></a> ' +
                                   '</div> ' +
                                   '<div class="entry-content">  ' +
                                   '<div class="content-top">  ' +
                                   '<h4 class="entry-title" itemscope="" itemtype="http://schema.org/Event"><a itemprop="name" ' +
                                   ' href="http://atlasstatistics.gr/Teams/Details/' + this.Id + '" target="_blank">' + this.TeamName + '</a></h4> ' +
                                   '</div> ' +
                                   '</div> ' +
                                   '</article> ' +
                                   '</li>';
                            choiceContainer.append(d);
                        });
                    }
                },
                error: function (result) {
                    //alert("Δεν έχετε διαλέξει όλες τις επιλογές!");
                }
            });
        }*@

        //GetTeamsbyKathgoria 2
        @*if ($("#divteamskat2").is(":visible")) {

            var choiceContainer = $("#ulteamskat2");
            choiceContainer.empty();

            $.ajax({
                type: "POST",
                url: baseUrl + '@Url.Action("GetTeamsbyKathgoria", "Home")',
                data: "{kid: " + $("#atlaskathgoria2").val() + "}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {

                    if (result.data.length > 0) {
                        $.each(result.data, function () {
                            var d = '<li class="col-md-3 col-sm-3 col-xs-3 ms-item2">' +
                                   '<article class="entry-item"> ' +
                                   '<a class="entry-categories" href="#">' + this.KathgoriaName + '<span class="ttg"></span></a> ' +
                                   '<div class="entry-thumb"> ' +
                                   '<a href="http://atlasstatistics.gr/Teams/Details/' + this.Id + '" target="_blank"><img src="' + this.TeamLogo + '" alt=""  style="height:120px;width:120px;" ></a> ' +
                                   '</div> ' +
                                   '<div class="entry-content">  ' +
                                   '<div class="content-top">  ' +
                                   '<h4 class="entry-title" itemscope="" itemtype="http://schema.org/Event"><a itemprop="name" ' +
                                   ' href="http://atlasstatistics.gr/Teams/Details/' + this.Id + '" target="_blank">' + this.TeamName + '</a></h4> ' +
                                   '</div> ' +
                                   '</div> ' +
                                   '</article> ' +
                                   '</li>';
                            choiceContainer.append(d);
                        });
                    }
                },
                error: function (result) {
                    //alert("Δεν έχετε διαλέξει όλες τις επιλογές!");
                }
            });
        }*@
    });
    </Script>
End Section
