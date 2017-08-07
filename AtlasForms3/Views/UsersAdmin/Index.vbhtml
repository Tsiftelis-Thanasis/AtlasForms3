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
            Ενεργός Χρήστης
        </th>        
        <th>
            @Html.Label("Actions")
        </th>     
    </tr>

@code

    Dim pdb2 As New AtlasStatisticsEntities

    @For Each item In Model

        Dim enableduser = (From u In pdb2.AspNetUsers
                           Where u.Id = item.Id
                           Select If(u.IsEnabled Is Nothing, 0, u.IsEnabled)).FirstOrDefault


        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.UserName)
            </td>
        <td>
            @Html.CheckBox("enableduser", If(enableduser = 0, False, True), New With {.style = "enabled=false;"})
        </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) 
            </td>
        </tr>

    Next

End Code

</table>
