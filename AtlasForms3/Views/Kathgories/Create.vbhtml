@ModelType AtlasForms3.Kathgories
@Code

    ViewData("Title") = "Δημιουργία Κατηγορίας"
    @Html.ValidationMessage("error_msg")


End Code
<h2>@ViewBag.Title</h2>
<hr />

@Using (Html.BeginForm("Create", "Kathgories", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))

@Html.AntiForgeryToken()
@Html.ValidationSummary(True)


@<div Class="row">
    @Html.LabelFor(Function(m) m.kathgorianame, htmlAttributes:=New With {.class = "control-label"})
    @Html.EditorFor(Function(m) m.kathgorianame, New With {.htmlAttributes = New With {.class = "form-control"}})    
</div>

@<div class="row">
    @Html.LabelFor(Function(m) m.ActiveKathgoria, htmlAttributes:=New With {.class = "control-label"})
    @Html.CheckBoxFor(Function(m) m.ActiveKathgoria, New With {.htmlAttributes = New With {.class = "form-control"}})
</div>

@<input type="submit" value="Αποθήκευση" class="btn btn-default" />

End Using

<hr />

<div>
    @Html.ActionLink("Επιστροφή", "Index", "Kathgories")
</div>

