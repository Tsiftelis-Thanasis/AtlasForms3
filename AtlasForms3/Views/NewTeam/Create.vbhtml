@ModelType AtlasForms3.Newteam
@Code
    ViewData("Title") = "Εγγραφή"
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
            @Html.LabelFor(Function(model) model.teamroster, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="col-md-2">
                    <input type="file" class="btn btn-default" id="uploadedroster" name="uploadedroster" />
                </div>
                <div class="col-md-8">
                    <label class="control-label" name="uploaddone" id="uploaddone">ανέβηκε το αρχείο...</label>
                </div>                
            </div>
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
