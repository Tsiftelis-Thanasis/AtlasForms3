@ModelType AtlasForms3.ApplicationUser

@code
    ViewBag.Title = "Delete"
End code

<h2>Delete</h2>

<h3>Ειστε σίγουροι για την διαγραφή; Μετά την διαγραφή δεν μπορεί να γίνει επαναφορά!</h3>

<div>
    <h4>User.</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.username)
        </dt>

        <dd>
            @Html.Displayfor(Function(model) model.UserName)
        </dd>
    </dl>

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Επιστροφή", "Index")
        </div>

    End Using
</div>
