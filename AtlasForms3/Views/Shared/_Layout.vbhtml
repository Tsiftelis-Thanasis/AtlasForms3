@code

    Dim pdb2 As New AtlasStatisticsEntities

    Dim firstDiorganwshid = (From d In pdb2.DiorganwshTable
                             Join s In pdb2.SeasonTable On d.Seasonid Equals s.Id
                             Where d.DiorganwshName.Contains("πρωταθλημα") And s.ActiveSeason = True
                             Select d.Id).FirstOrDefault

    'If Session("GlobalDiorganwshid") = 0 Then
    Session("GlobalDiorganwshid") = firstDiorganwshid
    'Else
    'firstDiorganwshid = Session("GlobalDiorganwshid")
    'End If

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

              
                <!-- logo -->

                <nav class="kopa-main-nav">
                    <div class="kopa-logo">
                        <a href="@Url.Action("Index", "Home")"><img src="~/Content/images/logoAtlas.png" alt="logo" style="height:60px;"></a>
                    </div>
                   
                 
                    <ul class="main-menu sf-menu">
                        <li class="current-menu-item">
                            <a href="@Url.Action("Index", "Home")"><span>Αρχικη</span></a>
                        </li>
                        <li class="current-menu-item">
                            <a class="lipointer" id="prwta8limaid" onclick="fillomiloinavbar(@firstDiorganwshid, 1)"><span>Πρωταθλημα</span></a>                         
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανώσεις</span></a>
                            <ul class="sub-menu" id="diorganwseiulid"> </ul>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανωτρια αρχη</span></a>
                            <ul class="sub-menu" id="diorgarxhpostsid">                                                              
                            </ul>
                        </li>
                        @if User.Identity.IsAuthenticated Then
                            If User.IsInRole("Admins") Then
                            @<li Class="current-menu-item"><a href="@Url.Action("Panel", "Home")"><span>διαχειριση</span></a></li>
                            End If
                        End If
                    </ul>
                </nav>


                <nav class="main-nav-mobile">
                    <ul class="main-menu sf-menu">
                        <li class="current-menu-item">
                            <a href="@Url.Action("Index", "Home")"><span>Αρχικη</span></a>
                        </li>
                        <li class="current-menu-item">
                            <a class="lipointer"  onclick="fillomiloinavbar(@firstDiorganwshid, 1)"><span>Πρωταθλημα</span></a>                         
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανώσεις</span></a>
                            <ul class="sub-menu" id="diorganwseiulidmobile"> </ul>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανωτρια αρχη</span></a>
                            <ul class="sub-menu" id="diorgarxhpostsidmobile"></ul>
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

                <nav class="th-kopa-main-nav-2">

                    <ul class="main-menu-2 sf-menu" id="omiloinavbarid">
                        @*<li>
                            <div class="sf-mega col-md-push-0 col-xs-push-0 col-sm-push-0">
                            <div class="sf-mega-section col-md-3 col-xs-3 col-sm-3">
                                <div class="widget kopa-sub-list-widget">
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
                        </li>*@
                    </ul>

                </nav>

            </div>   

            <div class="wrapper">
                <nav class="th-kopa-main-nav-3">
                    <ul class="main-menu-2"  id="kathgoriesnavbarid">
                       
                    </ul>
                </nav>
            </div>   

            </div>            
        
</header>
    

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
                    <a href="@Url.Action("Index", "Home")"><img src="~/Content/images/logoAtlas.png" alt="logo" style="height:auto;"></a>
                </div>
                <nav class="bottom-nav">

                    @Html.Partial("_LoginPartial")

                </nav>
                <nav class="bottom-nav-mobile">

                    @Html.Partial("_LoginPartial")

                </nav>

            </div>
        </div>        
    </div>
    
    <footer id="kopa-footer">
        <div class="wrapper clearfix">
            <p id="copyright" class="">Copyright © 2017 . All Rights Reserved. </p>
        </div>       
    </footer>
   

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
    function fillomiloinavbar(i, t) {

        //$("#firstDiorganwshid").val(i);

        t = t || 0;

        postDiorganwshid(i);

        var choiceContainer = $("#diorganwseiulid");
        var choiceContainermobile = $("#diorganwseiulidmobile");
        if (t = 0) {
            choiceContainer.toggle();
            choiceContainermobile.toggle();
        }

        $("#kathgoriesnavbarid").empty();

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
                            omilos = omilos + ' Όμιλος';
                        }
                        var omilosnaming = 'omilos' + this.Id + 'row';

                        @*'<div class="sf-mega col-md-push-0 col-xs-push-0 col-sm-push-0"> ' +
                                '<div class="sf-mega-section col-md-3 col-xs-3 col-sm-3"> ' +
                                    '<div class="widget kopa-sub-list-widget"> ' +
                                        '<ul class="sub-menu"> ' +
                                            '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=11">νεα</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=12">ομάδες</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=13">τιμωριες</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=14">προγραμμα</a> ' +
                                                '</li> ' +
                                                '<li> ' +
                                                '<a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=15">βαθμολογια</a>' +
                                                '</li>' +
                                                '</ul> ' +
                                                '</div> ' +
                                                '</div> ' +
                                                '<div class="sf-mega-section col-md-9 col-xs-9 col-sm-9"> ' +
                                                '<div class="widget kopa-sub-list-widget sub-list-1"> ' +
                                                '<h4>Τελευταια νεα ' + this.OmilosName + ' ομίλου</h4> ' +
                                                '<ul id="' + omilosnaming + '" class="row"></ul> ' +
                                                '</div>' +
                                                '</div>' +
                                                '</div> ' +*@


                        var d = '<li class="lipointer" onclick="appendKathgoriaNav(' + this.Id + ')"> ' +
                                '<span>' + omilos + '</span> ' +
                                '</li>';

                        choiceContainer.prepend(d);

                        //appendnewstoOmilos(omilosnaming, this.Id);


                    });
                }
            },
            error: function (result) {
                alert(result.status + ' ' + result.statusText);
            }
        });
    }


    function appendKathgoriaNav(containerid) {

        //apend for each omilos
             $.ajax({
                type: "POST",
                url: baseUrl + '@Url.Action("GetKathgoriesbyOmilos", "Home")',
                 data: "{OId: " + containerid + "}",
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {

                    var choiceContainer = $("#kathgoriesnavbarid");
                    choiceContainer.empty();

                    if (result.length > 0) {
                        var d = '';

                        $.each(result, function () {

                            //  Select k., k.Id).ToList

                            d += '<li class="lipointer" > <a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=12"> <span style="font-size: 12px; !important" >Ομάδες ' + this.KathgoriaName + '     </a> </span> </li> ' +
                                 '<li class="lipointer" > <a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=13"> <span style="font-size: 12px; !important" >Τιμωρίες ' + this.KathgoriaName + '   </a> </span> </li> ' +
                                 '<li class="lipointer" > <a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=14"> <span style="font-size: 12px; !important" >Πρόγραμμα ' + this.KathgoriaName + '  </a> </span> </li> ' +
                                 '<li class="lipointer" > <a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=15"> <span style="font-size: 12px; !important" >Βαθμολογίες ' + this.KathgoriaName + '</a> </span> </li> ' +
                                 '<li class="lipointer" > <a href="@Url.Action("Index", "Posts")/?a=' + this.Id + '&k=11"> <span style="font-size: 12px; !important" >Νέα ' + this.KathgoriaName + '        </a> </span> </li>';


                        });
                                               
                        choiceContainer.append(d);
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
                                    ' <img src="' + this.PostPhoto + '" alt="" style="height:90px;width:120px;"> ' +
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



    function postDiorganwshid(id) {

       // post diorganwsh id
        $.ajax({
            type: "POST",
            url: baseUrl + '@Url.Action("SetGlobalDiorganwshid", "Home")',
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


        // get diorganwtria arxh arthra
        $.ajax({
             type: "POST",
             url: baseUrl + '@Url.Action("GetLastNewsByCategory", "Posts")',
             data: "{nCount : 10, k : 1}",
             async: false,
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (result) {
                 var choiceContainer = $("#diorgarxhpostsid");
                 var choiceContainermobile = $("#diorgarxhpostsidmobile");
                 if (result.data.length > 0) {
                     choiceContainer.empty();
                     choiceContainermobile.empty();
                     $.each(result.data, function () {
                         var d = '<li><a href="' + baseUrl + '/Posts/Details/' + this.Id + '">' + this.PostTitle + '</a></li>';
                         choiceContainer.append(d);
                         choiceContainermobile.append(d);
                     });
                 }
             },
             error: function (result) {
                 alert(result.status + ' ' + result.statusText);
             }
         });

        // get diorganwseis
            $.ajax({
                type: "POST",
                url: baseUrl + '@Url.Action("Getdiorganwseis", "Home")',
                async: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {

                    var choiceContainer = $("#diorganwseiulid");
                    var choiceContainermobile = $("#diorganwseiulidmobile");
                    if (result.length > 0) {

                        choiceContainer.empty();
                        choiceContainermobile.empty();

                            $.each(result, function () {
                                var d = '<li class="lipointer" onclick="fillomiloinavbar(' + this.Id + ');"><a>' + this.DiorganwshName + '</a></li>'
                            choiceContainer.append(d);
                            choiceContainermobile.append(d);
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

    $(window).on('load', function() {
        setTimeout(function () {
            //$("#prwta8limaid").trigger("click");
            fillomiloinavbar($("#firstDiorganwshid").val());
        }, 200);
    });




</script>
