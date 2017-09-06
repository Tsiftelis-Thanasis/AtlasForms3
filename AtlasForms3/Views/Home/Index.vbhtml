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


    Dim oLastNewsList = ViewBag.LastNewsList
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


End Code

@Html.Hidden("atlaskathgoriaid", AtlasKathgoriaid)

<div id="main-content" Class="style1">

    <div Class="main-top"> 

        <div Class="social-links style1">
            <ul Class="clearfix">
                <li> <a href="https://www.facebook.com/atlasbasket.gr/" Class="fa fa-facebook"></a></li>
                <li> <a href="https://twitter.com/atlasteam1" Class="fa fa-twitter"></a></li>
                <li> <a href="http://www.google.com/profiles/117211032484470772194" Class="fa fa-google-plus"></a></li>
                <li> <a href="https://www.youtube.com/channel/UCRTTtMCMaxoKT11U1MekmwQ" Class="fa fa-youtube"></a></li>
                <li> <a href="https://www.instagram.com/atlasbasket.gr/" Class="fa fa-instagram"></a></li>
            </ul>
        </div>
        
    </div>

    @code

        If AtlasKathgoriaid > 0 Then
            @<p class="entry-categories style-s">
                <a style="background: #ef6018; !important" href="~/Home/Index/?ak=@AtlasKathgoriaid">Νέα</a>
                 
                @*<a href="~/Posts/Index/?ak=@atlaskathgoriaid"><span style="font-size: 12px; !important">λίστα με όλα τα νέα</span></a>*@
                 
                <a href="~/Posts/Index/?ak=@AtlasKathgoriaid&k=12"> <span style="font-size: 12px; !important">Ομαδες</span></a>
                <a href="~/Posts/Index/?ak=@AtlasKathgoriaid&k=15"> <span style="font-size: 12px; !important">Βαθμολογια</span></a>                                
                 @If UserisAuthenticated > 0 Then
                    If programmaid > 0 Then
                         @<a href="~/Posts/Details/@programmaid"> <span style="font-size: 12px; !important">Προγραμμα</span></a>
                     Else
                     @<a><span style="font-size: 12px; !important">Προγραμμα</span></a>
                     End If
                 End If
                 <a href="~/Posts/Index/?ak=@AtlasKathgoriaid&k=13"><span style="font-size: 12px; !important">Τιμωριες</span></a>
            </p>
        End If

    End Code

    <div Class="wrapper">
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
                                                <a  target = "_blank" href="http://www.atlasstatistics.gr/Games/Details/@g.Id">
                                                <p>@g.Gamedate</p>
                                                <ul Class="clearfix"> 
                                                    <li> 
                                                        <span title = @g.team1 >@g.team1</span> 
                                                        <span>@g.team1score</span>
                                                    </li> 
                                                    <li>
                                                        <span title =@g.team2>@g.team2</span>
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

    <div Class="wrapper mb-30">
        <div Class="widget-area-1">
            <div Class="widget kopa-tab-1-widget kopa-point-widget">
                <div Class="widget kopa-sync-carousel-widget">
                    <div Class="owl-carousel sync1" id="mainnewscarouselid">
                        @code
                            For each n In oLastNews1

                                    @<div Class="item">                        
                                <article class="entry-item">                            
                                 <div class="entry-thumb w3-center">
                                     <a href="/Posts/Details/@n.Id"><img src="@n.PostPhoto" style="height:480px;width:1024px;" alt=""></a> 
                                     <div class="thumb-hover"></div> 
                                </div> 
                                 <div class="entry-content">                                    
                                     <h4 class="entry-title"><a href="/Posts/Details/@n.Id">@n.PostTitle</a></h4>  
                                     <h5><span><b>@n.PostSummary</b></span></h5> 
                                 </div> 
                                <span></span>                                 
                                </article> 
                            </div>

                            Next
                        End Code                        
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
                                    <h3 Class="widget-title style1">τοπ 10 και δηλωσεις</h3>
                                    <div Class="widget kopa-sync-carousel-2-widget">
                                        <div Class="owl-carousel sync3" id="watchsync3">
                                            @code
                                                For Each o In oLastNewsList
                                                    @<div Class="item">
                                                        <article class="entry-item video-post">
                                                            <div class="entry-thumb w3-center">
                                                                <a href="/Posts/Details/@o.Id" ><img src="@o.PostPhoto" alt="" style="height:320px;width:640px;"></a>
                                                                <a class="thumb-icon" href="https://www.youtube.com/watch?v=@o.Youtubelink" target="_blank"></a>
                                                            </div>
                                                            <div class="entry-content">
                                                                <h3 class=""><a href="/Posts/Details/@o.Id">@o.PostTitle</a></h3>
                                                            </div>
                                                        </article>
                                                    </div>
                                                Next
                                            End Code
                                        </div>

                                        <div Class="owl-carousel sync4" id="watchsync4">
                                            @code
                                                For Each o1 In oLastNewsList
                                                    @<div Class="item">
                                                        <article Class="entry-item video-post">
                                                            <div Class="entry-thumb">
                                                                <a href="/Posts/Details/@o1.Id"><img src="@o1.PostPhoto2" alt="" style="height:100px;width:120px;"></a>
                                                                <a class="thumb-icon" href="https://www.youtube.com/watch?v=@o1.Youtubelink" target="_blank"></a>
                                                            </div>
                                                            <div Class="entry-content">
                                                                <h4 Class="entry-title"><a href="/Posts/Details/@o1.Id">@o1.PostTitle</a></h4>
                                                            </div>
                                                        </article>
                                                    </div>
                                                Next
                                            End Code
                                        </div>
                                    </div>
                                </div>                               

                                
                                <div Class="widget kopa-article-list-widget article-list-1">
                                    <h3 Class="widget-title style2">τελευταια νεα</h3>
                                    <ul id="latestnewsid" Class="clearfix">
                                        @code

                                            For Each n In oLastNews2

                                                    @<li><article Class="entry-item disable-select ">
                                                    <div Class="entry-thumb">
                                                        <a href = "#"><img src="@n.PostPhoto2" alt=""/></a>
                                                    </div>
                                                    <div Class="entry-content">
                                                    <div Class="content-top">
                                                    <h4 Class="entry-title"><a href="/Posts/Details/@n.Id">@n.PostTitle</a></h4>
                                                    </div>
                                                    <p>@n.PostSummary.... </p>
                                                    </div>
                                                    </article>
                                                    </li>
                                            Next
                                            End Code

                                        </ul>
                                    

                                        @code
                                            If AtlasKathgoriaid > 0 Then
                                                @<div Class="entry-item p w3-right-align"><p><a href="/Posts/index/?ak=@AtlasKathgoriaid" Class="title style2 "><span>Δείτε λίστα με όλα τα νεα...</span></a></p></div>
                                            Else
                                                @<div Class="entry-item p w3-right-align"><p><a href="/Posts/index" Class="title style2"><span>Δείτε λίστα με όλα τα νεα...</span></a></p></div>
                                            End If
                                        End code
                                </div>
                                </div>
     </div>

                <div Class="sidebar widget-area-11">
                <div Class="widget kopa-tab-1-widget kopa-point-widget">
                    <a href = "http://www.blue-ice.gr/"><img src="~/Content/images/blueiceok.png" alt=""></a>
                    <a href = "https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"><img src="~/Content/images/risko.jpg" alt=""></a>
                    <a href = "http://www.atlassportswear.gr/"><img src="~/Content/images/atlassportwear.png" alt=""></a>
                </div>

                <div Class="widget kopa-tab-1-widget kopa-point-widget">
                    <h3 Class="widget-title style5"><span class="fa fa-trophy"></span>Κορυφαίοι της εβδομάδας</h3>
                    <ul Class="clearfix">
                        <li>
                            <div Class="kopa-tab style3">
                                <ul Class="nav nav-tabs">
                                    <li Class="active"><a href="#points" data-toggle="tab">Πον.</a></li>
                                    <li> <a href = "#assist" data-toggle="tab">Πασ.</a></li>
                                    <li> <a href = "#reb" data-toggle="tab">Ριμ.</a></li>
                                    <li> <a href = "#steal" data-toggle="tab">Κλ.</a></li>
                                    <li> <a href = "#block" data-toggle="tab">Κοψ.</a></li>
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



            $(document).ready(function () {            
                var omilosid = $("#atlaskathgoriaid").val();
                var triggerappendfwtos = 1;
                if (omilosid != 0) {
                    $("#fwtografiesdiv").hide();
                    triggerappendfwtos = 0;
                }
                else {
                    $("#fwtografiesdiv").show();
                    triggerappendfwtos = 1;
                }
            });


        </script>

    End Section
