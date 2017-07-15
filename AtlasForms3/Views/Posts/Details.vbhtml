@ModelType AtlasForms3.Posts
@Code

    Dim pdb As New AtlasBlogEntities
    Dim pdb2 As New AtlasStatisticsEntities


    Dim imageSrc As String = ""
    If Model.PostPhoto IsNot Nothing Then
        Dim imageBase64 As String = Convert.ToBase64String(Model.PostPhoto)
        imageSrc = String.Format("data:image/png;base64,{0}", imageBase64)
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

    Dim postkathgoria = (From pk In pdb.BlogPostandKathgoriaTable
                         Where pk.PostId = Model.Id
                         Select pk.KathgoriaId, pk.AtlasKathgoriaId).FirstOrDefault
    Dim katid As Integer = If(postkathgoria.KathgoriaId Is Nothing, 0, postkathgoria.KathgoriaId)
    Dim omid As Integer = If(postkathgoria.AtlasKathgoriaId Is Nothing, 0, postkathgoria.AtlasKathgoriaId)

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


    Dim cTitle As String = ""
    If kathgorianamestr = "Ομάδες" Then
        Dim teamDet = Model.PostTitle.Split("-")
        cTitle = teamDet(1)
    Else
        cTitle = Model.PostTitle
    End If


    ViewData("Title") = cTitle



End Code


@Html.AntiForgeryToken()
@Html.ValidationSummary(True)
@Html.HiddenFor(Function(model) model.Id)


@*<div id="main-content" class="container">
    <div class="wrapper">*@


        <div class="main-top">
            <div class="kopa-ticker">
                <span Class="ticker-title"><i class="fa fa-angle-double-right"></i>@cTitle</span>
                <div Class="ticker-wrap">
                    <dl Class="ticker-1">
                        <dt></dt>
                        <dd>
                            <a> <span>&nbsp; </span></a> @*&nbsp; @Html.DisplayFor(Function(model) model.PostTitle)</span></a>*@
                        </dd>
                    </dl>
                </div>
            </div>
        </div>

        <div class="row">

            @*<div class="kopa-main-col">*@
                <div class="kopa-entry-post">
                    <article class="entry-item">

                        <p class="entry-categories style-s">
                            <a href="@Url.Action("Index", "Home")">Αρχικη</a>
                            @code
                                If omilosnamestr <> "" Then
                                    @<a href="@Url.Action("Index", "Posts", New With {.a = omid})">@omilosnamestr</a>
                                End If
                            End Code


                            @code
                                If kathgorianamestr <> "" Then
                                    @<a href="@Url.Action("Index", "Posts", New With {.k = katid})">@kathgorianamestr</a>
                                End If
                            End Code

                            <a>@Html.DisplayFor(Function(model) cTitle)</a>
                        </p>


                        <div class="row form-horizontal vertical-center">
                            <div class="form-group">
                                <div class="col-md-6 entry-thumb">
                                    <img src="@imageSrc" style="height:160px;width:160px;" />
                                </div>
                            </div>
                        </div>

                        @code
                            If Model.PostSummary.ToString <> "" Then
                                @<div Class="row form-horizontal">
                                    <div Class="form-group">
                                        <div Class="col-md-12"> 
                                            <em>
                                                @Html.DisplayFor(Function(model) model.PostSummary, New With {.class = "form-control input-text"})
                                            </em>
                                        </div>
                                    </div>
                                </div>
                            End If
                        End Code

                        @code
                            If Model.PostBody <> "" Then
                                @<div Class="row form-horizontal">
                                    <div Class="form-group">
                                        <div Class="col-md-12">
                                            @Html.Raw(Model.PostBody.ToString)                                            
                                        </div>
                                    </div>                  
                                </div>
                            End If
                        End code

                        @code
                            If Model.Statslink <> "" Then
                                @<p Class="short-des" style="text-align:center">
                                    <a target="_blank" href="http://atlasstatistics.gr/Games/Details/@Html.DisplayFor(Function(model) model.Statslink)">
                                        <img src="~/Content/images/various/stats.jpg" border="0" />
                                    </a>
                                </p>
                            End If
                        End Code

                        @code
                            If Model.Youtubelink.Length > 36 Then
                                @<iframe title="YouTube video player" Class="youtube-player" type="text/html"
                                            height="315" src="@Html.DisplayFor(Function(model) model.Youtubelink)"
                                            frameborder="0" allowFullScreen></iframe>
                            End If
                        End Code


                        <p></p>

                        <div Class="row form-horizontal">
                            <div Class="form-group">
                                <div Class="col-md-12">
                                    <div Class="entry-meta">
                                        <span Class="entry-author">Created by @Html.DisplayFor(Function(model) model.createdby)</span>
                                        <span Class="entry-date">Created on @Html.DisplayFor(Function(model) model.creationdate)</span>
                                        <br />
                                        <span Class="entry-author">Edit by @Html.DisplayFor(Function(model) model.editby)</span>
                                        <span Class="entry-date">Edited on @Html.DisplayFor(Function(model) model.editdate)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
        </article>
</div>
@*</div>*@


@*<div class="sidebar widget-area-11">

    <div class="widget kopa-ads-widget">
        <a href="http://www.blue-ice.gr/"><img src="http://www.atlasbasket.gr/images/banners/blueiceok.png" alt=""></a>
    </div>

    <div class="widget kopa-ads-widget">
        <a href="https://www.facebook.com/therisko2reloaded/?ref=ts&fref=ts"><img src="http://www.atlasbasket.gr/images/banners/risko.jpg" alt=""></a>
    </div>

    <div class="widget kopa-ads-widget">
        <a href="http://www.atlassportswear.gr/"><img src="http://www.atlasbasket.gr/images/banners/65c14b0a-e3b2-4e15-8f14-1ba31c041f20.png" alt=""></a>
    </div>
</div>
</div>*@

@*</div>


</div>*@

            <div Class="row form-horizontal">
                <div Class="form-group">
                    <div Class="col-md-12">
                        <p>
                            @Html.ActionLink("Επιστροφή στην αρχική", "Index")
                        </p>
                    </div>
                </div>
            </div>



@Section Scripts
    <script type="text/javascript">

        //tinymce.init({
        //    selector: '#PostBody',
        //    height: 400,
        //    menubar: false,
        //    readonly: true,
        //    statusbar: false,
        //    toolbar: false,
        //    menubar: false,
        //    branding: false,
        //    content_css: [
        //        '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
        //        '//www.tinymce.com/css/codepen.min.css']
        //});        
      
        //tinymce.init({
        //    selector: '#PostBody',
        //    inline: true,
        //    menubar: false,
        //    readonly: true,
        //    statusbar: false,
        //    toolbar: false,
        //    menubar: false,
        //    branding: false,
        //    content_css: [
        //      '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
        //      '//www.tinymce.com/css/codepen.min.css']
        //});


        //tinymce.init({
        //    selector: 'div.editable',
        //    inline: true,                
        //    menubar: false,
        //    readonly: true,
        //    statusbar: false,
        //    toolbar: false,
        //    menubar: false,
        //    branding: false,
        //    content_css: [
        //        '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
        //        '//www.tinymce.com/css/codepen.min.css']
        //});


    </script>
End Section
