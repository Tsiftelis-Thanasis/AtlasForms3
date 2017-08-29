@modeltype AtlasForms3.EditUserViewModel

@code
    ViewBag.Title = "Edit"
End code

<h2>Edit.</h2>


@Using (Html.BeginForm("Edit", "UsersAdmin", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"}))

    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Edit User Form.</h4>
        <hr />
        
        @Html.ValidationSummary(True)
        @Html.HiddenFor(Function(m) m.Id)
         @Html.HiddenFor(Function(m) m._showdates)
         @Html.HiddenFor(Function(m) m._showroles)

         
       <div class="form-group">
             @Html.LabelFor(Function(m) m.Username, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Username, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Username)
             </div>
         </div>


        <div class="form-group">
            @Html.LabelFor(Function(m) m.Email, New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
               @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
               @Html.ValidationMessageFor(Function(m) m.Email)
            </div>
        </div>


    

         <div class="form-group">
             @Html.LabelFor(Function(m) m.Phone, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Phone, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Phone)
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(m) m.IsEnabled, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @code
                     If Model.IsEnabled Then
                        @Html.CheckBox("IsEnabled", New With {.id = "IsEnabled", .class = "form-control", .checked = "checked", .value = True})
                     Else
                        @Html.CheckBox("IsEnabled", New With {.id = "IsEnabled", .class = "form-control", .value = False})
                     End If

                    @Html.ValidationMessageFor(Function(m) m.IsEnabled)

                End Code
       
             </div>
         </div>


       
        @If (Model._showroles) Then
             @<div class="form-group">
                @Html.Label("Roles", New With {.class = "control-label col-md-2"})
                 <span class=" col-md-10">
                @For Each item In Model.RolesList
                    @<input type="checkbox" name="SelectedRole" value="@item.Value" checked="@item.Selected" class="checkbox-inline" />
                    @Html.Label(item.Value, New With {.class = "control-label"})
                Next
                 </span>
             </div>
        End If

    
             <div class="form-group">
                 <div class="col-md-offset-2 col-md-10">
                     <input type="submit" value="Save" class="btn btn-default" />
                 </div>
             </div>
         </div>

                     End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@section Scripts 
    @Scripts.Render("~/bundles/jqueryval")

    <script type="text/javascript">

        $(function () {
            $('.chosen-select').chosen();
            $('.chosen-select-deselect').chosen({ allow_single_deselect: true });

            $('#IsEnabled').click(function () {
                if (!$(this).is(':checked')) {
                    $('#IsEnabled').val(false);
                }
                else {
                    $('#IsEnabled').val(true);                    
                }
            });

        });
    
    </script>
    

End Section
