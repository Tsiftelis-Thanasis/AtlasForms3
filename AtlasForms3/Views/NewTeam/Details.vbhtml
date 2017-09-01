@ModelType AtlasForms3.Newteam
@Code

    Dim pdb As New AtlasBlogEntities

    ViewData("Title") = Model.teamname

    'Dim file1 As String = ""
    'If Model.teamroster IsNot Nothing Then
    '    Dim filebase64 As String = Convert.ToBase64String(Model.teamroster)
    '    file1 = String.Format("data:file/" & Model.teamrosterext & ";base64,{0}", filebase64)
    'End If

    'Dim filename1 As String = Model.teamname & "." & Model.teamrosterext

    Dim pdb2 As New AtlasStatisticsEntities
    Dim gipedostr = ""
    If Model.gipedo > 0 Then
        gipedostr = (From g In pdb2.GipedaTable
                     Where g.Id = Model.gipedo
                     Select g.GipedoName).FirstOrDefault
    End If

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
            @Html.DisplayNameFor(Function(model) model.teamcolor)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.teamcolor)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.gipedo)
        </dt>

        <dd>
            gipedostr
        </dd>

         <dt>
            @Html.DisplayNameFor(Function(model) model.teamrosterStr)
        </dt>

        <dd>            
            @Html.TextAreaFor(Function(model) model.teamrosterStr, New With {.cols = 100, .rows = 10, .readonly = "readonly"})            
        </dd>

         

        
    </dl>

</div>