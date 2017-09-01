@ModelType AtlasForms3.Posts
@Code
    ViewData("Title") = "Delete"
End Code

<h3>Θελετε να σβησετε το συγκεκριμένο άρθρο;</h3>
<div>
    
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PostTitle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PostTitle)
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
            @Html.ActionLink("Back to List", "All")
        </div>
    End Using
</div>
