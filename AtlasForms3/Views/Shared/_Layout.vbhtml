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

End code


<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    

   
    <meta property="fb:app_id" content="238332292965135" /> @*use ATLAS ID*@
    <meta property="og:site_name" content="Atlas" />
    <meta property="og:title" content="@(If(ViewBag.Title = "", "", ViewBag.Title & " - ")) Ατλας μπάσκετ" />
    <meta property="og:type" content="website" /> @*or article*@
    <meta property="og:image" content="" /> @*image to show for each page*@
    <meta property="og:description" content="" /> @*description for each page*@
    <meta property="og:url" content="" />   @*url of the page*@


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


    <div id="loadingDiv" class="modalloader"></div>


    @*change AppId to ATLAS one*@
    <div id="fb-root"></div>
    <script>
        (function(d, s, id) {
          var js, fjs = d.getElementsByTagName(s)[0];
          if (d.getElementById(id)) return;
          js = d.createElement(s); js.id = id;
          js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.9&appId=140586622674265";
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
                        <a href="@Url.Action("Index", "Home")"><img src="~/Content/images/logoAtlas.png" alt="logo" style="height:60px;"></a>
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
                            <ul class="sub-menu" id="diorganwseiulid"> </ul>
                        </li>
                        <li class="current-menu-item">
                            <a><span>διοργανωτρια αρχη</span></a>
                            <ul class="sub-menu" id="diorgarxhpostsid">                                                              
                            </ul>
                        </li>    
                        

                        <li class="current-menu-item">
                            <a><span>εγγραφες </span></a>
                            <ul class="sub-menu" >
                                <li>
                                    <a href="@Url.Action("Create", "Newplayer")"><span> παιχτη</span></a>                            
                                </li>
                                <li>
                                    <a href="@Url.Action("Create", "Newteam")"><span> ομαδας</span></a>   
                                </li>
                            </ul>
                        </li>
                    

                        @If User.Identity.IsAuthenticated Then
                            If User.IsInRole("Admins") Then
                                @<li Class="current-menu-item"><a href="@Url.Action("Panel", "Home")"><span>διαχειριση</span></a></li>
                            End If
                        End If

                        @*<li class="current-menu-item"><a href="/Account/Login" id="loginLink">Log in</a></li>*@

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
                        
                        <li class="current-menu-item">
                            <a><span>εγγραφες </span></a>
                            <ul class="sub-menu">
                                <li>
                                    <a href="@Url.Action("Create", "Newplayer")"><span> παιχτη</span></a>
                                </li>
                                <li>
                                    <a href="@Url.Action("Create", "Newteam")"><span> ομαδας</span></a>
                                </li>
                            </ul>
                        </li>
            
 
                        @if User.Identity.IsAuthenticated Then
                            If User.IsInRole("Admins") Then
                                @<li Class="current-menu-item"><a href="@Url.Action("Panel", "Home")"><span>διαχειριση</span></a></li>
                            End If
                        End If

                        @*<li class="current-menu-item"><a href="/Account/Login" id="loginLink">Log in</a></li>*@


                    </ul>
                </nav>                
            </div> 
        </div>
      
        <div class="kopa-header-bottom">
            <div class="wrapper">
              <nav class="th-kopa-main-nav-2">
                    <ul class="main-menu-2 sf-menu" id="omiloinavbarid">                        
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
    @*@Scripts.Render("~/bundles/tinymce")*@
    @Scripts.Render("~/bundles/custom2")

    <script type="text/javascript" src="../Scripts/tinymce/tinymce.min.js"></script>

    @RenderSection("scripts", required:=False)
    
    <div id="fb-root"></div>
    <script>
        (function(d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
   </script>

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

        setTimeout(function () {

            t = t || 0;

            postDiorganwshid(i);

            var choiceContainer = $("#diorganwseiulid");
            var choiceContainermobile = $("#diorganwseiulidmobile");
            if (t = 0) {
                choiceContainer.toggle();
                choiceContainermobile.toggle();
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
                                    '<a  <a href="' + baseUrl + '/Home/Index/?a=' + this.Id + '"><span>' + omilos + '</span></a>' +
                                    '<ul class="sub-menu" id="' + omilosnaming + '"> </ul> ' +
                                    '</li>';

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



    /* =========================================================
    get programma id
    ============================================================ */
    function getProgrammaId(atlaskathgoriaid) {

        var progid;
        $.ajax({
            type: "POST",
            url: baseUrl + '@Url.Action("GetProgrammaidbyKathgoria", "Home")',
            data: "{atlaskathgoriaid: " + atlaskathgoriaid + "}",
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                progid = result;
            },
            error: function (result) {
                progid = 0;
            }
        });

        return progid;
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

                //setTimeout(function () {
                var i = 1;
                var d = '';
                if (result.length > 0) {
                    $.each(result, function () {
                        d += '<li class="lipointer" id="' + i + '"> <a href="@Url.Action("Index", "Posts")/?ak=' + this.Id + '&k=11"> <span style="font-size: 12px; !important" >Νεα ' + this.KathgoriaName + '        </a> </span> </li> ';
                        i++;
                    });
                    $.each(result, function () {
                        d += '<li class="lipointer" id="' + i + 1 + '"> <a href="@Url.Action("Index", "Posts")/?ak=' + this.Id + '&k=12"> <span style="font-size: 12px; !important" >Ομαδες ' + this.KathgoriaName + '     </a> </span> </li> ';
                        i++;
                    });
                    $.each(result, function () {
                        d += '<li class="lipointer" id="' + i + 2 + '"> <a href="@Url.Action("Index", "Posts")/?ak=' + this.Id + '&k=15"> <span style="font-size: 12px; !important" >Βαθμολογιες ' + this.KathgoriaName + '</a> </span> </li> ';
                        i++;
                    });
                    if ($("#UserisAuthenticated").val() > 0) {
                        $.each(result, function () {
                            d += '<li class="lipointer" id="' + i + 3 + '"> <a href="' + baseUrl + '/Posts/Details/' + getProgrammaId(this.Id) + '"> <span style="font-size: 12px; !important" >Προγραμμα ' + this.KathgoriaName + '  </a> </span> </li> ';
                            i++;
                        });
                    }

                    $.each(result, function () {
                        d += '<li class="lipointer" id="' + i + 4 + '"> <a href="@Url.Action("Index", "Posts")/?ak=' + this.Id + '&k=13"> <span style="font-size: 12px; !important" >Τιμωριες ' + this.KathgoriaName + '   </a> </span> </li> ';
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


    // get diorganwtria arxh arthra
    function GetDiorganwtria() {

        return $.ajax({
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

    }

    function GetDiorganwseis() {


        // get diorganwseis
      return  $.ajax({
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
                        var d = '<li class="lipointer" onclick="fillomiloinavbar(' + this.Id + ');"><a>' + this.DiorganwshName + '</a></li>';
                        choiceContainer.append(d);
                        choiceContainermobile.append(d);
                    });
                }
            },
            error: function (result) {
                alert(result.status + ' ' + result.statusText);
            }
        });

    }



    $(document).ready(function () {



        $('#loadingDiv')
             .hide()  // Hide it initially
             .ajaxStart(function () {
                 $(this).show();
             })
             .ajaxStop(function () {
                 $(this).hide();
             })
        ;

        
        var newPromise = $.Deferred();

        $.when(newPromise).done(function () {
            GetDiorganwtria();
        });
        
        newPromise.then(function () {
            GetDiorganwseis();
        });

        newPromise.resolve();


    });

    $(window).on('load', function () {
        setTimeout(function () {
            fillomiloinavbar($("#firstDiorganwshid").val());
        }, 100);
    });


</script>
