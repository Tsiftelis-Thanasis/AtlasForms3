@*@modeltype atlasbasketstatistics.EditUserViewModel

@code
    ViewBag.Title = "Edit"
End code

<h2>Edit.</h2>

@Using (Html.BeginForm)
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Edit User Form.</h4>
        <hr />
        
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(true)
        @Html.HiddenFor(Function(m) m.Id)
         @Html.HiddenFor(Function(m) m._showcompanies)
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
               @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control" })
               @Html.ValidationMessageFor(Function(m) m.Email)
            </div>
        </div>


         <div class="form-group">
             @Html.LabelFor(Function(m) m.Fullname, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Fullname, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Fullname)
             </div>
         </div>


         <div class="form-group">
             @Html.LabelFor(Function(m) m.Address, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Address, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Address)
             </div>
         </div>


         <div class="form-group">
             @Html.LabelFor(Function(m) m.Perioxi, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Perioxi, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Perioxi)
             </div>
         </div>


         <div class="form-group">
             @Html.LabelFor(Function(m) m.Poli, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Poli, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Poli)
             </div>
         </div>


         <div class="form-group">
             @Html.LabelFor(Function(m) m.Tk, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Tk, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Tk)
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(m) m.Afm, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Afm, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Afm)
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(m) m.Phone, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextBoxFor(Function(m) m.Phone, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(m) m.Phone)
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
        });
    
    </script>
    

End Section*@
