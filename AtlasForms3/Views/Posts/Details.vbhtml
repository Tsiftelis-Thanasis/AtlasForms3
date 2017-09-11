@ModelType AtlasForms3.Posts
@Code

    Dim pdb As New AtlasBlogEntities
    Dim pdb2 As New AtlasStatisticsEntities


    Dim imageSrc As String = ""
    If Model.PostPhotoStr IsNot Nothing Then
        'Dim imageBase64 As String = Convert.ToBase64String(Model.PostPhoto)
        'imageSrc = String.Format("data:image/png;base64,{0}", imageBase64)

        imageSrc = Model.PostPhotoStr

    End If

    'to do
    ''
    ''να προσθεσω τις διαφημίσεις
    ''
    'Dim ads = (From pk In pdb.BlogPostKathgoriaTable2
    '           Where pk.Id = 6
    '           Select pk.KathgoriaName).FirstOrDefault

    Dim kathgorianamestr As String = ""
    Dim omilosnamestr As String = ""
    Dim atlaskatnamestr As String = ""

    Dim postkathgoria = (From pk In pdb.BlogPostandKathgoriaTable
                         Where pk.PostId = Model.Id
                         Select pk.KathgoriaId, pk.AtlasKathgoriaId, pk.IsAtlasKathgoria, pk.IsAtlasOmilos).FirstOrDefault

    Dim katid As Integer = If(postkathgoria Is Nothing, 0, postkathgoria.KathgoriaId)
    Dim omid As Integer = 0
    Dim atlaskatid As Integer = 0
    If Not postkathgoria Is Nothing Then
        If Not postkathgoria.AtlasKathgoriaId Is Nothing Then
            If postkathgoria.IsAtlasOmilos = 1 Then
                omid = postkathgoria.AtlasKathgoriaId
            Else
                atlaskatid = postkathgoria.AtlasKathgoriaId
                omid = (From o In pdb2.OmilosTable
                        Join k In pdb2.KathgoriesTable On o.Id Equals k.Omilosid
                        Where k.Id = atlaskatid
                        Select o.Id).FirstOrDefault
            End If
        End If
    End If



    If katid > 0 Then
        kathgorianamestr = (From k In pdb.BlogKathgoriesTable
                            Where k.Id = katid
                            Select k.KathgoriaName).FirstOrDefault
    End If
    If omid > 0 Then
        omilosnamestr = (From o In pdb2.OmilosTable
                         Join d In pdb2.DiorganwshTable On d.Id Equals o.Diorganwshid
                         Where o.Id = omid
                         Select OmilosName = o.OmilosName & " (" & d.DiorganwshName & ")").FirstOrDefault
    End If

    If atlaskatid > 0 Then
        atlaskatnamestr = (From k In pdb2.KathgoriesTable
                           Where k.Id = atlaskatid
                           Select KathgoriaName = k.KathgoriaName).FirstOrDefault
    End If


    Dim cTitle As String = ""
    If kathgorianamestr = "Ομάδες" Then
        Dim teamDet = Model.PostTitle.Split("-")
        cTitle = teamDet(1)
    Else
        cTitle = Model.PostTitle
    End If


    ViewData("Title") = cTitle

    Dim urlwithid As String = HttpContext.Current.Request.Url.ToString
    Dim socialDesc As String = ViewData("Title")

    Dim programmaid As Integer = 0

    If atlaskatid > 0 Then
        programmaid = (From t In pdb.BlogPostandKathgoriaTable
                       Join t2 In pdb.BlogPostsTable On t2.Id Equals t.PostId
                       Where t2.Activepost = True And t.AtlasKathgoriaId = atlaskatid And t.KathgoriaId = 14
                       Select t.PostId).FirstOrDefault
    End If

    Dim UserisAuthenticated As Integer = If(User.Identity Is Nothing, 0, If(User.Identity.IsAuthenticated, 1, 0))

    Dim agwnistikistr As String = ""
    If Model.Agonistiki > 0 Then
        agwnistikistr = (From p1 In pdb2.AgwnistikesTable
                         Where p1.Id = Model.Agonistiki
                         Select p1.Agwnistiki).FirstOrDefault.ToString

    End If

End Code


@Html.AntiForgeryToken()
@Html.ValidationSummary(True)
@Html.HiddenFor(Function(model) model.Id)

<div class="main-top">
    <div class="kopa-ticker">
        <span Class="ticker-title"><i class="fa fa-angle-double-right"></i>@cTitle</span>
        <div Class="ticker-wrap">
            <dl Class="ticker-1">
                <dt></dt>
                <dd>
                    <a> <span>&nbsp; </span></a>
                </dd>
            </dl>
        </div>
    </div>
</div>

<div class="row">

    <div class="kopa-main-col">
        <div class="kopa-entry-post">
            <article class="entry-item">

                <p class="entry-categories style-s2">


                    @code

                        If atlaskatid > 0 And katid = 14 Then
                            @<a href="/Home/Index/?ak=@atlaskatid"> Νέα</a>

                                    @If katid = 12 Then
                                        @<a style="background: #ef6018 !important" href="/Posts/Index/?ak=@atlaskatid&k=12"><span >Ομαδες</span></a>
                                    Else
                                        @<a href="/Posts/Index/?ak=@atlaskatid&k=12"><span >Ομαδες</span></a>
                                    End If

                                    @If katid = 15 Then
                                        @<a style="background: #ef6018 !important" href="/Posts/Index/?ak=@atlaskatid&k=15"><span >Βαθμολογια</span></a>
                                    Else
                                        @<a href="/Posts/Index/?ak=@atlaskatid&k=15"><span >Βαθμολογια</span></a>
                                    End If

                                    @If UserisAuthenticated > 0 Then
                                        If programmaid > 0 Then
                                            @If katid = 14 Then
                                                @<a style="background: #ef6018 !important" href="/Posts/Details/@programmaid"> <span >Προγραμμα</span></a>
                                            Else
                                                @<a href="/Posts/Details/@programmaid"> <span >Προγραμμα</span></a>
                                            End If
                                        Else
                                            @If katid = 14 Then
                                                @<a style="background: #ef6018 !important"> <span >Προγραμμα</span></a>
                                            Else
                                                @<a><span >Προγραμμα</span></a>
                                            End If
                                        End If
                                    End If

                                    @If katid = 13 Then
                                        @<a style="background: #ef6018 !important" href="/Posts/Index/?ak=@atlaskatid&k=13"><span >Τιμωριες</span></a>
                                    Else
                                        @<a href="/Posts/Index/?ak=@atlaskatid&k=13"><span >Τιμωριες</span></a>
                                    End If

                        Else

                            @<a href="@Url.Action("Index", "Home")">Αρχικη</a>

                            If omilosnamestr <> "" Then
                                @<a href="@Url.Action("Index", "Posts", New With {.a = omid})">@omilosnamestr</a>
                            End If
                            If atlaskatnamestr <> "" Then
                                @<a href="@Url.Action("Index", "Home", New With {.ak = atlaskatid})">@atlaskatnamestr</a>
                            End If

                            @<a>@Html.DisplayFor(Function(model) cTitle)</a>

                        End If

                    End Code

                </p>

                @code
                    If imageSrc <> "" Then
                        @<div Class="row form-horizontal vertical-center">
                            <div Class="form-group">
                                <div Class="col-md-6 entry-thumb">
                                    <img src="@imageSrc" style="width:50%;" />
                                </div>
                            </div>
                        </div>
                    End If
                End Code


                @code
                    If agwnistikistr <> "" Then
                        @<div Class="row form-horizontal">
                            <div Class="form-group">
                                <div Class="col-md-12 w3-center">
                                    Αγωνιστική:
                                    <b>
                                        <em>
                                            @agwnistikistr
                                        </em>
                                    </b>
                                </div>
                            </div>
                        </div>

                    End If
                End Code

                @code
                    If not Model.PostSummary Is Nothing Then
                        If Model.PostSummary <> "" Then
                            @<div Class="row form-horizontal">
                                <div Class="form-group">
                                    <div Class="col-md-12 disable-select "> 
                                        <em>
                                            @Html.DisplayFor(Function(model) model.PostSummary, New With {.class = "form-control input-text"})
                                        </em>
                                    </div>
                                </div>
                            </div>
                        End If
                    End If
                End Code



                @code
                    If Not Model.PostBody Is Nothing Then
                        If Model.PostBody <> "" Then
                            @<div Class="row form-horizontal">
                               
                                <div Class="form-group">                                    
                                    <div Class="col-md-12 disable-select ">
                                        <div class="apostrophe-divider"><hr><span></span></div>
                                            @Html.Raw(Model.PostBody.ToString)
                                        <div class="apostrophe-divider"><hr><span></span></div>
                                    </div>
                                </div>
                                                

                            </div>
                        End If
                    End If

                End code

                @code
                    If not Model.Statslink Is Nothing Then
                        If Model.Statslink.ToString <> "" Then
                            @<p Class="short-des" style="text-align:center">
                                <a target="_blank" href="http://atlasstatistics.gr/Games/Details/@Model.Statslink">
                                    <img src="~/Content/images/stats.jpg" border="0" />
                                </a>
                            </p>
                        End If
                    End If
                End Code

                @code
                    If not Model.Youtubelink Is Nothing Then
                        If Model.Youtubelink.Length > 36 Then
                            @<iframe title="YouTube video player" Class="youtube-player" type="text/html"
                                     height="315" src="@Html.DisplayFor(Function(model) model.Youtubelink)"
                                     frameborder="0" allowFullScreen></iframe>
                        End If
                    End If
                End Code


                <p></p>

                @*<div Class="row form-horizontal">
                        <div Class="form-group">
                            <div Class="col-md-12">
                                <div Class="entry-meta">
                                    <span Class="entry-author">δημιουργήθηκε από @Html.DisplayFor(Function(model) model.createdby)</span>
                                    <span Class="entry-date">στης  @Html.DisplayFor(Function(model) model.creationdate)</span>
                                    <br />
                                    <span Class="entry-author">επεξεργάστηκε από @Html.DisplayFor(Function(model) model.editby)</span>
                                    <span Class="entry-date">στης  @Html.DisplayFor(Function(model) model.editdate)</span>
                                </div>
                            </div>
                        </div>
                    </div>*@

            </article>
        </div>

        @*<div Class="row form-horizontal">
            <div id="fbAtlas" Class="fb-like"
                 data-href=@urlwithid
                 data-layout="standard"
                 data-action="like"
                 data-size="large"
                 data-show-faces="true"
                 data-share="true">
            </div>
        </div>*@

        @*<div Class="row form-horizontal" style="float:right">
            <a target="_blank"
               href="https://www.facebook.com/sharer/sharer.php?u=@urlwithid&display=popup&ref=plugin&src=like&kid_directed_site=0&app_id=140586622674265">
                <img src="~/Content/images/facebook-icon.png">
            </a>
            <a class="twitter-share-button"
               href="https://twitter.com/intent/tweet?text=@socialDesc&url=@urlwithid"
               data-size="large">
                <img src="~/Content/images/Twitter_Logo.png" />
            </a>
        </div>*@
    </div>


    <div Class="sidebar widget-area-11">

        <div Class="widget kopa-tab-1-widget kopa-point-widget">
            <div Class="row form-horizontal w3-center">

                <div Class="row form-horizontal">
                    <a target="_blank"
                       href="https://www.facebook.com/sharer/sharer.php?u=@urlwithid&display=popup&ref=plugin&src=like&kid_directed_site=0&app_id=140586622674265&img=~/Content/images/facebook-icon.png">
                        <img src="~/Content/images/facebook-icon.png">
                    </a>
                    <a target="_blank" class="twitter-share-button"
                       href="https://twitter.com/intent/tweet?text=@socialDesc&url=@urlwithid"
                       data-size="large">
                        <img src="~/Content/images/Twitter_Logo.png" />
                    </a>
                </div>
            </div>
        </div>
    </div>

    <div Class="sidebar widget-area-11">
        <div id="divads" Class="widget kopa-tab-1-widget kopa-point-widget">
            <a href="http://www.blue-ice.gr/"> <img src="~/Content/images/blueiceok.png" alt=""></a>
            <a href="https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"> <img src="~/Content/images/risko.jpg" alt=""></a>
            <a href="http://www.atlassportswear.gr/"> <img src="~/Content/images/atlassportwear.png" alt=""></a>
        </div>
    </div>

</div>


@Section Scripts
    <script type="text/javascript">

    </script>
End Section
