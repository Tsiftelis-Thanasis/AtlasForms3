@Code
    ViewData("Title") = "διαχειριση"
End Code
<h2>@ViewBag.Title</h2>
<hr />  

<div class="row ">   
    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4><i class="icon-cpanel homeicons"></i> άρθρα - διαφημίσεις</h4>
            </div>
            <div class="panel-body">
                <p>  @Html.ActionLink("Νέο Άρθρο", "Create", "Posts") </p>
            </div>
            @*<div class="panel-body">
                <p>  @Html.ActionLink("Νέα Διαφήμιση", "Posts", "Create") </p>
            </div>*@
            <div class="panel-body">
                <p> @Html.ActionLink("Λίστα όλων των άρθρων", "All", "Posts") </p>
            </div>
        </div>
    </div>
    
     <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4><i class="icon-cpanel homeicons"></i> Κατηγοριες </h4>
            </div>
            <div class="panel-body">
                <p> @Html.ActionLink("Νέα Κατηγορία", "Create", "Kathgories") </p>
            </div>
            <div class="panel-body">
                <p> @Html.ActionLink("Λίστα Κατηγοριών", "Index", "Kathgories") </p>
            </div>
        </div>
    </div>
      
    
</div>

<div class="row ">
    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4><i class="icon-useralt homeicons"></i> Διαχειριση χρηστων</h4>
            </div>
            @*<div class="panel-body">
                <p> @Html.ActionLink("Νέος Χρήστης", "All", "Create") </p>
            </div>*@
            <div class="panel-body">
                <p> @Html.ActionLink("Χρήστες", "Index", "UsersAdmin") </p>

            </div>
        </div>
    </div>
</div>




