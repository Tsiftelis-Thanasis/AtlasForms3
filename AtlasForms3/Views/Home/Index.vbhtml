@Code

    Dim AtlasKathgoriaid As Integer = If(ViewBag.AtlasKathgoria Is Nothing, 0, ViewBag.AtlasKathgoria)
    Dim AtlasKathgoriaName As String = ""

    Using pdb2 As New AtlasStatisticsEntities

        If AtlasKathgoriaid > 0 Then

            AtlasKathgoriaName = (From k In pdb2.KathgoriesTable
                                  Where k.Id = AtlasKathgoriaid
                                  Select k.KathgoriaName).FirstOrDefault
        End If

    End Using

    'Dim innerTitle As String = ""
    If AtlasKathgoriaName = "" Then
        ViewData("Title") = "Κεντρική σελίδα"
    Else
        ViewData("Title") = AtlasKathgoriaName
    End If


    Dim oLastMvp = ViewBag.LastMvp
    Dim oLastDilwseis = ViewBag.LastDilwseis

    Dim oLastTop10List = ViewBag.LastTop10List

    Dim oLastGamesList = ViewBag.LastGamesList
    Dim oLastNews1 = ViewBag.LastNews1
    Dim oLastNews2 = ViewBag.LastNews2

    Dim oWeeklyStat1 = ViewBag.WeeklyStat1
    Dim oWeeklyStat2 = ViewBag.WeeklyStat2
    Dim oWeeklyStat3 = ViewBag.WeeklyStat3
    Dim oWeeklyStat4 = ViewBag.WeeklyStat4
    Dim oWeeklyStat5 = ViewBag.WeeklyStat5

    Dim oPhotosList = ViewBag.PhotosList

    Dim programmaid As Integer = 0

    Using pdb As New AtlasBlogEntities
        If AtlasKathgoriaid > 0 Then
            programmaid = (From t In pdb.BlogPostandKathgoriaTable
                           Join t2 In pdb.BlogPostsTable On t2.Id Equals t.PostId
                           Where t2.Activepost = True And t.AtlasKathgoriaId = AtlasKathgoriaid And t.KathgoriaId = 14
                           Select t.PostId).FirstOrDefault
        End If
    End Using

    Dim UserisAuthenticated As Integer = If(User.Identity Is Nothing, 0, If(User.Identity.IsAuthenticated, 1, 0))
    Dim urlwithid As String = HttpContext.Current.Request.Url.ToString
    Dim socialDesc As String = ViewData("Title")

    Dim maxlistid As Integer = 0
    Dim minlistid As Integer = 0
    If Not oLastNews2 Is Nothing Then
        If oLastNews2.count > 0 Then
            maxlistid = oLastNews2.item(0).Id
            minlistid = oLastNews2.item(oLastNews2.count - 1).Id
        End If
    End If

End Code

@Html.Hidden("atlaskathgoriaid", AtlasKathgoriaid)

@Html.Hidden("maxlistid", maxlistid)
@Html.Hidden("minlistid", minlistid)


<div class="row rowflex" >

    <div class="col-md-1 colflex panelBackground kopa-tab-1-widget">
        <a target="_blank" href="http://partner.sbaffiliates.com/processing/clickthrgh.asp?btag=a_63418b_46560&aid=" >
        <img id="sticker1" src="~/Content/images/sb1-site.jpg" class="w3-center" alt="logo" style="position:fixed;" /></a>
    </div>    


    <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10 colflex">

        <div class="panelBackground0 w3-center kopa-tab-1-widget"  style="padding-left:0px;padding-right:0px;">
            <a target="_blank" href="http://partner.sbaffiliates.com/processing/clickthrgh.asp?btag=a_63418b_46560&aid="><img src="~/Content/images/sb0-site.png" class="w3-center" alt="logo" /></a>
        </div> 

        <div id="main-content" Class="style1">

            <div Class="main-top">

                <div Class="social-links style1">
                    <ul Class="clearfix">
                        <li> <a href="https://www.facebook.com/atlasbasket.gr/" Class="fa fa-facebook"></a></li>
                        @*<li> <a href="https://twitter.com/atlasteam1" Class="fa fa-twitter"></a></li>*@
                        <li> <a href="http://www.google.com/profiles/117211032484470772194" Class="fa fa-google-plus"></a></li>
                        <li> <a href="https://www.youtube.com/channel/UCRTTtMCMaxoKT11U1MekmwQ" Class="fa fa-youtube"></a></li>
                        <li> <a href="https://www.instagram.com/atlasbasket.gr/" Class="fa fa-instagram"></a></li>
                    </ul>
                </div>

            </div>

            @code

                If AtlasKathgoriaid > 0 Then
                    @<p class="entry-categories style-s2">
                        <a style="background: #ef6018 !important" href="~/Home/Index/?ak=@AtlasKathgoriaid">Νέα</a>

                        @*<a href="~/Posts/Index/?ak=@atlaskathgoriaid"><span >λίστα με όλα τα νέα</span></a>*@

                        <a href="~/Posts/Index/?ak=@AtlasKathgoriaid&k=12"> <span>Ομάδες</span></a>
                        <a href="~/Posts/Index/?ak=@AtlasKathgoriaid&k=15"> <span>Βαθμολογία</span></a>
                        @If UserisAuthenticated > 0 Then
                            If programmaid > 0 Then
                                @*<a href="~/Posts/Details/@programmaid"> <span >Πρόγραμμα</span></a>*@
                                @<a href="/Posts/Index/?ak=@AtlasKathgoriaid&k=14"><span> Πρόγραμμα </span></a>
                            Else
                                @<a><span>Πρόγραμμα</span></a>
                            End If
                        End If
                        <a href="~/Posts/Index/?ak=@AtlasKathgoriaid&k=13"><span>Τιμωρίες</span></a>
                    </p>
                End If

            End Code

            <div Class="wrapperSmall">
                <div Class="kopa-page">
                    <div Class="widget kopa-tab-score-widget">
                        <div Class="kopa-tab style1">
                            <div Class="tab-content">
                                <div Class="tab-pane active" id="agroup">
                                    <div id="lastgamescarouselid" Class="owl-carousel owl-carousel-1">
                                        @code
                                            For Each g In oLastGamesList
                                                @<div Class="item">
                                                    <div Class="entry-item">
                                                        <a target="_blank" href="http://www.atlasstatistics.gr/Games/Details/@g.Id">
                                                            <p>@g.Gamedate</p>
                                                            <ul Class="clearfix">
                                                                <li>
                                                                    <span title=@g.team1>@g.team1</span>
                                                                    <span>@g.team1score</span>
                                                                </li>
                                                                <li>
                                                                    <span title=@g.team2>@g.team2</span>
                                                                    <span>@g.team2score</span>
                                                                </li>
                                                            </ul>
                                                        </a>
                                                    </div>
                                                </div>
                                            Next
                                        End Code
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            @*<div class="container">
                    
                <div class="row">
                    <div class="col-md-12">
                        <div class="carousel carousel-showsixmoveone slide" id="carousellastgames">
                            <div class="carousel-inner">
                                <div class="item active">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/0054A6/fff/&amp;text=1" class="img-responsive"></a></div>
                                </div>
                                <div class="item">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/002d5a/fff/&amp;text=2" class="img-responsive"></a></div>
                                </div>
                                <div class="item">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/d6d6d6/333&amp;text=3" class="img-responsive"></a></div>
                                </div>
                                <div class="item">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/002040/eeeeee&amp;text=4" class="img-responsive"></a></div>
                                </div>
                                <div class="item">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/0054A6/fff/&amp;text=5" class="img-responsive"></a></div>
                                </div>
                                <div class="item">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/002d5a/fff/&amp;text=6" class="img-responsive"></a></div>
                                </div>
                                <div class="item">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/eeeeee&amp;text=7" class="img-responsive"></a></div>
                                </div>
                                <div class="item">
                                    <div class="col-xs-12 col-sm-4 col-md-2"><a href="#"><img src="http://placehold.it/500/40a1ff/002040&amp;text=8" class="img-responsive"></a></div>
                                </div>
                            </div>
                            <a class="left carousel-control" href="#carousellastgames" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>
                            <a class="right carousel-control" href="#carousellastgames" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>
                        </div>
                    </div>
                </div>
            </div>*@


            <div Class="wrapperSmall mb-30">
              
                <div class="kopa-tab-1-widget">
                    <div id="carousel1" class="carousel slide" >

                        <ol class="carousel-indicators">

                            @code
                                Dim i As Integer = 0
                                For Each n In oLastNews1
                                    If i = 0 Then
                                        @<li data-target="#carousel1" data-slide-To=@i Class="active"></li>
                                    Else
                                        @<li data-target="#carousel1" data-slide-To=@i></li>
                                    End If
                                    i += 1
                                Next
                            End Code


                        </ol>

                        <div class="carousel-inner" role="listbox">

                            @code
                                Dim j As Integer = 0
                                For Each n In oLastNews1
                                    If j = 0 Then
                                        @<div Class="item active">
                                            <div Class="entry-thumb w3-center">
                                                <a href="/Posts/Details/@n.Id">
                                                    <img class="d-block img-fluid" src="@n.PostPhoto" style="height:480px;width:1024px;" alt="">
                                                </a>
                                            </div>

                                            <div Class="carousel-caption d-none d-md-block">
                                                <h4 Class="entry-title entry-title2"><a href="/Posts/Details/@n.Id">@n.PostTitle</a></h4>
                                            </div>
                                        </div>
                                    Else
                                        @<div class="item">
                                            <div Class="entry-thumb w3-center">
                                                <a href="/Posts/Details/@n.Id">
                                                    <img class="d-block img-fluid" src="@n.PostPhoto" style="height:480px;width:1024px;" alt="">
                                                </a>
                                            </div>

                                            <div Class="carousel-caption d-none d-md-block">
                                                <h4 Class="entry-title entry-title2"><a href="/Posts/Details/@n.Id">@n.PostTitle</a></h4>
                                            </div>
                                        </div>

                                    End If

                                    j += 1
                                Next
                            End Code

                        </div>

                        <a class="left carousel-control" href="#carousel1" role="button" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>                            
                        </a>
                        <a class="right carousel-control" href="#carousel1" role="button" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>                            
                        </a>

                    </div>
                </div>


            <p></p>

                    <div Class="wrapperSmall">
                        <div Class="content-wrap">



                            @*<div class="row">
                                <div Class="kopa-main-col">
                                    <div Class="widget-area-1">
                                        <div Class="widget kopa-tab-sync-carousel-widget">
                                            <h3 Class="widget-title style1">TOP 10</h3>
                                            <div class="col-xs-12" id="slider">
                                                <!-- Top part of the slider -->
                                                <div class="row">
                                                    <div class="col-sm-8" id="carousel-bounding-box">
                                                        <div class="carousel slide" id="myCarousel">
                                                            <!-- Carousel items -->
                                                            <div class="carousel-inner">
                                                                <div class="active item" data-slide-number="0">
                                                                    <img src="http://placehold.it/770x300&text=one">
                                                                </div>
                                                                <div class="item" data-slide-number="1">
                                                                    <img src="http://placehold.it/770x300&text=two">
                                                                </div>
                                                                <div class="item" data-slide-number="2">
                                                                    <img src="http://placehold.it/770x300&text=three">
                                                                </div>
                                                                <div class="item" data-slide-number="3">
                                                                    <img src="http://placehold.it/770x300&text=four">
                                                                </div>
                                                                <div class="item" data-slide-number="4">
                                                                    <img src="http://placehold.it/770x300&text=five">
                                                                </div>
                                                                <div class="item" data-slide-number="5">
                                                                    <img src="http://placehold.it/770x300&text=six">
                                                                </div>
                                                            </div><!-- Carousel nav -->

                                                        </div>
                                                    </div>

                                                </div>


                                                <!-- Bottom switcher of slider -->
                                                <ul class="hide-bullets">
                                                    <li class="col-sm-2">
                                                        <a class="thumbnail" id="carousel-selector-0"><img src="http://placehold.it/170x100&text=one"></a>
                                                    </li>
                                                    <li class="col-sm-2">
                                                        <a class="thumbnail" id="carousel-selector-1"><img src="http://placehold.it/170x100&text=two"></a>
                                                    </li>
                                                    <li class="col-sm-2">
                                                        <a class="thumbnail" id="carousel-selector-2"><img src="http://placehold.it/170x100&text=three"></a>
                                                    </li>
                                                    <li class="col-sm-2">
                                                        <a class="thumbnail" id="carousel-selector-3"><img src="http://placehold.it/170x100&text=four"></a>
                                                    </li>
                                                    <li class="col-sm-2">
                                                        <a class="thumbnail" id="carousel-selector-4"><img src="http://placehold.it/170x100&text=five"></a>
                                                    </li>
                                                </ul>
                                            </div><!--/Slider-->

                                           
                                             
                                        </div>
                                    </div>
                                </div>*@

                            <div Class="row">
                                <div Class="kopa-main-col">

                                    @code

                                            @If oLastTop10List.count > 0 And AtlasKathgoriaid = 0 Then

                                            @<div Class="widget-area-1">

                                                <div Class="widget kopa-tab-sync-carousel-widget">
                                                    <h3 Class="widget-title style1"><a href="/Posts/Index/?ak=@AtlasKathgoriaid&k=16&sl=1"><span>TOP 10</span></a></h3>
                                                    <div Class="widget kopa-sync-carousel-2-widget">

                                                        <div Class="owl-carousel sync3" id="watchsync3">

                                                            @For Each o In oLastTop10List
                                                            @<div Class="item">
                                                                <article class="entry-item video-post">
                                                                    <div class="entry-thumb w3-center">
                                                                        @*<a href="/Posts/Details/@o.Id"><img src="@o.PostPhoto" alt="" style="height:320px;width:640px;"></a>
                                                                        <a class="thumb-icon" href="https://www.youtube.com/watch?v=@o.Youtubelink" target="_blank"></a>*@
                                                                        <a href="/Posts/Details/@o.Id"><img src="@o.PostPhoto" alt="" style="height:320px;width:640px;">
                                                                            <span class="thumb-icon" ></span></a>
                                                                    </div>
                                                                    <div class="entry-content">
                                                                        <h3 class=""><a href="/Posts/Details/@o.Id">@o.PostTitle</a></h3>
                                                                    </div>
                                                                </article>
                                                            </div>
                                                            Next

                                                        </div>

                                                        <div Class="owl-carousel sync4" id="watchsync4">

                                                            @For Each o1 In oLastTop10List
                                                                @<div Class="item">
                                                                    <article Class="entry-item video-post">
                                                                        <div Class="entry-thumb">
                                                                            @*<a href="/Posts/Details/@o1.Id"><img src="@o1.PostPhoto2" alt="" style="height:100px;width:120px;"></a>
                                                                            <a class="thumb-icon" href="https://www.youtube.com/watch?v=@o1.Youtubelink" target="_blank"></a>*@
                                                                            <a href="/Posts/Details/@o1.Id">
                                                                                <img src="@o1.PostPhoto2" alt="" style="height:100px;width:120px;">
                                                                                <span class="thumb-icon"></span>
                                                                            </a>
                                                                        </div>
                                                                        <div Class="entry-content">
                                                                            <h4 Class="entry-title"><a href="/Posts/Details/@o1.Id">@o1.PostTitle</a></h4>
                                                                        </div>
                                                                    </article>
                                                                </div>
                                                            Next

                                                        </div>



                                                    </div>


                                                </div>
                                            </div>

                                            End If
                                    End Code




                                    @code

                                            @If oLastMvp.count > 0 And AtlasKathgoriaid > 0 Then
                                            @<div Class="widget-area-1">
                                                <div Class="widget kopa-tab-1-widget kopa-point-widget">
                                                    <h3 Class="widget-title style1"><a href="/Posts/Index/?ak=@AtlasKathgoriaid&k=6&sl=1"><span>MVP</span></a></h3>

                                                    <div Class="owl-carousel owl-carousel-1 sync22" id="watchsync3">

                                                        @For Each o In oLastMvp
                                                @<div Class="item">
                                                    <article class="entry-item ">
                                                        <div class="entry-thumb w3-center">
                                                            <a href="/Posts/Details/@o.Id"><img src="@o.PostPhoto" alt="" style="height:160px;width:auto;"></a>                                                            
                                                        </div>
                                                        <div class="entry-content widget-title style7 kopa-point-widget">
                                                            <h5 class=""><a style="color: #ffffff !important;" href="/Posts/Details/@o.Id">@o.PostTitle</a></h5>
                                                        </div>
                                                    </article>
                                                </div>
                                                        Next

                                                    </div>

                                                </div>
                                            </div>
                                            End If

                                    End Code

                                    @code

                                            @If oLastDilwseis.count > 0 And AtlasKathgoriaid > 0 Then
                                            @<div Class="widget-area-1">
                                                <div Class="widget kopa-tab-1-widget kopa-point-widget">

                                                    <h3 Class="widget-title style1"><a href="/Posts/Index/?ak=@AtlasKathgoriaid&k=17&sl=1"><span>Δηλώσεις</span></a></h3>
                                                    <div Class="owl-carousel owl-carousel-1 sync22" id="watchsync4">

                                                        @For Each o1 In oLastDilwseis

                                                            @<div Class="item kopa-point-widget">
                                                                <article Class="entry-item video-post">
                                                                    <div Class="entry-thumb">
                                                                        @*<a href="/Posts/Details/@o1.Id"><img src="@o1.PostPhoto2" alt="" style="height:100px;width:120px;"></a>
                                                                        <a class="thumb-icon" href="https://www.youtube.com/watch?v=@o1.Youtubelink" target="_blank"></a>*@
                                                                        <a href="/Posts/Details/@o1.Id"><img src="@o1.PostPhoto2" alt="" style="height:100px;width:120px;">
                                                                        <span class="thumb-icon" ></span></a>

                                                                    </div>
                                                                    <div Class="entry-content">
                                                                        <h5 Class="entry-title"><a href="/Posts/Details/@o1.Id">
                                                                            <span style="width:95%;word-wrap: break-word;">
                                                                                @o1.PostTitle                                
                                                                            </span>                                                                        
                                                                            </a></h5>
                                                                    </div>
                                                                </article>
                                                            </div>
                                                        Next
                                                    </div>
                                                </div>
                                            </div>

                                            End If
                                            End code                        


                                    <div Class="widget kopa-article-list-widget article-list-1" id="lastnewsscrollid">

                                        @code
                                            If AtlasKathgoriaid > 0 Then
                                                @<h3 Class="widget-title style2"><a href="/Posts/Index/?ak=@AtlasKathgoriaid&k=11&sl=1"><span>Νέα Ομίλου</span></a></h3>
                                            Else
                                                @<h3 Class="widget-title style2"><a href="/Posts/Index/?ak=@AtlasKathgoriaid&k=3&sl=1"><span>Νέα Διοργάνωσης</span></a></h3>
                                            End If

                                                @<ul id="latestnewsid" Class="clearfix">

                                                    @For Each n In oLastNews2
                                                        Dim postsummarystr = If(n.postsummary Is Nothing, "", n.postsummary)
                                                        @<li>
                                                            <article Class="entry-item disable-select ">
                                                                <div Class="entry-thumb">
                                                                    <a href="/Posts/Details/@n.Id"><img src="@n.PostPhoto2" alt="" /></a>
                                                                </div>
                                                                <div Class="entry-content">
                                                                    <div Class="content-top">
                                                                        <h4 Class="entry-title"><a href="/Posts/Details/@n.Id">@n.PostTitle</a></h4>
                                                                    </div>
                                                                    <p> @postsummarystr ... </p>
                                                                </div>
                                                            </article>
                                                        </li>
                                                    Next
                                                </ul>

                                            @<div class="row entry-categories style-s2">

                                                <div class="col-md-6 col-xs-6 w3-left-align ">
                                                <a id="newerpage"  class="lipointer">
                                                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"> </span>
                                                    Πρόσφατα άρθρα
                                                </a>
                                                </div>
                                             
                                                <div class="col-md-6 col-xs-6 w3-right-align ">

                                                <a id="olderpage" class="lipointer">
                                                Παλιότερα άρθρα
                                                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"> </span>
                                                </a>
                                                </div>        
                                                                              
                                            </div>
                                    End code
                                    </div>
                                </div>

                                <div Class="sidebar widget-area-11">
                                    <div Class="widget kopa-tab-1-widget kopa-point-widget">
                                        <div Class="row form-horizontal w3-center">
                                            <a target="_blank"
                                               href="https://www.facebook.com/sharer/sharer.php?u=@urlwithid&display=popup&ref=plugin&src=like&kid_directed_site=0&app_id=140586622674265">
                                                <img src="~/Content/images/facebook-icon.png">
                                            </a>                                          
                                        </div>
                                        
                                        <p></p>

                                        <div  id="facebookshareid">
                                          
                                            <div class="fb-page" data-href="https://www.facebook.com/atlasbasket.gr/" data-small-header="false"
                                                  data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="false">
                                            <blockquote cite="https://www.facebook.com/atlasbasket.gr/" class="fb-xfbml-parse-ignore">
                                                <a href="https://www.facebook.com/atlasbasket.gr/">atlasbasket.gr</a></blockquote></div>

                                        </div>


                                    </div>
                                </div>

                                <div Class="sidebar widget-area-11">

                                    <div Class="widget kopa-tab-1-widget kopa-point-widget">
                                        <a href="http://www.blue-ice.gr/"><img src="~/Content/images/blueiceok.png" alt=""></a>
                                        <a href="https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"><img src="~/Content/images/risko.jpg" alt=""></a>
                                        <a href="http://www.atlassportswear.gr/"><img src="~/Content/images/atlassportwear.png" alt=""></a>
                                    </div>

                                    <div Class="widget kopa-tab-1-widget kopa-point-widget">
                                        <h3 Class="widget-title style5"><span class="fa fa-trophy"></span>Κορυφαίοι της εβδομάδας</h3>
                                        <ul Class="clearfix">
                                            <li>
                                                <div Class="kopa-tab style3">
                                                    <ul Class="nav nav-tabs">
                                                        <li Class="active"><a href="#points" data-toggle="tab">Πον.</a></li>
                                                        <li> <a href="#assist" data-toggle="tab">ΑΣ.</a></li>
                                                        <li> <a href="#reb" data-toggle="tab">Ριμ.</a></li>
                                                        <li> <a href="#steal" data-toggle="tab">Κλ.</a></li>
                                                        <li> <a href="#block" data-toggle="tab">Κοψ.</a></li>
                                                    </ul>

                                                    <div Class="tab-content">
                                                        <div Class="tab-pane active" id="points">
                                                            <ul Class="kopa-list clearfix" id="pointsul">

                                                                @code
                                                                    Dim p As Integer = 1
                                                                    For Each stat In oWeeklyStat1

                                                                        Dim _photo As String = stat.pphoto.ToString
                                                                        If _photo = "" Then
                                                                            _photo = "/Content/images/icons8-Basketball-Player-50.png"
                                                                        End If


                                                                        @<li>
                                                                            <div class="point-item">
                                                                                <div class="point-left">
                                                                                    <div class="point-thumb">
                                                                                        <img src=@_photo alt="" />
                                                                                        <span>@p</span>
                                                                                    </div>
                                                                                    <div class="point-content">
                                                                                        <p><a href="http://atlasstatistics.gr/Players/Details/@stat.pid">@stat.pname</a></p>
                                                                                        <p><span><a href="http://atlasstatistics.gr/Teams/Details/@stat.tid">@stat.tname</a></span></p>
                                                                                        <span>@stat.omilosname</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="point-right">
                                                                                    <p>@stat.val</p>
                                                                                    <span> </span>
                                                                                </div>
                                                                            </div>
                                                                        </li>

                                                                        p += 1

                                                                    Next

                                                                End Code


                                                            </ul>
                                                        </div>

                                                        <div Class="tab-pane" id="assist">
                                                            <ul Class="kopa-list clearfix" id="assistul">


                                                                @code
                                                                    p = 1
                                                                    For Each stat In oWeeklyStat2

                                                                        Dim _photo As String = stat.pphoto.ToString
                                                                        If _photo = "" Then
                                                                            _photo = "/Content/images/icons8-Basketball-Player-50.png"
                                                                        End If


                                                                        @<li>
                                                                            <div class="point-item">
                                                                                <div class="point-left">
                                                                                    <div class="point-thumb">
                                                                                        <img src=@_photo alt="" />
                                                                                        <span>@p</span>
                                                                                    </div>
                                                                                    <div class="point-content">
                                                                                        <p><a href="http://atlasstatistics.gr/Players/Details/@stat.pid">@stat.pname</a></p>
                                                                                        <p><span><a href="http://atlasstatistics.gr/Teams/Details/@stat.tid">@stat.tname</a></span></p>
                                                                                        <span>@stat.omilosname</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="point-right">
                                                                                    <p>@stat.val</p>
                                                                                    <span> </span>
                                                                                </div>
                                                                            </div>
                                                                        </li>

                                                                        p += 1

                                                                    Next

                                                                End Code


                                                            </ul>
                                                        </div>

                                                        <div Class="tab-pane" id="reb">
                                                            <ul Class="kopa-list clearfix" id="reboundul">

                                                                @code
                                                                    p = 1
                                                                    For Each stat In oWeeklyStat3

                                                                        Dim _photo As String = stat.pphoto.ToString
                                                                        If _photo = "" Then
                                                                            _photo = "/Content/images/icons8-Basketball-Player-50.png"
                                                                        End If


                                                                        @<li>
                                                                            <div class="point-item">
                                                                                <div class="point-left">
                                                                                    <div class="point-thumb">
                                                                                        <img src=@_photo alt="" />
                                                                                        <span>@p</span>
                                                                                    </div>
                                                                                    <div class="point-content">
                                                                                        <p><a href="http://atlasstatistics.gr/Players/Details/@stat.pid">@stat.pname</a></p>
                                                                                        <p><span><a href="http://atlasstatistics.gr/Teams/Details/@stat.tid">@stat.tname</a></span></p>
                                                                                        <span>@stat.omilosname</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="point-right">
                                                                                    <p>@stat.val</p>
                                                                                    <span> </span>
                                                                                </div>
                                                                            </div>
                                                                        </li>

                                                                        p += 1

                                                                    Next

                                                                End Code

                                                            </ul>
                                                        </div>

                                                        <div Class="tab-pane" id="steal">
                                                            <ul Class="kopa-list clearfix" id="stealsul">

                                                                @code
                                                                    p = 1
                                                                    For Each stat In oWeeklyStat4

                                                                        Dim _photo As String = stat.pphoto.ToString
                                                                        If _photo = "" Then
                                                                            _photo = "/Content/images/icons8-Basketball-Player-50.png"
                                                                        End If


                                                                        @<li>
                                                                            <div class="point-item">
                                                                                <div class="point-left">
                                                                                    <div class="point-thumb">
                                                                                        <img src=@_photo alt="" />
                                                                                        <span>@p</span>
                                                                                    </div>
                                                                                    <div class="point-content">
                                                                                        <p><a href="http://atlasstatistics.gr/Players/Details/@stat.pid">@stat.pname</a></p>
                                                                                        <p><span><a href="http://atlasstatistics.gr/Teams/Details/@stat.tid">@stat.tname</a></span></p>
                                                                                        <span>@stat.omilosname</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="point-right">
                                                                                    <p>@stat.val</p>
                                                                                    <span> </span>
                                                                                </div>
                                                                            </div>
                                                                        </li>

                                                                        p += 1

                                                                    Next

                                                                End Code


                                                            </ul>
                                                        </div>

                                                        <div Class="tab-pane" id="block">
                                                            <ul Class="kopa-list clearfix" id="blocksul">

                                                                @code
                                                                    p = 1
                                                                    For Each stat In oWeeklyStat5

                                                                        Dim _photo As String = stat.pphoto.ToString
                                                                        If _photo = "" Then
                                                                            _photo = "/Content/images/icons8-Basketball-Player-50.png"
                                                                        End If


                                                                        @<li>
                                                                            <div class="point-item">
                                                                                <div class="point-left">
                                                                                    <div class="point-thumb">
                                                                                        <img src=@_photo alt="" />
                                                                                        <span>@p</span>
                                                                                    </div>
                                                                                    <div class="point-content">
                                                                                        <p><a href="http://atlasstatistics.gr/Players/Details/@stat.pid">@stat.pname</a></p>
                                                                                        <p><span><a href="http://atlasstatistics.gr/Teams/Details/@stat.tid">@stat.tname</a></span></p>
                                                                                        <span>@stat.omilosname</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="point-right">
                                                                                    <p>@stat.val</p>
                                                                                    <span> </span>
                                                                                </div>
                                                                            </div>
                                                                        </li>

                                                                        p += 1

                                                                    Next

                                                                End Code


                                                            </ul>
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
               
          
            <div Class="w3-center  widget kopa-tab-1-widget kopa-point-widget">

                <a href="http://praxis-ygeias.gr/"><img src="~/Content/images/praksis.png" alt=""></a>
                <p></p>

            </div>

            <div Class="widget-area-24 kopa-area kopa-area-2 w3-center" id="fwtografiesdiv">

                <h2 Class="widget-title style9"><span><b>Φωτογραφιες</b></span></h2>

                <div Class="widget kopa-tab-1-widget kopa-point-widget">

                    <div Class="row">
                        <div Class="widget-area-11">
                            <div Class="w3-content w3-section" style="max-width:45%" id="fwtografiesid">
                                @code
                                    For each _p In oPhotosList
                                        @<img Class="mySlides w3-center" src=@_p style="height:30%;width:100%">
                                    Next
                                End Code
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
         

    <div class="col-md-1 colflex panelBackground kopa-tab-1-widget">
        <a target="_blank" href="http://partner.sbaffiliates.com/processing/clickthrgh.asp?btag=a_63418b_46560&aid=" >
        <img id="sticker2" src="~/Content/images/sb2-site.jpg" class="w3-center" alt="logo" style="position:fixed;" /></a>
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

            carousel1();


            function coverflow(i, el) {
                el.removeClass('pre following')
                    .nextAll()
                        .removeClass('pre following')
                        .addClass('following')
                    .end()
                    .prevAll()
                        .removeClass('pre following')
                        .addClass('pre');
            }

            (function () {
                $('.carousel-showsixmoveone .item').each(function () {
                    var itemToClone = $(this);

                    for (var i = 1; i < 6; i++) {
                        itemToClone = itemToClone.next();

                        // wrap around if at end of item collection
                        if (!itemToClone.length) {
                            itemToClone = $(this).siblings(':first');
                        }

                        // grab item, clone, add marker class, add to collection
                        itemToClone.children(':first-child').clone()
                          .addClass("cloneditem-" + (i))
                          .appendTo($(this));
                    }
                });
            }());


            $(document).ready(function () {

                $('.carousel-control').click(function (e) {
                    e.preventDefault();
                    $('#carousel1').carousel($(this).data());
                    $('#carousellastgames').carousel($(this).data());
                });

                var omilosid = $("#atlaskathgoriaid").val();
                var triggerappendfwtos = 1;
                if (omilosid != 0) {
                    $("#fwtografiesdiv").hide();
                    $("#carousel2").hide();
                    $("#facebookshareid").hide();
                    triggerappendfwtos = 0;
                }
                else {
                    $("#fwtografiesdiv").show();
                    $("#carousel2").hide();
                    $("#facebookshareid").show();
                    triggerappendfwtos = 1;
                }



                $('#newerpage').click(function () {

                    if ($("#maxlistid").val() > 0) {

                        info = [];
                        info[0] = 3;
                        info[1] = 11;
                        //info[2] = 13;

                        $.ajax({
                            type: "POST",
                            url: baseUrl + '@Url.Action("GetLastNewsPaging", "Home")',
                            data: "{nCount: 10,  kathgories: " + JSON.stringify(info) + ", atlaskathgoria: " + $("#atlaskathgoriaid").val() + ", " +
                                  " maxid:  " + $("#maxlistid").val() + ", minid: 0}",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                var choiceContainer = $("#latestnewsid");
                                if (result.data.length > 0) {

                                    choiceContainer.empty();
                                    var d = '';
                                    var cnt = 0;
                                    var min1 = 999999999;
                                    var max1 = 0;


                                    $.each(result.data, function () {

                                        if (min1 => this.Id) {
                                            min1 = this.Id;
                                        }

                                        if (max1 <= this.Id) {
                                            max1 = this.Id;
                                        }

                                        var postdd = '';
                                        if (this.postsummarystr != null) {
                                            postdd = this.postsummarystr;
                                        }
                                        
                                        d = '<li> ' +
                                            ' <article Class="entry-item disable-select ">' +
                                            ' <div Class="entry-thumb">' +
                                            ' <a href="/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto2 + '" alt="" /></a>' +
                                            ' </div>' +
                                            ' <div Class="entry-content">' +
                                            ' <div Class="content-top">' +
                                            ' <h4 Class="entry-title"><a href="/Posts/Details/' + this.Id + '">' + this.PostTitle + '</a></h4>' +
                                            ' </div>' +
                                            ' <p> ' + postdd + '... </p>' +
                                            ' </div>' +
                                            ' </article>' +
                                            ' </li>';
                                        choiceContainer.append(d);
                                        //cnt++;
                                    });

                                    $("#minlistid").val(min1);
                                    $("#maxlistid").val(max1);

                                    $(document).scrollTop($("#lastnewsscrollid").offset().top);
                                }
                            },
                            error: function (result) {
                            }
                        });
                    }
                });

                $('#olderpage').click(function () {

                    if ($("#minlistid").val() > 0) {
                        
                        info = [];
                        info[0] = 3;
                        info[1] = 11;
                        //info[2] = 13;
                
                        $.ajax({
                            type: "POST",
                            url: baseUrl + '@Url.Action("GetLastNewsPaging", "Home")',
                            data: "{nCount: 10,  kathgories: " + JSON.stringify(info) + ", atlaskathgoria: " + $("#atlaskathgoriaid").val() + ", " +
                                    " maxid: 0, minid: " + $("#minlistid").val() + "}",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                
                                var choiceContainer = $("#latestnewsid");
                                if (result.data.length > 0) {

                                    choiceContainer.empty();
                                    var d ='';
                                    var cnt = 0;
                                    var min1 = 999999999;
                                    var max1 = 0;


                                    $.each(result.data, function () {
                                    
                                        if (min1 => this.Id) {
                                            min1 = this.Id;
                                        }

                                        if (max1 <= this.Id) {
                                            max1 = this.Id;
                                        }

                                        var postdd = '';
                                        if (this.postsummarystr != null) {
                                            postdd = this.postsummarystr;
                                        }                                        
                                        
                                        d = '<li> ' +
                                            ' <article Class="entry-item disable-select ">' +
                                            ' <div Class="entry-thumb">' +
                                            ' <a href="/Posts/Details/' + this.Id + '"><img src="' + this.PostPhoto2 + '" alt="" /></a>' +
                                            ' </div>' +
                                            ' <div Class="entry-content">' +
                                            ' <div Class="content-top">' +
                                            ' <h4 Class="entry-title"><a href="/Posts/Details/' + this.Id + '">' + this.PostTitle + '</a></h4>' +
                                            ' </div>' +
                                            ' <p> ' + postdd + '... </p>' +
                                            ' </div>' +
                                            ' </article>' +
                                            ' </li>';
                                        choiceContainer.append(d);
                                        
                                    });

                                    $("#minlistid").val(min1);
                                    $("#maxlistid").val(max1);

                                    $(document).scrollTop($("#lastnewsscrollid").offset().top);

                                }
                            },
                            error: function (result) {
                                alert(result.status + ' ' + result.statusText);
                            }
                        });
                    }

                 });

            });
</script>

 End Section

