@ModelType AtlasForms3.NewPlayer
@Code

    Dim pdb As New AtlasBlogEntities

    ViewData("Title") = Model.playername


End Code


@Html.AntiForgeryToken()
@Html.ValidationSummary(True)
@Html.HiddenFor(Function(model) model.Id)

<h4>στοιχεια παιχτη</h4>
<hr />

<div>


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



    </dl>

</div>