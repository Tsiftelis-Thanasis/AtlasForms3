@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Register"
End Code

<h2>@ViewBag.Title.</h2>

@Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

    @Html.AntiForgeryToken()

    @<text>
    <h4>Register a new account.</h4>
    <hr />
    @Html.ValidationSummary("", New With {.class = "text-danger"})

    <p>Login details.</p>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.Username, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Username, New With {.class = "form-control"})
        </div>
   
        @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
        </div>
        @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
        </div>
        @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
        </div>
    </div>
<hr />

<div class="form-group">
    @Html.LabelFor(Function(m) m.Fullname, New With {.class = "col-md-2 control-label"})
    <div class="col-md-10">
        @Html.TextBoxFor(Function(m) m.Fullname, New With {.class = "form-control"})
    </div>
    @Html.LabelFor(Function(m) m.Address, New With {.class = "col-md-2 control-label"})
    <div class="col-md-10">
        @Html.TextBoxFor(Function(m) m.Address, New With {.class = "form-control"})
    </div>
    @Html.LabelFor(Function(m) m.Perioxi, New With {.class = "col-md-2 control-label"})
    <div class="col-md-10">
        @Html.TextBoxFor(Function(m) m.Perioxi, New With {.class = "form-control"})
    </div>
    @Html.LabelFor(Function(m) m.Poli, New With {.class = "col-md-2 control-label"})
    <div class="col-md-10">
        @Html.TextBoxFor(Function(m) m.Poli, New With {.class = "form-control"})
    </div>
    @Html.LabelFor(Function(m) m.Tk, New With {.class = "col-md-2 control-label"})
    <div class="col-md-10">
        @Html.TextBoxFor(Function(m) m.Tk, New With {.class = "form-control"})
    </div>
    @Html.LabelFor(Function(m) m.Afm, New With {.class = "col-md-2 control-label"})
    <div class="col-md-10">
        @Html.TextBoxFor(Function(m) m.Afm, New With {.class = "form-control"})
    </div>
    @Html.LabelFor(Function(m) m.Phone, New With {.class = "col-md-2 control-label"})
    <div class="col-md-10">
        @Html.TextBoxFor(Function(m) m.Phone, New With {.class = "form-control"})
    </div>
</div>

<hr />
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" class="btn btn-default" value="Register" />
        </div>
    </div>
    </text>
End Using

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
