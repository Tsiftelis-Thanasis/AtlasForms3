@Code
    ViewData("Title") = "επικοινωνια"
End Code

<div class="row rowflex">
    <div class="col-md-1 colflex panelBackground">
        <a target="_blank" href="http://partner.sbaffiliates.com/processing/clickthrgh.asp?btag=a_63418b_46560&aid="><img id="sticker1" src="~/Content/images/sb1-site.jpg" class="w3-center" alt="logo" style="position:fixed;" /></a>
    </div>


    <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10 colflex">

        <div class="panelBackground0 w3-center" style="padding-left:0px;padding-right:0px;">
            <a target="_blank" href="http://partner.sbaffiliates.com/processing/clickthrgh.asp?btag=a_63418b_46560&aid="><img src="~/Content/images/sb0-site.png" class="w3-center" alt="logo" /></a>
        </div>

        <div>


            <img src="~/Content/images/logoAtlas.png" alt="logo" style="height:60px;">

            <address>
                <br />
                <abbr title="Phone">6955146575</abbr><br />
                <abbr title="Phone">6946792744</abbr><br />

                <strong>Υποστήριξη:</strong>   <a href="mailto:ATLASBASKETBALLTEAM@GMAIL.COM">ATLASBASKETBALLTEAM@GMAIL.COM</a><br />

            </address>


            <hr />

            <h4>@ViewData("Title")</h4>

            @Using (Html.BeginForm("Contact", "Home", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))

                @Html.ValidationSummary(True)
                @Html.AntiForgeryToken()

                @<div class="form-horizontal">

                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

                    <div class="form-group">
                        @Html.Label("Ονοματεπώνυμο", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.Editor("name", New With {.htmlAttributes = New With {.id = "name", .class = "form-control"}})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.Label("Email", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.Editor("email", New With {.htmlAttributes = New With {.id = "email", .class = "form-control"}})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.Label("Θέμα", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.Editor("subj", New With {.htmlAttributes = New With {.id = "subj", .class = "form-control"}})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.Label("Κείμενο", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.TextArea("body", New With {.id = "body", .cols = 100, .rows = 10})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.Label("Αποστολή αντίγραφου", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.CheckBox("copy", New With {.id = "copy"})
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" value="Αποστολή" class="btn btn-default" />
                        </div>
                    </div>
                </div>
            End Using




        </div>

    </div>


    <div Class="col-md-1 colflex panelBackground">
        <a target="_blank" href="http://partner.sbaffiliates.com/processing/clickthrgh.asp?btag=a_63418b_46560&aid="><img id="sticker2" src="~/Content/images/sb2-site.jpg" Class="w3-center" alt="logo" style="position:fixed;" /></a>
    </div>
</div>



    @Section Scripts
        @Scripts.Render("~/bundles/jqueryval")

    End Section

