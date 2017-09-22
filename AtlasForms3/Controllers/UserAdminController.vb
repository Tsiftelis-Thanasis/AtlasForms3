Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web
Imports System.Web.Mvc


<Authorize(Roles:="Admins,Users,Superusers")> _
Public Class UsersAdminController
    Inherits Controller

    Dim aspdb As New AtlasStatisticsEntities

    Public Sub New()
    End Sub

    Public Sub New(userManager__1 As ApplicationUserManager, roleManager__2 As ApplicationRoleManager)
        UserManager = userManager__1
        RoleManager = roleManager__2
    End Sub

    Private _userManager As ApplicationUserManager
    Public Property UserManager() As ApplicationUserManager
        Get
            Return If(_userManager, HttpContext.GetOwinContext().GetUserManager(Of ApplicationUserManager)())
        End Get
        Private Set(value As ApplicationUserManager)
            _userManager = value
        End Set
    End Property

    Private _roleManager As ApplicationRoleManager
    Public Property RoleManager() As ApplicationRoleManager
        Get
            Return If(_roleManager, HttpContext.GetOwinContext().[Get](Of ApplicationRoleManager)())
        End Get
        Private Set(value As ApplicationRoleManager)
            _roleManager = value
        End Set
    End Property

    '
    ' GET: /Users/
    <Authorize(Roles:="Admins")>
    Public Function Index() As ActionResult
        Return View()
    End Function
    'Public Async Function Index() As Task(Of ActionResult)
    '    Return View(Await UserManager.Users.ToListAsync())
    'End Function

    '
    ' GET: /Users/Details/5
    Public Async Function Details(id As String) As Task(Of ActionResult)
        If id Is Nothing Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user = Await UserManager.FindByIdAsync(id)

        ViewBag.RoleNames = Await UserManager.GetRolesAsync(user.Id)

        Return View(user)
    End Function

    '
    ' GET: /Users/Create
    Public Function Create()
        'Get the list of Roles

        Dim rl As New List(Of SelectListItem)
        Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))

        For Each role In rm.Roles.ToList()
            rl.Add(New SelectListItem() With {.Selected = False, .Text = role.Name, .Value = role.Name})
        Next

        ViewBag.RoleId = rl.AsEnumerable

        Dim m As New RegisterViewModel
        Return View(m)

    End Function

    '
    ' POST: /Users/Create
    <HttpPost>
    Public Async Function Create(userViewModel As RegisterViewModel, Companies As String(), selectedRoles As String()) As Task(Of ActionResult)

        Dim aspdb As New AtlasBlogEntities

        Dim rl As New List(Of SelectListItem)
        Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))

        For Each role In rm.Roles.ToList()
            rl.Add(New SelectListItem() With {.Selected = False, .Text = role.Name, .Value = role.Name})
        Next

        If ModelState.IsValid Then

            Dim usercreated = New ApplicationUser() With {
                 .UserName = userViewModel.Username,
                 .Email = userViewModel.Email
            }

            ' Then create:
            Dim adminresult = Await UserManager.CreateAsync(usercreated, userViewModel.Password)

            'Add User to the selected Roles 
            If adminresult.Succeeded Then


                If selectedRoles IsNot Nothing Then
                    Dim result = Await UserManager.AddToRolesAsync(usercreated.Id, selectedRoles)
                    If Not result.Succeeded Then
                        ModelState.AddModelError("", result.Errors.First())
                        ViewBag.RoleId = rl.AsEnumerable
                        Dim m As New RegisterViewModel
                        Return View(m)
                    End If
                Else

                End If
            Else
                ModelState.AddModelError("", adminresult.Errors.First())
                ViewBag.RoleId = rl.AsEnumerable
                Dim m As New RegisterViewModel
                m = userViewModel
                Return View(m)
            End If
            Return RedirectToAction("Index")
        Else
            ModelState.AddModelError("", "Error with model")
            ViewBag.RoleId = rl.AsEnumerable
            Dim m As New RegisterViewModel
            m = userViewModel
            Return View(userViewModel)

        End If

    End Function


    '
    ' GET: /Users/Edit/1
    Public Async Function Edit(id As String) As Task(Of ActionResult)

        If id Is Nothing Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If


        Dim userlogged = Await UserManager.FindByNameAsync(User.Identity.Name)
        If userlogged Is Nothing Then
            Return HttpNotFound()
        End If
        Dim userlogginedRoles = Await UserManager.GetRolesAsync(userlogged.Id)


        Dim useredited = Await UserManager.FindByIdAsync(id)
        If useredited Is Nothing Then
            Return HttpNotFound()
        End If
        Dim userRoles = Await UserManager.GetRolesAsync(useredited.Id)

        Dim rl As New List(Of SelectListItem)
        Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))

        For Each role In rm.Roles.ToList()
            If userRoles.Contains(role.Name) Then
                rl.Add(New SelectListItem() With {.Selected = True, .Text = role.Name, .Value = role.Name})
            Else
                rl.Add(New SelectListItem() With {.Selected = False, .Text = role.Name, .Value = role.Name})
            End If
        Next

        Dim cl As New List(Of SelectListItem)
        Dim aspdb As New AtlasStatisticsEntities

        ', u.Address, u.Perioxi, u.Poli, u.Tk, u.Afm, _
        Dim userdb = (From u In aspdb.AspNetUsers
                      Where u.Id = useredited.Id
                      Select u.Fullname, u.Phone, islocked = If(u.IsLocked Is Nothing, False, True), isenabled = If(u.IsEnabled Is Nothing, 0, u.IsEnabled)).First

        Dim e As New EditUserViewModel() With {
            .Id = useredited.Id,
            .Username = useredited.UserName,
            .Email = useredited.Email,
            .Fullname = If(userdb.Fullname Is Nothing, "", userdb.Fullname),
            .IsEnabled = If(userdb.isenabled = 1, True, False),
            .IsLocked = userdb.islocked,
            .Phone = userdb.Phone,
            .RolesList = rl
            }
        '.Address = If(userdb.Address Is Nothing, "", userdb.Address), _
        '.Perioxi = If(userdb.Perioxi Is Nothing, "", userdb.Perioxi), _
        '.Poli = If(userdb.Poli Is Nothing, "", userdb.Poli), _
        '.Tk = If(userdb.Tk Is Nothing, "", userdb.Tk), _
        '.Afm = If(userdb.Afm Is Nothing, "", userdb.Afm), _
        '.Phone = If(userdb.Phone Is Nothing, "", userdb.Phone), _

        e._showroles = False
        e._showdates = False

        For Each role In userlogginedRoles
            If role.ToString = "Admins" Or role.ToString = "Superusers" Then
                e._showroles = True
                e._showdates = True
            End If
        Next

        Return View(e)


    End Function

    '
    ' POST: /Users/Edit/5
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Async Function Edit(editUser As EditUserViewModel,
                               selectedRole As String()) As Task(Of ActionResult)

        If ModelState.IsValid Then

            Dim useredited = Await UserManager.FindByIdAsync(editUser.Id)
            If useredited Is Nothing Then
                Return HttpNotFound()
            End If

            'useredited.UserName = editUser.Username
            'useredited.Email = editUser.Email

            Dim userRoles = Await UserManager.GetRolesAsync(useredited.Id)

            selectedRole = If(selectedRole, New String() {})

            Dim result = Await UserManager.AddToRolesAsync(useredited.Id, selectedRole.Except(userRoles).ToArray())

            If Not result.Succeeded Then
                ModelState.AddModelError("", result.Errors.First())
                Return View()
            End If

            result = Await UserManager.RemoveFromRolesAsync(useredited.Id, userRoles.Except(selectedRole).ToArray())

            If Not result.Succeeded Then
                ModelState.AddModelError("", result.Errors.First())
                Return View()
            End If

            'Dim e = From asp In aspdb.AspNetUsers
            '        Where asp.Id = useredited.Id

            Dim e As New AspNetUsers
            e = aspdb.AspNetUsers.Find(useredited.Id)
            e.UserName = editUser.Username
            e.Email = editUser.Email
            e.Fullname = editUser.Fullname
            'e.Address = editUser.Address
            'e.Perioxi = editUser.Perioxi
            'e.Poli = editUser.Poli
            'e.Tk = editUser.Tk
            'e.Afm = editUser.Afm
            e.Phone = editUser.Phone
            e.IsEnabled = If(editUser.IsEnabled = True, 1, 0)
            e.EmailConfirmed = editUser.IsEnabled
            e.IsLocked = editUser.IsLocked
            aspdb.SaveChanges()

            Return RedirectToAction("Index")
        End If
        ModelState.AddModelError("", "Something failed.")
        Return View()
    End Function

    '
    ' GET: /Users/Delete/5
    Public Async Function Delete(id As String) As Task(Of ActionResult)
        If id Is Nothing Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim user = Await UserManager.FindByIdAsync(id)
        If user Is Nothing Then
            Return HttpNotFound()
        End If
        Return View(user)
    End Function

    '
    ' POST: /Users/Delete/5
    <HttpPost, ActionName("Delete")>
    <ValidateAntiForgeryToken>
    Public Async Function DeleteConfirmed(id As String) As Task(Of ActionResult)
        If ModelState.IsValid Then
            If id Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim user = Await UserManager.FindByIdAsync(id)
            If user Is Nothing Then
                Return HttpNotFound()
            End If
            Dim result = Await UserManager.DeleteAsync(user)
            If Not result.Succeeded Then
                ModelState.AddModelError("", result.Errors.First())
                Return View()
            End If
            Return RedirectToAction("Index")
        End If
        Return View()
    End Function


    Function GetUsers() As JsonResult

        Dim q = (From p In aspdb.AspNetUsers
                 Select p.Email, p.IsEnabled, p.Id, p.UserName
                    ).AsEnumerable().[Select](
                    Function(o) New With {.id = o.Id, .username = o.UserName, .email = o.Email,
                    .isenabled = If(o.IsEnabled Is Nothing, "Όχι", If(o.IsEnabled = 0, "Όχι", "Ναί"))}).ToList

        Dim dtm As New DataTableModel
        If q IsNot Nothing Then
            dtm.data = q.Cast(Of Object).ToList
        End If
        dtm.draw = 0
        dtm.recordsTotal = dtm.data.Count
        dtm.recordsFiltered = dtm.recordsTotal

        Return Json(dtm, JsonRequestBehavior.AllowGet)
    End Function


End Class
