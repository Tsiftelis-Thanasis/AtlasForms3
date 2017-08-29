@ModelType AtlasForms3.Newteam
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Θελετε να σβησετε την παρακάτω ομάδα;</h3>
<div>
    
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.teamname)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.teamname)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.teamemail)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.teamemail)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.teamphone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.teamphone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.createdby)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.createdby)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.creationdate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.creationdate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.editby)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.editby)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.editdate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.editdate)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
