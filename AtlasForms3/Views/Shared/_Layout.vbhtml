@code

    Dim pdb2 As New AtlasStatisticsEntities

    Dim StaticfirstDiorganwshid = (From d In pdb2.DiorganwshTable
                                   Join s In pdb2.SeasonTable On d.Seasonid Equals s.Id
                                   Where d.DiorganwshName.Contains("πρωταθλημα") And s.ActiveSeason = True
                                   Select d.Id).FirstOrDefault

    Dim firstDiorganwshid = (From d In pdb2.DiorganwshTable
                             Join s In pdb2.SeasonTable On d.Seasonid Equals s.Id
                             Where d.DiorganwshName.Contains("πρωταθλημα") And s.ActiveSeason = True
                             Select d.Id).FirstOrDefault

    If Session("GlobalDiorganwshid") = 0 Then
        Session("GlobalDiorganwshid") = firstDiorganwshid
    Else
        firstDiorganwshid = Session("GlobalDiorganwshid")
    End If


    Dim UserisAuthenticated As Integer = If(User.Identity Is Nothing, 0, If(User.Identity.IsAuthenticated, 1, 0))

    Dim u As New Utils
    Dim oGetSimplePosts = u.GetSimplePosts(10, Nothing, 1, Nothing)
    Dim oGetdiorganwseis = u.Getdiorganwseis()

    Dim urlwithid As String = HttpContext.Current.Request.Url.ToString
    Dim socialDesc As String = If(ViewBag.Title = "", "", ViewBag.Title & " - ") & "Ατλας μπάσκετ"
    Dim imageSrc As String = Request.Url.GetLeftPart(UriPartial.Authority).ToString & "/Content/images/atlas_fb_logo.jpg"

    If Not ViewBag.postimage Is Nothing Then
        imageSrc = Request.Url.GetLeftPart(UriPartial.Authority).ToString & ViewBag.postimage.ToString
    End If

End code


<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta property="fb:app_id" content="140586622674265" />
    <meta property="og:site_name" content="AtlasBasket" />
    <meta property="og:title" content="@(If(ViewBag.Title = "", "", ViewBag.Title & " - ")) Ατλας μπάσκετ" />
    <meta property="og:url" content="@urlwithid" />
    <meta property="og:image" content="@imageSrc" /> @*image for each page*@
    <meta property="og:image:width" content="600" />
    <meta property="og:image:height" content="315" />
    <meta property="og:type" content="article" /> @*or website article*@
    <meta property="og:description" content="@socialDesc" /> @*description for each page*@

    <title>@(If(ViewBag.Title = "", "", ViewBag.Title & " - ")) Ατλας μπάσκετ</title>
    <link rel="shortcut icon" type="image/ico" href="~/favicon.ico">

    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    <style>
        .mySlides {
            display: none;
        }
            
    </style>

    @RenderSection("styles", required:=False)

    <script type="text/javascript" language="javascript">

        var url1 = window.location.href.split('/');
        var baseUrl = url1[0] + '//' + url1[2];

        var old = alert;
        alert = function () {
            console.log(new Error().stack);
            old.apply(window, arguments);
        };

            //google analytics!
          (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
          (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
          m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
          })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

          ga('create', 'UA-106049344-1', 'auto');
          ga('send', 'pageview');

    </script>
</head>


<body>

    <div id="loadingDiv" class="modalloader"></div>

    @*CHANGEME if you want button to be in greek change the en_US to el_GR*@
    @*atlas id =140586622674265
    rcringid =140586622674265*@
    <div id="fb-root"></div>
    <script>(function(d, s, id) {
          var js, fjs = d.getElementsByTagName(s)[0];
          if (d.getElementById(id)) return;
          js = d.createElement(s); js.id = id;
          js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.10&appId=140586622674265";
          fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>


    @Html.Hidden("firstDiorganwshid", firstDiorganwshid)
    @Html.Hidden("UserisAuthenticated", UserisAuthenticated)

    <header class="kopa-header">
        <div class="kopa-header-middle">
            <div class="wrapper">
                <nav class="kopa-main-nav">
                    <div class="kopa-logo">
                        <a href="@Url.Action("Index", "Home")"><img src="~/Content/images/atlaslogobig_ok.png" alt="logo" style="height:60px;"></a>
                    </div>

                    <ul class="main-menu sf-menu">
                        <li class="current-menu-item">
                            <a href="@Url.Action("Index", "Home")"><span>Αρχικη</span></a>
                        </li>
                        <li class="current-menu-item">
                            <a class="lipointer" id="prwta8limaid" onclick="fillomiloinavbar(@StaticfirstDiorganwshid , 1)"><span>Πρωταθλημα</span></a>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανώσεις</span></a>
                            <ul class="sub-menu" id="diorganwseiulid">
                                @code
                                    For Each g In oGetdiorganwseis
                                        @<li class="lipointer" ><a onclick="fillomiloinavbar(@g.Id);">@g.DiorganwshName</a></li>
                                    Next
                                End Code
                            </ul>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανωτρια αρχη</span></a>
                            <ul class="sub-menu" id="diorgarxhpostsid">

                                @code
                                    For Each g In oGetSimplePosts
                                        @<li><a href="/Posts/Details/@g.Id">@g.PostTitle</a></li>
                                    Next
                                End Code

                            </ul>
                        </li>

                        <li class="current-menu-item">
                            <a href="@Url.Action("Create", "Newteam")"><span>εγγραφη ομαδας</span></a>                      
                        </li>

                        <li class="current-menu-item">
                            <a href="@Url.Action("Contact", "Home")"><span>επικοινωνια </span></a>
                        </li>

                        @If User.Identity.IsAuthenticated Then
                            If User.IsInRole("Admins") Then
                                @<li Class="current-menu-item"><a href="@Url.Action("Panel", "Home")"><span>διαχειριση</span></a></li>
                            End If
                        End If

                    </ul>

                </nav>

                <nav class="main-nav-mobile clearfix">
                    <a class="pull fa fa-bars"></a>
                    <ul class="main-menu-mobile" style="display: none;" id="mobilemainmenu">

                        <li class="">
                            <a href="@Url.Action("Index", "Home")"><span>Αρχικη</span></a>
                        </li>

                        <li class="">
                            <a class="lipointer" onclick="fillomiloinavbar(@firstDiorganwshid, 1);"><span>Πρωταθλημα</span></a>                            
                        </li>

                        <li class="">
                            <a><span>διοργανώσεις</span><span class=""></span></a>
                            <ul class="sub-menu" id="diorganwseiulidmobile" data-index="0" style="display: none;">
                                @code
                                    For Each g In oGetdiorganwseis
                                        @<li class="lipointer" ><a onclick="fillomiloinavbar(@g.Id);">@g.DiorganwshName</a></li>
                                    Next
                                End Code
                            </ul>
                        </li>

                        <li class="">
                            <a><span>διοργανωτρια αρχη</span><span class=""></span></a>
                            <ul class="sub-menu" id="diorgarxhpostsidmobile" data-index="1" style="display: none;">
                                @code
                                    For Each g In oGetSimplePosts
                                        @<li><a href="/Posts/Details/@g.Id">@g.PostTitle</a></li>
                                    Next
                                End Code
                            </ul>
                        </li>

                        <li class="">
                            <a href="@Url.Action("Create", "Newteam")"><span>εγγραφη ομαδας</span></a>
                        </li>

                        <li class="">
                            <a href="@Url.Action("Contact", "Home")"><span>επικοινωνια </span></a>
                        </li>

                        @if User.Identity.IsAuthenticated Then
                            If User.IsInRole("Admins") Then
                                @<li Class=""><a href="@Url.Action("Panel", "Home")"><span>διαχειριση</span></a></li>
                            End If
                        End If

                    </ul>
                </nav>
               

                @*<nav class="main-nav-mobile clearfix">                    
                    <ul class="main-menu sf-menu">
                        <li class="current-menu-item">
                            <a href="@Url.Action("Index", "Home")"><span>Αρχικη</span></a>
                        </li>
                        <li class="current-menu-item mm">
                            <a class="lipointer mm" onclick="fillomiloinavbar(@firstDiorganwshid, 1)"><span>Πρωταθλημα</span></a>
                        </li>
                        <li  class="current-menu-item">
                            <a><span>διοργανώσεις</span></a>
                            <ul class="sub-menu" id="diorganwseiulidmobile">
                                @code
                                    For Each g In oGetdiorganwseis
                                        @<li class="lipointer" onclick="fillomiloinavbar(@g.Id);"><a>@g.DiorganwshName</a></li>
                                    Next
                                End Code
                            </ul>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανωτρια αρχη</span></a>
                            <ul class="sub-menu" id="diorgarxhpostsidmobile">
                                @code
                                    For Each g In oGetSimplePosts
                                        @<li><a href="/Posts/Details/@g.Id">@g.PostTitle</a></li>
                                    Next
                                End Code
                            </ul>
                        </li>

                        <li class="current-menu-item">
                            <a href="@Url.Action("Create", "Newteam")"><span>εγγραφη ομαδας</span></a>
                                              
                        </li>

                        <li class="current-menu-item">
                            <a href="@Url.Action("Contact", "Home")"><span>επικοινωνια </span></a>
                        </li>

                        @if User.Identity.IsAuthenticated Then
                            If User.IsInRole("Admins") Then
                                @<li Class="current-menu-item"><a href="@Url.Action("Panel", "Home")"><span>διαχειριση</span></a></li>
                            End If
                        End If
                    </ul>
                </nav>*@

            </div>
        </div>

        <div class="kopa-header-bottom">
            <div class="wrapper">
                <nav class="th-kopa-main-nav-2">
                    <ul class="main-menu-2 sf-menu" id="omiloinavbarid"></ul>
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
            </div>

            <div class="wrapper">
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
    @Scripts.Render("~/bundles/custom2")

    <script type="text/javascript" src="~/Scripts/tinymce/tinymce.min.js"></script>

    @RenderSection("scripts", required:=False)

    @*<div id="fb-root"></div>
    <script>
        (function(d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>*@

</body>
</html>


<script type="text/javascript" language="javascript">

    $.widget.bridge('uibutton', $.ui.button);
    $.widget.bridge('uitooltip', $.ui.tooltip);

    $(function () {
        var bootstrapButton = $.fn.button.noConflict();// return $.fn.button to previously assigned value
        $.fn.bootstrapBtn = bootstrapButton;           // give $().bootstrapBtn the Bootstrap functionality
    });

    //fillomiloinavbar
    function fillomiloinavbar(i, t) {

        setTimeout(function () {

            t = t || 0;

            postDiorganwshid(i);

            var choiceContainer = $("#diorganwseiulid");
            var choiceContainermobile = $("#diorganwseiulidmobile");
            var mobilemainmenu = $("#mobilemainmenu");
         
            if (t = 0) {
                choiceContainer.toggle();
                choiceContainermobile.toggle();              
            }

            if (mobilemainmenu.is(':visible')) {
                mobilemainmenu.hide();
            }

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

                            var d = '<li class="lipointer" value = "' + this.Id + '"> ' +
                                    '<a class="sf-with-ul"><span>' + omilos + '</span></a>' +
                                    '<ul class="sub-menu" id="' + omilosnaming + '"> </ul> ' +
                                    '</li>';


                            @*<li class="">
                          <a><span>διοργανώσεις</span><span class=""></span></a>
                          <ul class="sub-menu" id="diorganwseiulidmobile" data-index="0" style="display: none;">
                              @code
                                  For Each g In oGetdiorganwseis
                                      @<li class="lipointer" ><a onclick="fillomiloinavbar(@g.Id);">@g.DiorganwshName</a></li>
                                  Next
                              End Code
                          </ul>
                      </li>*@

                            //'<a href="' + baseUrl + '/Home/Index/?a=' + this.Id + '"><span>' + omilos + '</span></a>' +

                            choiceContainer.append(d);
                            appendnewstoOmilos(omilosnaming, this.Id);

                        });

                        //setTimeout(function () {
                        var li = choiceContainer.children("li");
                        li.detach();
                        li.sort(function (a, b) {
                            return parseInt(a.id) > parseInt(b.id);
                        }).each(function () {
                            var elem = $(this);
                            elem.remove();
                            $(elem).prependTo(choiceContainer);
                        })
                        //}, 100);

                    }
                },
                error: function (result) {
                    alert(result.status + ' ' + result.statusText);
                }
            });
        }, 100);

    }

    /* =========================================================
    post diorganwsh
    ============================================================ */
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

    //append news in omilos
    function appendnewstoOmilos(containername, containerid) {

        $.ajax({
            type: "POST",
            url: baseUrl + '@Url.Action("GetKathgoriesbyOmilos", "Home")',
            data: "{OId: " + containerid + "}",
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {

                var choiceContainer = $("#" + containername);
                choiceContainer.empty();
                var i = 1;
                var d = '';
                if (result.length > 0) {

                    $.each(result, function () {
                        d += '<li class="lipointer" id="' + i + '"> <a href="/Home/Index/?ak=' + this.Id + '"> <span style="font-size: 12px !important" >' + this.KathgoriaName + '        </a> </span> </li> ';
                        i++;
                    });
                    choiceContainer.append(d);

                }
                //}, 100);
            },
            error: function (result) {
                alert(result.status + ' ' + result.statusText);
            }
        });
    }

    $(document).ready(function () {

        $('li').each(function () {
            this.onclick = function () { }
            this.touchstart = function () { }
        });

        //$('ul').each(function () {
        //    this.toggle;
        //});



       @*fillomiloinavbar(@firstDiorganwshid, 1)" onclick="fillomiloinavbar(@firstDiorganwshid, 1)"oinavbar(@firstDiorganwshid, 1)"*@
        //$("#prwtathlimaid2").on("click touchstart", function(){
        //    fillomiloinavbar($("#firstDiorganwshid").val());
        //});

        $('#loadingDiv')
             .hide()  // Hide it initially
             .ajaxStart(function () {
                 $(this).show();
             })
             .ajaxStop(function () {
                 $(this).hide();
             })
        ;


        //alert($("#firstDiorganwshid").val());

        fillomiloinavbar($("#firstDiorganwshid").val());


    });

</script>
