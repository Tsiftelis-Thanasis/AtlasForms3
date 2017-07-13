@ModelType AtlasForms3.Posts

@Code
    ViewData("Title") = "Αλλαγή: " & Model.PostTitle

    @Html.ValidationMessage("error_msg")

    Dim pdb As New AtlasBlogEntities
    Dim pdb2 As New AtlasStatisticsEntities

    Dim katlist As New List(Of SelectListItem)
    Dim omiloilist As New List(Of SelectListItem)

    Dim katid = (From pak In pdb.BlogPostandKathgoriaTable
                 Where pak.PostId = Model.Id
                 Select pak.KathgoriaId).FirstOrDefault

    Dim omid = (From pak In pdb.BlogPostandKathgoriaTable
                Where pak.PostId = Model.Id
                Select pak.AtlasKathgoriaId).FirstOrDefault

    Dim list1 = (From p1 In pdb.BlogKathgoriesTable
                 Select p1.Id, p1.KathgoriaName).OrderBy(Function(p) p.KathgoriaName).ToList

    For Each it In list1
        If it.Id = katid Then
            katlist.Add(New SelectListItem() With {.Selected = True, .Text = it.KathgoriaName, .Value = it.Id})
        Else
            katlist.Add(New SelectListItem() With {.Selected = False, .Text = it.KathgoriaName, .Value = it.Id})
        End If
    Next


    Dim list2 = (From p1 In pdb2.OmilosTable
                 Select p1.Id, p1.OmilosName).OrderBy(Function(p) p.OmilosName).ToList

    For Each it In list2
        If it.Id = omid Then
            omiloilist.Add(New SelectListItem() With {.Selected = True, .Text = it.OmilosName, .Value = it.Id})
        Else
            omiloilist.Add(New SelectListItem() With {.Selected = False, .Text = it.OmilosName, .Value = it.Id})
        End If
    Next

    Dim imageSrc As String = ""
    If Model.PostPhoto IsNot Nothing Then
        Dim imageBase64 As String = Convert.ToBase64String(Model.PostPhoto)
        imageSrc = String.Format("data:image/png;base64,{0}", imageBase64)
    End If



End Code
<h2>@ViewBag.Title</h2>
<hr />

@Using (Html.BeginForm("Edit", "Posts", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)
    @Html.HiddenFor(Function(model) model.Id)

    @<div Class="kopa-entry-post">
    
    <article Class="entry-item">
           
        <div class="row">
            <div class="col-sm-2"><label>Τίτλος:</label></div>            
            <div class="col-lg-10">@Html.EditorFor(Function(model) model.PostTitle)</div>
        </div>
        
        <div class="row">
            <div class="col-sm-2"><label>Κατηγορία:</label></div>
            <div class="col-sm-10">
                @Html.DropDownList("kathgoria", katlist, New With {.id = "kathgoria", .class = "form-control chosen-select", .multiple = "false"})
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2"><label>Όμιλος:</label></div>
            <div class="col-sm-10">
                @Html.DropDownList("omilos", omiloilist, New With {.id = "omilos", .class = "form-control chosen-select", .multiple = "false"})
            </div>
        </div>
                

        <div class="row">
            <div class="col-sm-2"><label>Περίληψη:</label></div>  
            <div class="col-sm-10">
                @Html.EditorFor(Function(model) model.PostSummary)
            </div>
        </div>
        
        
        @Html.TextAreaFor(Function(m) m.PostBody)   

        Youtube link (code): <p Class="short-des"><i>@Html.EditorFor(Function(model) model.Youtubelink)</i></p>
        Statistics Link (just the number): <p Class="short-des"><i>@Html.EditorFor(Function(model) model.Statslink)</i></p>
        Active : <p Class="short-des"><i>@Html.CheckBoxFor(Function(m) m.Activepost)</i></p>
              
        @Html.LabelFor(Function(m) m.PostPhoto)
        <div Class="entry-thumb">
            <img src="@imageSrc" style="height:320px;width:320px;"/>
        </div>
        
        <input type="file" id="uploadEditorImage" name="uploadEditorImage" />
        @Html.Label("uploaddone", "Upload is done...", New With {.id = "uploaddone"})
        
        <div Class="entry-meta">
            <span Class="entry-author">Created by @Html.DisplayFor(Function(model) model.createdby)</span>
            <span Class="entry-date">Created on @Html.DisplayFor(Function(model) model.creationdate)</span>
            <br />
            <span Class="entry-author">Edit by @Html.DisplayFor(Function(model) model.editby)</span>
            <span Class="entry-date">Edited on @Html.DisplayFor(Function(model) model.editdate)</span>
        </div>
      
    </article>




</div>

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

    //$(function () {
    //    $('.chosen-select').chosen();
    //    $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
    //});


    $(document).ready(function () {
        $("#createdby").attr('readonly', 'readonly');
        $("#creationdate").attr('readonly', 'readonly');
        $("#editby").attr('readonly', 'readonly');
        $("#editdate").attr('readonly', 'readonly');

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
    });


    </script>
End Section
