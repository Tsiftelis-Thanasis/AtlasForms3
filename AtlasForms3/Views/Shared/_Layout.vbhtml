@code

    Dim pdb2 As New atlasStatisticsEntities

    Dim firstDiorganwshid = (From d In pdb2.DiorganwshTable
                             Join s In pdb2.SeasonTable On d.Seasonid Equals s.Id
                             Where d.DiorganwshName.Contains("πρωταθλημα") And s.ActiveSeason = True
                             Select d.Id).FirstOrDefault

End Code

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@(If(ViewBag.Title = "", "", ViewBag.Title & " - ")) Ατλας μπάσκετ</title>
    <link rel="shortcut icon" type="image/ico" href="~/favicon.ico">

    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    @RenderSection("styles", required:=False)
    <script type="text/javascript" language="javascript">

        var url1 = window.location.href.split('/');
        var baseUrl = url1[0] + '//' + url1[2];

    </script>

    <link href='https://fonts.googleapis.com/css?family=Open+Sans&subset=latin,greek' rel='stylesheet' type='text/css'>

</head>


<body>

    @Html.Hidden("firstDiorganwshid", firstDiorganwshid)


    <header class="kopa-header">

        <div class="kopa-header-middle">

            <div class="wrapper">

                <div class="kopa-logo">
                    <a href="@Url.Action("Index", "Home")"><img src="~/Content/images/logoAtlas.png" alt="logo" style="height:60px;"></a>
                </div>
                <!-- logo -->

                <nav class="kopa-main-nav">
                    <ul class="main-menu sf-menu">
                        <li class="current-menu-item">
                            <a href="@Url.Action("Index", "Home")"><span>Αρχικη</span></a>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανώσεις</span></a>
                            <ul class="sub-menu" id="diorganwseiulid"> </ul>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανωτρια αρχη</span></a>
                            <ul class="sub-menu">
                                <li><a href="viewNews.aspx?typ=org&title=κανονες - οροι συμμετοχης">κανονες οροι συμμετοχης</a></li>
                                <li><a href="gallery2.html">διακηρυξη πρωταθληματος 2016/17</a></li>
                                <li><a href="gallery3.html">φυσιοθεραπειες</a></li>
                                <li><a href="gallery4.html">υπηρεσιες</a></li>
                                <li><a href="gallery4.html">ιατρικη ομαδα</a></li>
                                <li><a href="gallery4.html">πειθαρχικο δικαιο</a></li>
                                <li><a href="gallery4.html">συνεργατες</a></li>
                                <li><a href="gallery4.html">εγγραφες</a></li>
                                <li><a href="gallery4.html">επικοινωνια</a></li>
                            </ul>
                        </li>
                        @if User.Identity.IsAuthenticated Then
                            If User.IsInRole("Admins") Then
                            @<li Class="current-menu-item"><a href="@Url.Action("Panel", "Home")"><span>διαχειριση</span></a></li>
                            End If
                        End If
                    </ul>
                </nav>

            </div>
            <!-- wrapper -->

        </div>
        <!-- kopa-header-middle -->

        <div class="kopa-header-bottom">

            <div class="wrapper">

                <nav class="kopa-main-nav-2">
                    <ul class="main-menu-2 sf-menu" id="omiloinavbarid">
                        <li>
                            <div class="sf-mega col-md-push-0 col-xs-push-0 col-sm-push-0">
                                <div class="sf-mega-section col-md-3 col-xs-3 col-sm-3">
                                    <div class="widget kopa-sub-list-widget">
                                       ****na kanw edw to spasimo?? mhpws menei kai stis alles selides??
                                         <ul class="sub-menu">
                                            <li>
                                            </li> 
                                        </ul> 
                                    </div> 
                                </div> 
                            <div class="sf-mega-section col-md-9 col-xs-9 col-sm-9">
                                <div class="widget kopa-sub-list-widget sub-list-1">
                                    <h4></h4> 
                                        <ul class="row"></ul> 
                                    </div>
                                </div>
                            </div> 
                        </li>
                    </ul>
                </nav>
                <!--/end main-nav-2-->

            </div>
            <!-- wrapper -->

            <div class="kopa-sub-page kopa-single-page">
                <div class="widget kopa-tab-score-widget">
                    <div class="kopa-tab style1">
                        <div class="tab-content">
                            <div class="tab-pane active" id="agroup">
                                <div id="lastgamescarouselid" class="owl-carousel owl-carousel-1">
                                    
                                </div>
                            </div>

                            <!-- tab-pane -->
                        </div>
                    </div>
                    <!-- kopa-tab -->

                </div>
                <!-- widget -->
            </div>

        </div>
        <!-- kopa-header-bottom -->



    </header>
    <!-- kopa-page-header -->

    <div class="kopa-sub-page kopa-single-page">
        <div class="container body-content">           
                    @RenderBody()
                <hr />           
        </div>
    </div>

    <div id="bottom-sidebar">

        <div class="bottom-area-1">

            <div class="wrapper">

                <div class="kopa-logo">
                    <a href="@Url.Action("Index", "Home")"><img src="~/Content/images/logoAtlas.png" alt="logo" style="height:60px;"></a>
                </div>
                <!-- logo -->


                <nav class="bottom-nav">

                    @Html.Partial("_LoginPartial")

                </nav>
                <!--/end bottom-nav-->
                <!--/main-menu-mobile-->

            </div>
            <!-- wrapper -->
        </div>
        <!-- bottom-area-2 -->
        <!-- bottom-area-2 -->

    </div>
    <!-- bottom-sidebar -->

    <footer id="kopa-footer">

        <div class="wrapper clearfix">

            <p id="copyright" class="">Copyright © 2017 . All Rights Reserved. </p>

        </div>
        <!-- wrapper -->

    </footer>
    <!-- kopa-footer -->

    <a href="#" class="scrollup"><span class="fa fa-chevron-up"></span></a>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryui")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/custom")
    @RenderSection("scripts", required:=False)
</body>
</html>


<script type="text/javascript" language="javascript">

    /*** Handle jQuery plugin naming conflict between jQuery UI and Bootstrap ***/
    $.widget.bridge('uibutton', $.ui.button);
    $.widget.bridge('uitooltip', $.ui.tooltip);
    $(function () {
        var bootstrapButton = $.fn.button.noConflict();// return $.fn.button to previously assigned value
        $.fn.bootstrapBtn = bootstrapButton;           // give $().bootstrapBtn the Bootstrap functionality
    });

    //fillomiloinavbar
    function fillomiloinavbar(i) {

        $("#firstDiorganwshid").val(i);

       $.ajax({
            type: "POST",
            url: baseUrl + '@Url.Action("GetOmiloiByDiorganwsh", "Home")',
            data: "{dId: " + i + "}",
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {

                var choiceContainer = $("#omiloinavbarid");

                if (result.length > 0) {
                    choiceContainer.empty();

                    $.each(result, function () {

                        var omilos = this.OmilosName;
                        if (omilos.length < 2) {
                            omilos = omilos + ' ομιλος';
                        }
                        var omilosnaming = 'omilos' + this.Id + 'row';

                        var d = '<li> ' +
                                '<span>' + omilos + '</span> ' +
                                '<div class="sf-mega col-md-push-0 col-xs-push-0 col-sm-push-0"> ' +
                                '<div class="sf-mega-section col-md-3 col-xs-3 col-sm-3"> ' +
                                    '<div class="widget kopa-sub-list-widget"> ' +
                                        '<ul class="sub-menu"> ' +
                                            '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&yk=2">νεα</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&yk=3">ομάδες</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&yk=4">τιμωριες</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&yk=5">προγραμμα</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&yk=6">βαθμολογια</a>' +
                                                '</li>' +
                                                '</ul> ' +
                                                '</div> ' +
                                                '</div> ' +
                                                '<div class="sf-mega-section col-md-9 col-xs-9 col-sm-9"> ' +
                                                '<div class="widget kopa-sub-list-widget sub-list-1"> ' +
                                                '<h4>Τελευταια νεα ομιλου</h4> ' +
                                                '<ul id="' + omilosnaming + '" class="row"></ul> ' +
                                                '</div>' +
                                                '</div>' +
                                                '</div> ' +
                                                '</li>';
                        choiceContainer.append(d);

                        appendnewstoOmilos(omilosnaming, this.Id);

                    });
                }
            },
            error: function (result) {
                alert(result.status + ' ' + result.statusText);
            }
        });
    }


    function appendnewstoOmilos(containername, containerid) {

        //apend for each omilos
        $.ajax({
            type: "POST",
            url: baseUrl + '@Url.Action("GetLastNewsByCategory2", "Posts")',
            data: "{nCount : 5, KathgoriaId : " + containerid + ", IsAtlasOmilos: 1}",
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {

                var choiceContainer = $("#" + containername);

                if (result.data.length > 0) {

                    choiceContainer.empty();

                    $.each(result.data, function () {

                        var d = ' <li class="col-md-4 col-xs-4 col-sm-4"> ' +
                                ' <article class="entry-item"> ' +
                                ' <a href="' + baseUrl + '/Posts/Details/' + this.Id + '"> ' +
                                ' <div class="entry-thumb"> ' +
                                ' <img src="' + this.PostPhoto + '" alt=""> ' +
                                ' </div> </a>' +
                                ' <h4 class="entry-title">' + this.PostTitle + '</h4> ' +
                                ' </article> ' +
                                ' </li> ';
                        choiceContainer.append(d);

                    });
                }
            },
            error: function (result) {
                alert(result.status + ' ' + result.statusText);
            }
        });

    }


    $(document).ready(function () {

        // get diorganwseis
            $.ajax({
                type: "POST",
                url: baseUrl + '@Url.Action("Getdiorganwseis", "Home")',
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {

                    var choiceContainer = $("#diorganwseiulid");
                    if (result.length > 0) {

                            choiceContainer.empty();
                            $.each(result, function () {
                            var d = '<li onclick="fillomiloinavbar(' + this.Id + ');"><a>' + this.DiorganwshName + '</a></li>'
                            choiceContainer.append(d);
                        });
                    }
                },
                error: function (result) {
                    alert(result.status + ' ' + result.statusText);
                }
            });


        //append lastgames carouselid

        $.ajax({
            type: "POST",
            url: baseUrl + '@Url.Action("Getlastgames", "Home")',
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {

                var choiceContainer = $("#lastgamescarouselid");
                if (result.length > 0) {

                    choiceContainer.empty();
                    $.each(result, function () {

                        var d= '<div class="item"> ' +
                                '<div class="entry-item"> ' +
                                '<a  target="_blank" href="http://www.atlasstatistics.gr/Games/Details/' + this.Id + '"> ' +
                                '<p>' + this.Gamedate + '</p> ' +
                                '<ul class="clearfix"> ' +
                                '<li> ' +
                                '<span title="' + this.team1 + '">' + this.team1 + '</span> ' +
                                '<span>' + this.team1score + '</span> ' +
                                '</li> ' +
                                '<li> ' +
                                '<span title="' + this.team2 + '">' + this.team2 + '</span> ' +
                                '<span>' + this.team2score + '</span> ' +
                                '</li> ' +
                                '</ul> ' +
                                '</a> ' +
                                '</div> ' +
                                '</div>';
                                   
                        choiceContainer.append(d);
                    });
                }
            },
            error: function (result) {
                alert(result.status + ' ' + result.statusText);
            }
        });


    });


    fillomiloinavbar($("#firstDiorganwshid").val());

</script>
