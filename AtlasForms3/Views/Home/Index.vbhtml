﻿@Code



    Dim atlasomilosid As Integer = If(ViewBag.AtlasOmilos Is Nothing, 0, ViewBag.AtlasOmilos)
    Dim atlasomilosname As String = ""

    Using pdb2 As New AtlasStatisticsEntities

        If atlasomilosid > 0 Then

            atlasomilosname = (From k In pdb2.OmilosTable
                               Where k.Id = atlasomilosid
                               Select k.OmilosName).FirstOrDefault
        End If

    End Using

    'Dim innerTitle As String = ""
    If atlasomilosname = "" Then
        ViewData("Title") = "Κεντρική σελίδα"
    Else
        If atlasomilosname.Count < 2 Then
            atlasomilosname = atlasomilosname & " Όμιλος"
        End If

        ViewData("Title") = atlasomilosname
    End If


End Code


@Html.Hidden("atlasomilosid", atlasomilosid)


<div id="main-content" Class="style1">

    <div Class="main-top">

        <div Class="social-links style1">
            <ul Class="clearfix">
                <li> <a href="https://www.facebook.com/atlasbasket.gr/" Class="fa fa-facebook"></a></li>
                <li> <a href="https://twitter.com/atlasteam1" Class="fa fa-twitter"></a></li>
                <li> <a href="http://www.google.com/profiles/117211032484470772194" Class="fa fa-google-plus"></a></li>
                <li> <a href="https://www.youtube.com/channel/UCRTTtMCMaxoKT11U1MekmwQ" Class="fa fa-youtube"></a></li>
            </ul>
        </div>

    </div>

    <!-- main-top -->
    <div Class="wrapper">

        <div Class="kopa-page">
            <div Class="widget kopa-tab-score-widget">
                <div Class="kopa-tab style1">
                    <div Class="tab-content">
                        <div Class="tab-pane active" id="agroup">
                            <div id="lastgamescarouselid" Class="owl-carousel owl-carousel-1">

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

    <div Class="wrapper mb-30">

        <div Class="widget-area-1">

            <div Class="widget kopa-tab-1-widget kopa-point-widget">
                <div Class="widget kopa-sync-carousel-widget">
                    <div Class="owl-carousel sync1" id="mainnewscarouselid">
                    </div>
                </div>
            </div>
            <p></p>

            <div Class="wrapper">

                <div Class="content-wrap">

                    <div Class="row">

                        <div Class="kopa-main-col">

                            <div Class="widget-area-2">

                                <div Class="widget kopa-tab-sync-carousel-widget">
                                    <h3 Class="widget-title style1">τοπ 10</h3>
                                    <div Class="widget kopa-sync-carousel-2-widget">
                                        <div Class="owl-carousel sync3" id="watchsync3">
                                        </div>

                                        <div Class="owl-carousel sync4" id="watchsync4">
                                        </div>

                                    </div>

                                </div>

                                <div Class="widget kopa-article-list-widget article-list-1">
                                    <h3 Class="widget-title style2">τελευταια νεα</h3>
                                    <ul id="latestnewsid" Class="clearfix"></ul>
                                </div>

                            </div>

                        </div>

                        @*<div Class="sidebar2 widget-area-11">

                                <div Class="widget kopa-tab-1-widget kopa-point-widget">
                                    <a href="http://www.blue-ice.gr/"> <img src="~/Content/images/blueiceok.png" alt=""></a>
                                    <a href="https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"> <img src="~/Content/images/risko.jpg" alt=""></a>
                                    <a href="http://www.atlassportswear.gr/"> <img src="~/Content/images/atlassportwear.png" alt=""></a>
                                </div>
                            </div>*@


                        <div Class="sidebar widget-area-11">

                            <div Class="widget kopa-tab-1-widget kopa-point-widget">
                                <a href="http://www.blue-ice.gr/"> <img src="~/Content/images/blueiceok.png" alt=""></a>
                                <a href="https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"> <img src="~/Content/images/risko.jpg" alt=""></a>
                                <a href="http://www.atlassportswear.gr/"> <img src="~/Content/images/atlassportwear.png" alt=""></a>
                            </div>


                            <div Class="widget kopa-tab-1-widget kopa-point-widget">
                                <h3 Class="widget-title style5"><span class="fa fa-trophy"></span>Κορυφαίοι της εβδομάδας</h3>
                                <ul Class="clearfix">
                                    <li>
                                        <div Class="kopa-tab style3">
                                            <ul Class="nav nav-tabs">
                                                <li Class="active"><a href="#points" data-toggle="tab">Πον.</a></li>
                                                <li> <a href="#assist" data-toggle="tab">Πασ.</a></li>
                                                <li> <a href="#reb" data-toggle="tab">Ριμ.</a></li>
                                                <li> <a href="#steal" data-toggle="tab">Κλ.</a></li>
                                                <li> <a href="#block" data-toggle="tab">Κοψ.</a></li>
                                            </ul>

                                            <div Class="tab-content">
                                                <div Class="tab-pane active" id="points">
                                                    <ul Class="kopa-list clearfix" id="pointsul"></ul>
                                                </div>

                                                <div Class="tab-pane" id="assist">
                                                    <ul Class="kopa-list clearfix" id="assistul"></ul>
                                                </div>

                                                <div Class="tab-pane" id="reb">
                                                    <ul Class="kopa-list clearfix" id="reboundul"></ul>
                                                </div>

                                                <div Class="tab-pane" id="steal">
                                                    <ul Class="kopa-list clearfix" id="stealsul"></ul>
                                                </div>

                                                <div Class="tab-pane" id="block">
                                                    <ul Class="kopa-list clearfix" id="blocksul"></ul>
                                                </div>


                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>
    
    <div Class="widget-area-24 kopa-area kopa-area-2 w3-center" id="fwtografiesdiv">

        <h2 Class="widget-title style9"><span><b>Φωτογραφιες</b></span></h2>

        <div Class="widget kopa-tab-1-widget kopa-point-widget">

            <div Class="row">
                <div class="widget-area-11">
                    <div class="w3-content w3-section" style="max-width:45%" id="fwtografiesid">
                        
                        @*<img class="mySlides w3-center" src="~/Content/images/scroll-slider/2.jpg" style="height:30%;width:100%">*@

                    </div>
                </div>
            </div>

        </div>
    </div>

    </div>

    @Section Scripts
        <script type="text/javascript">

            var myIndex = 0;
            
            //carousel for the images of the gallery
            function carousel1() {
                var i;
                var x = document.getElementsByClassName("mySlides");
                for (i = 0; i < x.length; i++) {
                    x[i].style.display = "none";
                }
                myIndex++;
                if (myIndex > x.length) { myIndex = 1 }
                x[myIndex - 1].style.display = "block";
                setTimeout(carousel1, 5000); // Change image every 5 seconds
            }

            //append lastgames carouselid
            function GetLastGames(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("Getlastgames", "Home")',
                    data: "{omilosid : " + omilosid + "}",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var choiceContainer = $("#lastgamescarouselid");
                        if (result.length > 0) {

                            choiceContainer.empty();
                            $.each(result, function () {

                                var d = '<div class="item"> ' +
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
                        alert('1 ' + result.status + ' ' + result.statusText);
                    }
                });
            }


            //append carousel sync3 and sync4
            function AppendCarousel1(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetLastNewsByCategory", "Posts")',
                    data: "{nCount : 10, atlasomilosid: " + omilosid + "}",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var sync3container = $("#watchsync3");
                        var sync4container = $("#watchsync4");

                        if (result.data.length > 0) {

                            sync3container.empty();
                            sync4container.empty();

                            $.each(result.data, function () {

                                d = ' <div class="item"> ' +
                                    '   <article class="entry-item video-post"> ' +
                                    '   <div class="entry-thumb"> ' +
                                    '       <a href="' + baseUrl + '/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto + '" alt="" style="height:315px;"></a> ' +
                                    '       <a class="thumb-icon" href="https://www.youtube.com/watch?v=' + this.Youtubelink + '" target="_blank"></a> ' +
                                    '   </div> ' +
                                    '   <div class="entry-content"> ' +
                                    '       <h3 class=""><a href="' + baseUrl + '/Posts/Details/' + this.Id + '">' + this.PostTitle + '</a></h3> ' +
                                    '   </div> ' +
                                    ' </article> ' +
                                    '</div>';
                                sync3container.append(d);

                                d = ' <div class="item"> ' +
                                    '   <article class="entry-item video-post"> ' +
                                    '   <div class="entry-thumb"> ' +
                                    '       <a href="' + baseUrl + '/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto2 + '" alt="" style="height:100px;width:120px;"></a> ' +
                                    '       <a class="thumb-icon" href="https://www.youtube.com/watch?v=' + this.Youtubelink + '" target="_blank"></a> ' +
                                    '   </div> ' +
                                    '   <div class="entry-content"> ' +
                                    '       <h4 class="entry-title"><a href="' + baseUrl + '/Posts/Details/' + this.Id + '">' + this.PostTitle + '</a></h4> ' +
                                    '   </div> ' +
                                    ' </article> ' +
                                    '</div>';
                                sync4container.append(d);

                            });
                        }
                    },
                    error: function (result) {
                        alert('2 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //append mainnewscarouselid
            function AppendMainCarousel(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetLastNews", "Posts")',
                    data: "{nCount : 5, atlasomilosid: " + omilosid + "}",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var synccontainer = $("#mainnewscarouselid");

                        if (result.data.length > 0) {

                            synccontainer.empty();

                            $.each(result.data, function () {

                                d = ' <div class="item"> ' +
                                    ' <article class="entry-item"> ' +
                                    ' <div class="entry-thumb"> ' +
                                    ' <a href="' + baseUrl + '/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto + '" style="height:520px;" alt=""></a> ' +
                                    ' <div class="thumb-hover"></div> ' +
                                    ' </div> ' +
                                    ' <div class="entry-content"> ' +
                                    ' <h4 class="entry-title"><a href="' + baseUrl + '/Posts/Details/' + this.Id + '">' + this.PostTitle + '</a></h4>  ' +
                                    ' <h5><span><b>' + this.PostSummary + '</b></span></h5> ' +
                                    ' </div> ' +
                                    ' <span></span> ' +
                                    ' </article> ' +
                                    ' </div>';
                                synccontainer.append(d);

                            });
                        }
                    },
                    error: function (result) {
                        alert('3 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //apend latestnewsid
            function AppendLatestNews(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetLastNews", "Posts")',
                    data: "{nCount : 10, atlasomilosid: " + omilosid + "}",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        var choiceContainer = $("#latestnewsid");
                        if (result.data.length > 0) {
                            choiceContainer.empty();
                            $.each(result.data, function () {
                                d = '<li> ' +
                                    ' <article class="entry-item"> ' +
                                    ' <div class="entry-thumb"> ' +
                                    ' <a href="#"><img src="' + this.PostPhoto2 + '" alt=""></a> ' +
                                    ' </div> ' +
                                    ' <div class="entry-content"> ' +
                                    ' <div class="content-top"> ' +
                                    ' <h4 class="entry-title"><a href="' + baseUrl + '/Posts/Details/' + this.Id + '">' + this.PostTitle + '</a></h4> ' +
                                    ' </div> ' +
                                    ' <p>' + this.PostSummary + '.... </p> ' +
                                    ' </div> ' +
                                    ' </article> ' +
                                    ' </li> '
                                choiceContainer.append(d);
                            });
                        }
                    },
                    error: function (result) {
                        alert('4 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //apend kalyteresfaseisid
            function AppendKalyteresFaseis(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetKalyteresFaseisVideo", "Posts")',
                    data: "{atlasomilosid: " + omilosid + "}",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var choiceContainer = $("#kalyteresfaseisid");
                        if (result.data.length > 0) {
                            choiceContainer.empty();
                            $.each(result.data, function () {
                                d = '<div class="item"> ' +
                                    '<article class="entry-item"> ' +
                                    '<div class="entry-thumb"> ' +
                                    '<a class="thumb-icon" href="https://www.youtube.com/watch?v=' + this.Youtubelink + '" target="_blank"></a> ' +
                                    '<a href="' + baseUrl + '/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto + '" alt="" style="height:30px;width:30px;" ></a> ' +
                                    '<p class="new-icon"> ' +
                                    '<span>' + this.PostTitle + '</span> ' +
                                    '</p> ' +
                                    '</div> ' +
                                    '</article> ' +
                                    '</div> ';
                                choiceContainer.append(d);
                            });
                        }
                    },
                    error: function (result) {
                        alert('5 ' + result.status + ' ' + result.statusText);
                    }
                });
            }



            //append pointsul
            function AppendPoints(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat1", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var choiceContainer = $("#pointsul");
                        appendTop5Container(choiceContainer, result);
                    },
                    error: function (result) {
                        alert('6 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //append assistul
            function AppendAssists(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat2", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var choiceContainer = $("#assistul");
                        appendTop5Container(choiceContainer, result);
                    },
                    error: function (result) {
                        alert('7 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //append reboundul
            function AppendRebound(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat3", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var choiceContainer = $("#reboundul");
                        appendTop5Container(choiceContainer, result);
                    },
                    error: function (result) {
                        alert('8 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //append stealsul
            function AppendSteals(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat4", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        var choiceContainer = $("#stealsul");
                        appendTop5Container(choiceContainer, result);
                    },
                    error: function (result) {
                        alert('9 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //append blocksul
            function AppendBlocks(omilosid) {
                return $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat5", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {

                        var choiceContainer = $("#blocksul");
                        appendTop5Container(choiceContainer, result);
                    },
                    error: function (result) {
                        alert('10 ' + result.status + ' ' + result.statusText);
                    }
                });
            }

            //apend fwtografiesid
            function AppendFwtografies(triggerevent) {

                if (triggerevent == 1) {

                    return $.ajax({
                        type: "POST",
                        url: baseUrl + '@Url.Action("GetFwtografies", "Home")',
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {

                            var choiceContainer = $("#fwtografiesid");
                            if (result.length > 0) {
                                
                                choiceContainer.empty();
                                $.each(result, function () {
                                    //d = '<img class="mySlides w3-center" src="' + this.PostPhoto + '" style="height:30%;width:100%">';
                                    
                                    d = '<img class="mySlides w3-center" src="' + this + '" style="height:30%;width:100%">';

                                    choiceContainer.append(d);
                                });

                                carousel1();

                            }
                        },
                        error: function (result) {
                            alert('15 ' + result.status + ' ' + result.statusText);
                        }
                    });

                }

            }


            $(document).ready(function () {
            
                var omilosid = $("#atlasomilosid").val();
                var triggerappendfwtos = 1;
                if (omilosid != 0) {
                    $("#fwtografiesdiv").hide();
                    triggerappendfwtos = 0;
                }
                else {
                    $("#fwtografiesdiv").show();
                    triggerappendfwtos = 1;
                }
                
            
                $.when(GetLastGames(omilosid),
                    AppendCarousel1(omilosid),
                    AppendMainCarousel(omilosid),
                    AppendLatestNews(omilosid),
                    AppendKalyteresFaseis(omilosid),
                    AppendPoints(omilosid),
                    AppendAssists(omilosid),
                    AppendRebound(omilosid),
                    AppendSteals(omilosid),
                    AppendBlocks(omilosid),
                    AppendFwtografies(triggerappendfwtos)
                    );

            });
        </script>

    End Section
