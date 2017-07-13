@ModelType LoginViewModel
@Code
    ViewBag.Title = "Log in"
End Code

<h2>@ViewBag.Title.</h2>
    
        <section id="loginForm">
            @Using Html.BeginForm("Login", "Account", New With { .ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @<text>
                <h4>Use a local account to log in.</h4>
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                <div class="form-group">
                    @Html.LabelFor(Function(m) m.Username, New With {.class = "control-label"})
                    @Html.TextBoxFor(Function(m) m.Username, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.Username, "", New With {.class = "text-danger"})
                    
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(m) m.Password, New With {.class = "control-label"})
                    @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                </div>
                <div class="form-group">
                        <div class="checkbox">
                            @Html.CheckBoxFor(Function(m) m.RememberMe)
                            @Html.LabelFor(Function(m) m.RememberMe)
                        </div>                    
                </div>
            
            <div class="form-group">
                <input type="submit" value="Log in" class="btn btn-default" />
                <p>
                    @Html.ActionLink("Forgot your password?", "ForgotPassword")
                </p>
            </div>

                </text>
            End Using
        </section>
    

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
