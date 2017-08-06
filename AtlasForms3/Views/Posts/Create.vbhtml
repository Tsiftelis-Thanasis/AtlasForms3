@ModelType AtlasForms3.Posts

@Code

    @Html.ValidationMessage("error_msg")

    Dim pdb As New AtlasBlogEntities
    Dim pdb2 As New AtlasStatisticsEntities

    Dim katlist As New List(Of SelectListItem)
    Dim omiloilist As New List(Of SelectListItem)
    Dim atlaskatlist As New List(Of SelectListItem)

    Dim list1 = (From p1 In pdb.BlogKathgoriesTable
                 Select p1.Id, p1.KathgoriaName).OrderBy(Function(p) p.KathgoriaName).ToList

    For Each it In list1
        katlist.Add(New SelectListItem() With {.Selected = False, .Text = it.KathgoriaName, .Value = it.Id})
    Next


    Dim list2 = (From o In pdb2.OmilosTable
                 Join d In pdb2.DiorganwshTable On d.Id Equals o.Diorganwshid
                 Join s In pdb2.SeasonTable On s.Id Equals d.Seasonid
                 Where s.ActiveSeason = True
                 Select o.Id, OmilosName = o.OmilosName & " (" & d.DiorganwshName & ")").OrderBy(Function(p) p.OmilosName).ToList

    For Each it In list2
        omiloilist.Add(New SelectListItem() With {.Selected = False, .Text = it.OmilosName, .Value = it.Id})
    Next


    Dim list3 = (From k In pdb2.KathgoriesTable
                 Join o In pdb2.OmilosTable On k.Omilosid Equals o.Id
                 Join d In pdb2.DiorganwshTable On d.Id Equals o.Diorganwshid
                 Join s In pdb2.SeasonTable On s.Id Equals d.Seasonid
                 Where s.ActiveSeason = True
                 Select k.Id, KathgoriaName = k.KathgoriaName).OrderBy(Function(p) p.KathgoriaName).ToList

    For Each it In list3
        atlaskatlist.Add(New SelectListItem() With {.Selected = False, .Text = it.KathgoriaName, .Value = it.Id})
    Next


End Code

@Using (Html.BeginForm("Create", "Posts", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)


    @<article Class="entry-item">
        <div class="container">
            <div class="row">
                <div class="col-md-11 section">
                    <div class="row section-header">
                        <h2>δημιουργία</h2>
                    </div>

                    <div class="row form-horizontal">
                        <div class="form-group">
                            <label for="title" class="col-md-1 control-label">Τίτλος</label>
                            <div class="col-md-11">
                                @Html.TextBoxFor(Function(model) model.PostTitle, New With {.class = "form-control input-text"})
                            </div>
                        </div>
                    </div>


                    <div class="row form-horizontal">
                        <div class="form-group">
                            <label for="title" class="col-md-1 control-label">Κατηγορία</label>
                            <div class="col-sm-5">
                                @Html.DropDownList("kathgoria", katlist, "Please select...", New With {.id = "kathgoria", .class = "form-control chosen-select"})
                            </div>
                        </div>
                    </div>
                    <div class="row form-horizontal">
                        <div class="form-group">
                            <label for="title" class="col-md-1 control-label">Όμιλος  (στατιστικά)</label>
                            <div class="col-sm-5">
                                @Html.DropDownList("omilos", omiloilist, "Please select...", New With {.id = "omilos", .class = "form-control chosen-select"})
                            </div>
                        </div>
                    </div>
                    <div class="row form-horizontal">
                        <div class="form-group">
                            <label for="title" class="col-md-1 control-label">Κατηγορία  (στατιστικά)</label>
                            <div class="col-sm-5">
                                @Html.DropDownList("atlaskathgoria", atlaskatlist, "Please select...", New With {.id = "atlaskathgoria", .class = "form-control chosen-select"})
                            </div>
                        </div>
                    </div>

                    <div class="row form-horizontal">
                        <div class="form-group">
                            <label for="title" class="col-md-1 control-label">Περίληψη</label>
                            <div class="col-md-11">
                                @Html.TextBoxFor(Function(model) model.PostSummary, New With {.class = "form-control input-text"})
                            </div>
                        </div>
                    </div>


                    <div class="row form-horizontal">
                        <div class="form-group">
                            <label for="title" class="col-md-2 control-label">Youtube link (code) </label>
                            <div class="col-md-4">
                                @Html.TextBoxFor(Function(model) model.Youtubelink, New With {.class = "form-control input-text"})
                            </div>

                            <label for="title" class="col-md-2 control-label">Statistics Link (number) </label>
                            <div class="col-md-4">
                                @Html.TextBoxFor(Function(model) model.Statslink, New With {.class = "form-control input-text"})
                            </div>
                          
                        </div>
                    </div>

                    <div class="row form-horizontal">

                    </div>

                    <div class="row form-horizontal">
                        <div class="form-group">
                            <label class="col-md-1 control-label">Φωτογραφία</label>
                            <div class="col-md-2">
                                <input type="file" class="btn btn-default" id="uploadEditorImage" name="uploadEditorImage" />
                            </div>
                            <div class="col-md-9">
                                <label class="control-label" name="uploaddone" id="uploaddone">ανέβηκε η φωτογραφία...</label>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row form-horizontal">
                        <div class="form-group">
                            @Html.TextAreaFor(Function(m) m.PostBody)
                        </div>
                    </div>


                </div>
            </div>
        </div>

    

    </article>



    @<div class="form-group">
        <input type="submit" name="Command" value="Αποθήκευση" class="btn btn-default" />
    </div>

End Using

<hr />
<div>
    @Html.ActionLink("Επιστροφή", "Index", "Posts")
</div>


@Section Scripts
    <script type="text/javascript">

        $(function () {
            $('.chosen-select').chosen();
            $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
        });
        
    tinymce.init({
        selector: 'textarea',
        height: 500,
        menubar: false,
        plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table contextmenu paste code'
        ],
        toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
        content_css: [
            '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
            '//www.tinymce.com/css/codepen.min.css']
    });


    $(document).ready(function () {
     
        $('#uploaddone').hide();

        $("#uploadEditorImage").change(function () {
            var data = new FormData();
            var files = $("#uploadEditorImage").get(0).files;
            if (files.length > 0) {
                $('#uploaddone').show();
            }
            else {
                $('#uploaddone').hide();
            }
        });

        cleankathgories();
        fillkathgories();

        $("#omilos").change(function () {
            cleankathgories();
            fillkathgories();            
        });

    });
        
    function cleankathgories() {
        $("#atlaskathgoria").empty();
        $("#atlaskathgoria").trigger("chosen:updated");
    }

    function fillkathgories() {

        var sid = $("#omilos").val();

        if (sid > 0) {

            setTimeout(function () {

                $.ajax({
                    type: "POST",
                    url: '@Url.Action("GetKathgories", "Home")',
                    data: { id: sid },
                    success: function (data) {
                        var items = [];
                        items.push("<option value=''>Παρακαλώ επιλέξτε...</option>");
                        $.each(data, function () {
                            items.push("<option value=" + this.value + ">" + this.text + "</option>");
                        });
                        $("#atlaskathgoria").html(items.join(' '));
                        $("#atlaskathgoria").trigger("chosen:updated");
                    },
                    error: function (msg) { alert(msg); }
                })

            }, 10);

        }

        else {
            $("#atlaskathgoria").empty();
            $("#atlaskathgoria").trigger("chosen:updated");
        }

    }


    </script>
End Section
