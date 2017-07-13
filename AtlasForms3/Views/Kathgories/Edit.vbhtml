@ModelType AtlasForms3.Kathgories

@Code
    ViewData("Title") = Model.kathgorianame
    @Html.ValidationMessage("error_msg")

End Code
<h2>@ViewBag.Title</h2>
<hr />

@Using (Html.BeginForm("Edit", "Kathgories", FormMethod.Post, New With {.enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)
    @Html.HiddenFor(Function(model) model.Id)

    @<div Class="row">
    @Html.LabelFor(Function(m) m.kathgorianame, htmlAttributes:=New With {.class = "control-label col-md-4"})
    @Html.EditorFor(Function(m) m.kathgorianame, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div class="row">
    @Html.LabelFor(Function(m) m.ActiveKathgoria, htmlAttributes:=New With {.class = "control-label col-md-4"})
    @Html.CheckBoxFor(Function(m) m.ActiveKathgoria, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>

    @<div Class="row">
    @Html.LabelFor(Function(m) m.createdby, htmlAttributes:=New With {.class = "control-label col-md-4"})
    @Html.EditorFor(Function(m) m.createdby, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div class="row">
    @Html.LabelFor(Function(m) m.creationdate, htmlAttributes:=New With {.class = "control-label col-md-4"})
    @Html.EditorFor(Function(m) m.creationdate, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div class="row">
    @Html.LabelFor(Function(m) m.editby, htmlAttributes:=New With {.class = "control-label col-md-4"})
    @Html.EditorFor(Function(m) m.editby, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>
    @<div Class="row">
    @Html.LabelFor(Function(m) m.editdate, htmlAttributes:=New With {.class = "control-label col-md-4"})
    @Html.EditorFor(Function(m) m.editdate, New With {.htmlAttributes = New With {.class = "form-control"}})
    </div>

    @<div class="form-group">
        <input type="submit" name="Command" value="Αλλαγή" Class="btn btn-default" />
    </div>

End Using

        <hr />
        <div>
            @Html.ActionLink("Επιστροφή", "Index", "Kathgories")
        </div>

@Scripts.Render("~/bundles/jqueryval")
        @Section Scripts
            <script type="text/javascript">

                $(document).ready(function () {

                    $("#createdby").attr('readonly', 'readonly');
                    $("#creationdate").attr('readonly', 'readonly');
                    $("#editby").attr('readonly', 'readonly');
                    $("#editdate").attr('readonly', 'readonly');

                });


            </script>
        End Section
