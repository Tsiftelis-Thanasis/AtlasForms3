@ModelType AtlasForms3.Newteam
@Code

    Dim pdb As New AtlasBlogEntities

    ViewData("Title") = Model.teamname

    Dim file1 As String = ""
    If Model.teamroster IsNot Nothing Then
        Dim filebase64 As String = Convert.ToBase64String(Model.teamroster)
        file1 = String.Format("data:file/" & Model.teamrosterext & ";base64,{0}", filebase64)
    End If

    Dim filename1 As String = Model.teamname & "." & Model.teamrosterext

End Code


@Html.AntiForgeryToken()
@Html.ValidationSummary(True)
@Html.HiddenFor(Function(model) model.Id)

<h4>στοιχεια ομαδας</h4>
<hr />

<div>


    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.teamname)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.teamname)
        </dd>


        <dt>
            @Html.DisplayNameFor(Function(model) model.teamleadername)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.teamleadername)
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
            @Html.DisplayNameFor(Function(model) model.teamroster)
        </dt>

        <dd>
            <a href="@file1" download="@filename1"><span>Το αρχείο  </span><i class="fa fa-file-text-o"> </i></a>            
             
        </dd>

    </dl>

</div>