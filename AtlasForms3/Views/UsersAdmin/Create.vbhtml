@Modeltype AtlasForms3.RegisterViewModel

@Code
    ViewBag.Title = "Create"
end code

<h2>@ViewBag.Title.</h2>

@Using (Html.BeginForm("Create", "UsersAdmin", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"}))

    @Html.AntiForgeryToken()
    
    @<h4>Create a new account.</h4>
    @<hr />
    @Html.ValidationSummary("", New With {.class = "text-error" })
    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Username, htmlAttributes:=New With {.class = "control-label col-md-2"})        
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Username, New With {.class = "form-control"})
        </div>
    </div>
    
    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
        </div>
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label" })
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control" })
        </div>
    </div>
    
    @<div class="form-group">
        @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-md-2 control-label" })
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control" })
        </div>
    </div>

    @<div class="form-group">
        <label class="col-md-2 control-label">Select User Role</label>
        <div class="col-md-10">
            @For Each item In ViewBag.RoleId
            @<input type="checkbox" name="SelectedRoles" value="@item.Value" class="checkbox-inline" />
            @<label class = "control-label">@item.Text</label>
            Next
        </div>
    </div>
    @<div class="form-group">
        <div class="col-md-offset-2 col-md-10">
        <input type="submit" class="btn btn-default" value="Create" />
        </div>
    </div>
    End Using


@section Scripts 
    @Scripts.Render("~/bundles/jqueryval")

<script type="text/javascript">

        $(function () {
            $('.chosen-select').chosen();
            $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
        });

</script>

end section
