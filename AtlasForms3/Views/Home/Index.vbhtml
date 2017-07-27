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

            <div Class="widget kopa-sync-carousel-widget">
                <div Class="owl-carousel sync1"  id="mainnewscarouselid">                   
                 
                </div>
                <!-- sync1 -->
            </div>

            @*</div>*@
            <!-- kopa sync carousel widget -->
            @*<div class="widget kopa-scroll-slider-widget">
                <h3 class="widget-title"><span><b>gallery post</b></span></h3>
                <span class="thumb-left"></span>
                <span class="thumb-right"></span>
                <div class="scroll-slider">
                    <a href="#" class="s-prev fa fa-chevron-left"></a>
                    <a href="#" class="s-next fa fa-chevron-right"></a>
                    <div class="loading">
                        <i class="fa fa-refresh fa-spin"></i>
                    </div>
                    <ul class="clearfix">
                        <li class="s-item">
                            <div class="item-wrap">
                                <article class="entry-item image-post">
                                    <div class="item-bg"></div>
                                    <h4 class="entry-title"><span class="fa"></span><a href="#">clark</a></h4>
                                    <div class="entry-thumb">
                                        <a href="#"><img src="~/Content/images/scroll-slider/1.jpg" alt=""></a>
                                    </div>
                                </article>
                            </div>
                        </li>
                        <li class="s-item">
                            <div class="item-wrap">
                                <article class="entry-item image-post">
                                    <div class="item-bg"></div>
                                    <h4 class="entry-title"><span class="fa"></span><a href="#">Luthor</a></h4>
                                    <div class="entry-thumb">
                                        <a href="#"><img src="~/Content/images/scroll-slider/2.jpg" alt=""></a>
                                    </div>
                                </article>
                            </div>
                        </li>
                        <li class="s-item">
                            <div class="item-wrap">
                                <article class="entry-item image-post">
                                    <div class="item-bg"></div>
                                    <h4 class="entry-title"><span class="fa"></span><a href="#">clark</a></h4>
                                    <div class="entry-thumb">
                                        <a href="#"><img src="~/Content/images/scroll-slider/1.jpg" alt=""></a>
                                    </div>
                                </article>
                            </div>
                        </li>
                        <li class="s-item">
                            <div class="item-wrap">
                                <article class="entry-item image-post">
                                    <div class="item-bg"></div>
                                    <h4 class="entry-title"><span class="fa"></span><a href="#">Luthor</a></h4>
                                    <div class="entry-thumb">
                                        <a href="#"><img src="~/Content/images/scroll-slider/2.jpg" alt=""></a>
                                    </div>
                                </article>
                            </div>
                        </li>
                        <li class="s-item">
                            <div class="item-wrap">
                                <article class="entry-item image-post">
                                    <div class="item-bg"></div>
                                    <h4 class="entry-title"><span class="fa"></span><a href="#">clark</a></h4>
                                    <div class="entry-thumb">
                                        <a href="#"><img src="~/Content/images/scroll-slider/1.jpg" alt=""></a>
                                    </div>
                                </article>
                            </div>
                        </li>
                        <li class="s-item">
                            <div class="item-wrap">
                                <article class="entry-item image-post">
                                    <div class="item-bg"></div>
                                    <h4 class="entry-title"><span class="fa"></span><a href="#">Luthor</a></h4>
                                    <div class="entry-thumb">
                                        <a href="#"><img src="~/Content/images/scroll-slider/2.jpg" alt=""></a>
                                    </div>
                                </article>
                            </div>
                        </li>
                        <li class="s-item">
                            <div class="item-wrap">
                                <article class="entry-item image-post">
                                    <div class="item-bg"></div>
                                    <h4 class="entry-title"><span class="fa"></span><a href="#">clark</a></h4>
                                    <div class="entry-thumb">
                                        <a href="#"><img src="~/Content/images/scroll-slider/1.jpg" alt=""></a>
                                    </div>
                                </article>
                            </div>
                        </li>

                    </ul>
                </div>*@
            <!-- scroll-slider
            </div>
            <!-- widget -->
            @*</div>*@
            <!-- widget-area-1 -->
            @*</div>*@
            <!-- wrapper -->

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
                                        <!-- sync3 -->
                                        <div Class="owl-carousel sync4" id="watchsync4">
                                        </div>
                                        <!-- sync4 -->
                                    </div>
                                    <!-- kopa sync carousel widget -->
                                </div>
                                <!-- widget -->                             


                                <div Class="widget kopa-article-list-widget article-list-1">
                                    <h3 Class="widget-title style2">τελευταια νεα</h3>
                                    <ul id = "latestnewsid" Class="clearfix"></ul>
                                </div>
                                <!-- widget -->

                            </div>
                            <!-- widget-area-2 -->


                        </div>
                        <!-- main-col -->

                        <div Class="sidebar widget-area-11">


                            <!-- widget -->

                            <div Class="widget ">
                                <a href = "http://www.blue-ice.gr/"> <img src="http://www.atlasbasket.gr/images/banners/blueiceok.png" alt=""></a>
                                <a href = "https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"> <img src="http://www.atlasbasket.gr/images/banners/risko.jpg" alt=""></a>
                                <a href = "http://www.atlassportswear.gr/"> <img src="http://www.atlasbasket.gr/images/banners/65c14b0a-e3b2-4e15-8f14-1ba31c041f20.png" alt=""></a>
                            </div>
                            <!-- widget -->
                            @*<div class="widget kopa-point-widget">*@
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
                                            <!-- nav-tabs -->
                                            <div Class="tab-content">
                                                <div Class="tab-pane active" id="points">
                                                    <ul Class="kopa-list clearfix" id="pointsul"></ul>
                                                </div>
                                                <!-- tab-pane -->
                                                <div Class="tab-pane" id="assist">
                                                    <ul Class="kopa-list clearfix" id="assistul"></ul>
                                                </div>
                                                <!-- tab-pane -->
                                                <div Class="tab-pane" id="reb">
                                                    <ul Class="kopa-list clearfix" id="reboundul"></ul>
                                                </div>
                                                <!-- tab-pane -->
                                                <div Class="tab-pane" id="steal">
                                                    <ul Class="kopa-list clearfix" id="stealsul"></ul>
                                                </div>
                                                <!-- tab-pane -->
                                                <div Class="tab-pane" id="block">
                                                    <ul Class="kopa-list clearfix" id="blocksul"></ul>
                                                </div>
                                                <!-- tab-pane -->

                                            </div>
                                        </div>
                                        <!-- kopa-tab -->
                                    </li>
                                </ul>
                            </div>
                            <!-- widget -->
                            @*</div>*@
                            <!-- widget -->


                            @*<div class="widget kopa-point-widget">

    <div class="widget kopa-calendar-widget">
        <h3 class="widget-title style5"><span class="fa fa-calendar"></span>Calendar</h3>
        <div class="widget-content">
            <ul class="clearfix">
                <li>
                    <div class="cl-item">
                        <div class="cl-left">
                            <h4>15</h4>
                            <p>nov 2014</p>
                        </div>
                        <div class="cl-right">
                            <h5><a href="#">All American Tourny</a></h5>
                            <a href="#">Joe Dumars Fieldhouse</a>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="cl-item">
                        <div class="cl-left">
                            <h4>25</h4>
                            <p>nov 2014</p>
                        </div>
                        <div class="cl-right">
                            <h5><a href="#">Osaka, Japan</a></h5>
                            <a href="#">Joe Dumars Fieldhouse</a>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="cl-item">
                        <div class="cl-left">
                            <h4>27</h4>
                            <p>nov 2014</p>
                        </div>
                        <div class="cl-right">
                            <h5><a href="#">1 Day To Win It All</a></h5>
                            <a href="#">Silver Creek Sportsplex</a>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="cl-item">
                        <div class="cl-left">
                            <h4>19</h4>
                            <p>nov 2014</p>
                        </div>
                        <div class="cl-right">
                            <h5><a href="#">Super Skillz Showdown</a></h5>
                            <a href="#">Amherst Pepsi Center</a>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="cl-item">
                        <div class="cl-left">
                            <h4>29</h4>
                            <p>nov 2014</p>
                        </div>
                        <div class="cl-right">
                            <h5><a href="#">Weekend Warriors</a></h5>
                            <a href="#">Duel Decks</a>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <!-- widget -->
                            </div> *@
                            <!-- widget-area-17 -->


                        </div>
                        <!-- sidebar -->

                    </div>
                    <!-- row -->

                </div>
                <!-- content-wrap -->

                @*<section class="kopa-area kopa-area-1 mb-30">

                    <span class="t1"></span>
                    <span class="t2"></span>

                    <div class="content-wrap">

                        <div class="row">

                            <div class="widget-area-12">

                                <div class="widget kopa-result-widget">
                                    <h3 class="widget-title style6">προηγουμενα αποτελεσματα</h3>
                                    <div class="widget-content">
                                        <div class="span-bg">
                                            <span class="c-tg"></span>
                                        </div>
                                        <div class="owl-carousel owl-carousel-2">
                                            <div class="item">
                                                <div class="r-item">
                                                    <a class="r-num" href="#">
                                                        <span class="r-color">2</span>
                                                        <span>-</span>
                                                        <span>1</span>
                                                    </a>
                                                    <a class="r-side left" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/1.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>arsenol</h5>
                                                            <p>Sanchen (27 pen), Sanobo (78)</p>
                                                        </div>
                                                    </a>
                                                    <a class="r-side right" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/2.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>hon city</h5>
                                                            <p>K. Benny (78)</p>
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                            <!-- item -->
                                            <div class="item">
                                                <div class="r-item">
                                                    <a class="r-num" href="#">
                                                        <span class="r-color">2</span>
                                                        <span>-</span>
                                                        <span>1</span>
                                                    </a>
                                                    <a class="r-side left" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/1.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>arsenol</h5>
                                                            <p>Sanchen (27 pen), Sanobo (78)</p>
                                                        </div>
                                                    </a>
                                                    <a class="r-side right" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/2.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>hon city</h5>
                                                            <p>K. Benny (78)</p>
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                            <!-- item -->
                                        </div>
                                        <!-- owl-carousel-2 -->
                                    </div>
                                </div>
                                <!-- widget -->

                                <div class="widget kopa-fixture-widget">
                                    <h3 class="widget-title style6">UPCOMING FIXTURES</h3>
                                    <div class="widget-content">
                                        <div class="owl-carousel owl-carousel-2">
                                            <div class="item">
                                                <div class="r-item">
                                                    <a class="r-num" href="#">
                                                        <span>-</span>
                                                        <span>vs</span>
                                                        <span>-</span>
                                                    </a>
                                                    <a class="r-side left" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/3.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>chelsen</h5>
                                                        </div>
                                                    </a>
                                                    <a class="r-side right" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/1.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>arsenol</h5>
                                                        </div>
                                                    </a>
                                                    <p>Sat 18th Oct 15.00 Emirates Stadium</p>
                                                </div>
                                            </div>
                                            <!-- item -->
                                            <div class="item">
                                                <div class="r-item">
                                                    <a class="r-num" href="#">
                                                        <span>-</span>
                                                        <span>vs</span>
                                                        <span>-</span>
                                                    </a>
                                                    <a class="r-side left" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/3.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>chelsen</h5>
                                                        </div>
                                                    </a>
                                                    <a class="r-side right" href="#">
                                                        <div class="r-thumb">
                                                            <img src="~/Content/images/result/1.png" alt="">
                                                        </div>
                                                        <div class="r-content">
                                                            <h5>arsenol</h5>
                                                        </div>
                                                    </a>
                                                    <p>Sat 18th Oct 15.00 Emirates Stadium</p>
                                                </div>
                                            </div>
                                            <!-- item -->
                                        </div>
                                        <!-- owl-carousel-3 -->
                                    </div>
                                </div>
                                <!-- widget -->

                            </div>
                            <!-- widget-area-12 -->

                            <div id="divstandcommon1" Class="widget-area-13">

                                <div Class="widget kopa-charts-widget">
                                    <h3 Class="widget-title style6"><span>βαθμολογια Α1</span></h3>
                                    <div Class="widget-content">
                                        <header>
                                            <div Class="t-col">Α/Α</div>
                                            <div Class="t-col width1">ομαδα</div>
                                            <div Class="t-col">Αγ.</div>
                                            <div Class="t-col">βαθμ.</div>
                                        </header>
                                        <ul Class="clearfix">
                                            <li>
                                                <div Class="t-col">1</div>
                                                <div Class="t-col width1">BROOKLYN BETS</div>
                                                <div Class="t-col">20</div>
                                                <div Class="t-col">35</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">2</div>
                                                <div Class="t-col width1">CROCODILES</div>
                                                <div Class="t-col">20</div>
                                                <div Class="t-col">33</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">3</div>
                                                <div Class="t-col width1">DEPORTIVO ΦΑΛΗΡΟ</div>
                                                <div Class="t-col">20</div>
                                                <div Class="t-col">33</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">4</div>
                                                <div Class="t-col width1">mon utd</div>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col">11</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">5</div>
                                                <div Class="t-col width1">swansen</div>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col">11</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">6</div>
                                                <div Class="t-col width1">Spors</div>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col">11</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col width1">West Hem</div>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col">10</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">8</div>
                                                <div Class="t-col width1">arsenol</div>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col">10</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">9</div>
                                                <div Class="t-col width1">Liverpunl</div>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col">10</div>
                                            </li>
                                            <li>
                                                <div Class="t-col">10</div>
                                                <div Class="t-col width1">Astun Villo</div>
                                                <div Class="t-col">7</div>
                                                <div Class="t-col">10</div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>



                            </div>
                            <!-- widget-area-13 -->

                        </div>
                        <!-- row -->

                    </div>

                </section>*@
                

            </div>



            </div>
            <!-- wrapper -->
        </div>

    <div Class="widget-area-24 kopa-area kopa-area-2">

        <div Class="widget kopa-product-list-widget">
            <h3 Class="widget-title style10">καλυτερες φασεις -- > Gallery !</h3>
            <div Class="content-wrap">
                <div Class="row">
                    <div id = "kalyteresfaseisid" Class="owl-carousel owl-carousel-4">
                    </div>
                    <!-- owl-carousel-4 -->
                </div>
                <!-- row -->
            </div>
        </div>
        <!-- widget -->

    </div>
    <!-- widget-area-24 -->

    </div>
    <!-- main-content -->




    @Section Scripts


 <script type="text/javascript">

            $(document).ready(function () {


                var omilosid = $("#atlasomilosid").val();

                
                //url: baseUrl + '@Url.Action("GetLastNewswithVideo", "Posts")',
                //append carousel sync3 and sync4
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetLastNewsByCategory", "Posts")',
                    data: "{nCount : 10, k: 7}",
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

                //apend kalyteresfaseisid
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetLastNewsByCategory", "Posts")',
                    data: "{nCount : 10, k: 7}",
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

                               
                //append mainnewscarouselid
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetLastNews", "Posts")',
                    data: "{nCount : 5}",
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


            

                //apend latestnewsid
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetLastNews", "Posts")',
                    data: "{nCount : 10}",
                    async: false,
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

                //append pointsul
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat1", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: false,
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


                //append assistul
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat2", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: false,
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


                //append reboundul
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat3", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: false,
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


                //append stealsul
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat4", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: false,
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

                //append blocksul
                $.ajax({
                    type: "POST",
                    url: baseUrl + '@Url.Action("GetWeeklyReportStat5", "Home")',
                    data: "{omid : " + omilosid + "}",
                    async: false,
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


                //append lastgames carouselid

                $.ajax({
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


            });
        </script>

    End Section
