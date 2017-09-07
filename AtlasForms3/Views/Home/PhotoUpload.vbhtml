@ModelType AtlasForms3.Newteam
@Code
    ViewData("Title") = "Εγγραφή"


    Dim pdb2 As New AtlasStatisticsEntities

    Dim gList As New List(Of SelectListItem)

    Dim list1 = (From p1 In pdb2.GipedaTable
                 Select p1.Id, p1.GipedoName).OrderBy(Function(p) p.GipedoName).ToList

    For Each it In list1
        gList.Add(New SelectListItem() With {.Text = it.GipedoName, .Value = it.Id})
    Next


End Code

@*<h2>Create</h2>*@


@Using (Html.BeginForm("Create", "NewTeam", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))

    @Html.ValidationSummary(True)
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Εγγραφη</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.teamname, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.teamname, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.teamname, "", New With { .class = "text-danger" })
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.teamleadername, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.teamleadername, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.teamleadername, "", New With {.class = "text-danger"})
             </div>
         </div>


        <div class="form-group">
            @Html.LabelFor(Function(model) model.teamemail, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.teamemail, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.teamemail, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.teamphone, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.teamphone, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.teamphone, "", New With { .class = "text-danger" })
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.teamcolor, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.teamcolor, New With {.htmlAttributes = New With {.class = "form-control"}})                 
             </div>
         </div>


         <div class="form-group">
             @Html.LabelFor(Function(model) model.gipedo, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">                 
                 @Html.DropDownList("gipedo", gList, "Please select...", New With {.id = "gipedo", .class = "form-control chosen-select"})           
             </div>
         </div>


         <div class="form-group">
             @Html.LabelFor(Function(model) model.teamrosterStr, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextAreaFor(Function(model) model.teamrosterStr, New With {.cols = 100, .rows = 10})
             </div>
             @*@Html.Label("Συμπληρώστε την ομαδα σας. Ονοματεπώνυμο παιχτών και αριθμό εμφάνισης")*@
         </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Εγγραφή" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using


@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")

<script type="text/javascript">
          

    $(function () {
        $('.chosen-select').chosen();
        $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
    });


    $(document).ready(function () {

        $('#uploaddone').hide();

        $("#uploadedroster").change(function () {
            var data = new FormData();
            var files = $("#uploadedroster").get(0).files;
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
