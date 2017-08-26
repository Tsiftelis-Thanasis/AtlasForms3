@Code



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
        ViewData("Title") = "ατλας μπασκετ"
    Else
        If atlasomilosname.Count < 2 Then
            atlasomilosname = atlasomilosname & " Όμιλος"
        End If

        ViewData("Title") = atlasomilosname
    End If


End Code


@Html.Hidden("atlasomilosid", atlasomilosid)


<div id = "main-content" Class="style1">


    <div Class="main-top">



        <div Class="social-links style1">
            <ul Class="clearfix">
                <li> <a href = "#" Class="fa fa-facebook"></a></li>
                <li> <a href = "#" Class="fa fa-twitter"></a></li>
                <li> <a href = "#" Class="fa fa-google-plus"></a></li>
                <li> <a href = "#" Class="fa fa-instagram"></a></li>
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
                                <div id = "lastgamescarouselid" Class="owl-carousel owl-carousel-1">

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

    <div Class="widget-area-24 kopa-area kopa-area-2">

        <div Class="widget kopa-product-list-widget">
            <h3 Class="widget-title style10">καλυτερες φασεις -- > Gallery !</h3>
            <div Class="content-wrap">
                <div Class="row">
                    <div id = "kalyteresfaseisid" Class="owl-carousel owl-carousel-4">
                    </div>                   
                </div>                
            </div>
        </div>       
    </div>    
        </div>
  

@Section Scripts        
 <script type="text/javascript">

    //append lastgames carouselid
     function GetLastGames(omilosid) {
        return $.ajaxQueue({
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
                alert(result.status + ' ' + result.statusText);
            }
        });
    }


    //append carousel sync3 and sync4
     function AppendCarousel1(omilosid) {
        return $.ajaxQueue({
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
                            '       <a href="' + baseUrl + '/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto + '" alt="" style="height:100px;width:100px;"></a> ' +
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
                alert(result.status + ' ' + result.statusText);
            }
        });
    }

    //append mainnewscarouselid               
     function AppendMainCarousel(omilosid) {
        return $.ajaxQueue({
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
                alert(result.status + ' ' + result.statusText);
            }
        });
    }

    //apend latestnewsid
     function AppendLatestNews(omilosid) {
        return $.ajaxQueue({
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
                            ' <a href="#"><img src="' + this.PostPhoto + '" alt=""></a> ' +
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
                alert(result.status + ' ' + result.statusText);
            }
        });
    }

    //apend kalyteresfaseisid
     function AppendKalyteresFaseis(omilosid) {
        return $.ajaxQueue({
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
                            '<a href="' + baseUrl + '/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto + '" alt="" height:30px;width:30px; ></a> ' +
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
                alert(result.status + ' ' + result.statusText);
            }
        });
    }





     //append pointsul
     function AppendPoints(omilosid) {
         return $.ajaxQueue({
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
                 alert(result.status + ' ' + result.statusText);
             }
         });
     }

     //append assistul
     function AppendAssists(omilosid) {
         return $.ajaxQueue({
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
                 alert(result.status + ' ' + result.statusText);
             }
         });
     }

     //append reboundul
     function AppendRebound(omilosid) {
         return $.ajaxQueue({
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
                 alert(result.status + ' ' + result.statusText);
             }
         });
     }

     //append stealsul
     function AppendSteals(omilosid) {
         return $.ajaxQueue({
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
                 alert(result.status + ' ' + result.statusText);
             }
         });
     }

     //append blocksul
     function AppendBlocks(omilosid) {
         return $.ajaxQueue({
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
                 alert(result.status + ' ' + result.statusText);
             }
         });
     }



            $(document).ready(function () {



                (function ($) {

                    // jQuery on an empty object, we are going to use this as our Queue
                    var ajaxQueue = $({});

                    $.ajaxQueue = function (ajaxOpts) {
                        var jqXHR,
                            dfd = $.Deferred(),
                            promise = dfd.promise();

                        // queue our ajax request
                        ajaxQueue.queue(doRequest);

                        // add the abort method
                        promise.abort = function (statusText) {

                            // proxy abort to the jqXHR if it is active
                            if (jqXHR) {
                                return jqXHR.abort(statusText);
                            }

                            // if there wasn't already a jqXHR we need to remove from queue
                            var queue = ajaxQueue.queue(),
                                index = $.inArray(doRequest, queue);

                            if (index > -1) {
                                queue.splice(index, 1);
                            }

                            // and then reject the deferred
                            dfd.rejectWith(ajaxOpts.context || ajaxOpts,
                                [promise, statusText, ""]);

                            return promise;
                        };

                        // run the actual query
                        function doRequest(next) {
                            jqXHR = $.ajax(ajaxOpts)
                                .then(next, next)
                                .done(dfd.resolve)
                                .fail(dfd.reject);
                        }

                        return promise;
                    };
                })(jQuery);

                var omilosid = $("#atlasomilosid").val();


                var newPromise = $.Deferred();

                $.when(newPromise).done(function () {
                    
                });

                newPromise.always(function () {
                    GetLastGames(omilosid);
                }).always(function () {                    
                    AppendCarousel1(omilosid);
                }).always(function () {
                    AppendMainCarousel(omilosid);
                }).always(function () {
                    AppendLatestNews(omilosid);
                }).always(function () {
                    AppendKalyteresFaseis(omilosid);
                }).always(function () {
                    AppendPoints(omilosid);
                }).always(function () {
                    AppendAssists(omilosid);
                }).always(function () {
                    AppendRebound(omilosid);
                }).always(function () {
                    AppendSteals(omilosid);
                }).always(function () {
                    AppendBlocks(omilosid);
                });
                                
               


                //newPromise.resolve();

                
                $.when(GetLastGames(omilosid),
                    AppendCarousel1(omilosid),
                    AppendMainCarousel(omilosid),
                    AppendLatestNews(omilosid),
                    AppendKalyteresFaseis(omilosid),
                    AppendPoints(omilosid),
                    AppendAssists(omilosid),
                    AppendRebound(omilosid),
                    AppendSteals(omilosid),
                    AppendBlocks(omilosid)
                    );
                

                @*$.ajax({
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
                        alert(result.status + ' ' + result.statusText);
                    }
                });*@


            });
        </script>

    End Section
