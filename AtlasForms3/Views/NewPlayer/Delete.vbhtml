@ModelType AtlasForms3.NewPlayer
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Θελετε να σβησετε τον παρακατω παιχτη?</h3>
<div>
    
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.playername)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.playername)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.playeremail)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.playeremail)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.playerphone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.playerphone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.playerbirthdate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.playerbirthdate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.playerheight)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.playerheight)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.playerposition)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.playerposition)
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
