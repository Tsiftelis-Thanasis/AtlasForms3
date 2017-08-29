@ModelType RegisterViewModel
@Code
End Code
@Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

    @Html.AntiForgeryToken()

    @<text>
    <h4>Register a new account.</h4>
    <hr />
    @Html.ValidationSummary("", New With {.class = "text-danger"})

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
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" class="btn btn-default" value="Register" />
        </div>
    </div>
    </text>
End Using

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
