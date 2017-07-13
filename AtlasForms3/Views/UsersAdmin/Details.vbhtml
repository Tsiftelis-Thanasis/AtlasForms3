@ModelType atlasbasketstatistics.ApplicationUser


@code
    ViewBag.Title = "Details"
End code

<h2>Details.</h2>

<div>
    <h4>User</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </dt>
        <dd>
            @Html.Displayfor(Function(model) model.UserName)
        </dd>
    </dl>
</div>
<h4>List of roles for this user</h4>
@If (ViewBag.RoleNames.Count = 0) Then
    @<hr />
    @<p>No roles found for this user.</p>
end if

<table class="table">

    @For Each item In ViewBag.RoleNames
        @<tr>
            <td>
                @item
            </td>
        </tr>
    Next
        
</table>

<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>



