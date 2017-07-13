@modeltype IEnumerable(of ApplicationUser)

@code
    ViewBag.Title = "Index"
End code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>        
        <th>
            @Html.Label("Actions")
        </th>     
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.Displayfor(Function(modelItem) item.UserName)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) 
            </td>
        </tr>
    Next

</table>
