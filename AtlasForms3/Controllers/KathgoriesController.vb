Imports System.IO
Imports System.Net.Http
Imports System.Net

<Compress>
Public Class KathgoriesController
    Inherits System.Web.Mvc.Controller

    Private pdb As New AtlasBlogEntities

    <Authorize(Roles:="Admins")>
    Function Index() As ActionResult
        Return View()
    End Function

    Function GetKathgoriesList() As JsonResult

        Dim q = (From t In pdb.BlogKathgoriesTable
                 Select t.Id, t.KathgoriaName, t.ActiveKathgoria
                ).AsEnumerable().[Select](
                Function(o) New With {.Kathgoriesid = o.Id, .KathgoriaName = o.KathgoriaName,
                .ActiveKathgoria = If(o.ActiveKathgoria = 0, "Ανενεργή", "Ενεργή")}).ToList

        Dim dtm As New DataTableModel
        If q IsNot Nothing Then
            dtm.data = q.Cast(Of Object).ToList
        End If
        dtm.draw = 0
        dtm.recordsTotal = dtm.data.Count
        dtm.recordsFiltered = dtm.recordsTotal

        Return Json(dtm, JsonRequestBehavior.AllowGet)
    End Function

    '
    ' GET: /Profile/Create
    <Authorize(Roles:="Admins")>
    Function Create() As ActionResult

        Dim t = New Kathgories
        t.ActiveKathgoria = True
        Return View(t)

    End Function

    '
    ' POST: /Profile/Create
    <Authorize(Roles:="Admins")>
    <HttpPost()>
    Function Create(ByVal _kat As Kathgories) As ActionResult
        Try

            If ModelState.IsValid Then

                Try

                    Dim k As New BlogKathgoriesTable

                    k.KathgoriaName = _kat.kathgorianame
                    k.ActiveKathgoria = If(_kat.ActiveKathgoria, 1, 0)
                    k.CreatedBy = User.Identity.Name
                    k.CreationDate = Now()
                    k.EditBy = User.Identity.Name
                    k.EditDate = Now()
                    pdb.BlogKathgoriesTable.Add(k)
                    pdb.SaveChanges()

                Catch ex As Exception
                    ViewBag.Error = "an error"
                    ModelState.AddModelError("error_msg", "an error")
                    Return View(_kat)
                End Try

                Return RedirectToAction("Index", "Kathgories")

            Else
                Return View(_kat)

            End If

        Catch ex As Exception

            ViewBag.Error = ex.Message
            ModelState.AddModelError("error_msg", ex.Message)
            Return View(_kat)

        End Try

    End Function


    ' GET: /Profile/Edit/5
    <Authorize(Roles:="Admins")>
    Function Edit(ByVal id As Integer) As ActionResult

        Dim q = (From t In pdb.BlogKathgoriesTable
                 Where t.Id = id
                 Select t).First

        Dim t1 As New Kathgories
        t1.Id = q.Id
        t1.kathgorianame = q.KathgoriaName
        t1.ActiveKathgoria = q.ActiveKathgoria
        t1.createdby = q.CreatedBy
        t1.creationdate = q.CreationDate
        t1.editby = q.EditBy
        t1.editdate = q.EditDate

        Return View(t1)

    End Function


    ' POST: /Profile/Edit
    <Authorize(Roles:="Admins")>
    <HttpPost()>
    Function Edit(ByVal _edkat As Kathgories) As ActionResult

        If ModelState.IsValid Then

            Try

                Dim editKathgories = pdb.BlogKathgoriesTable.Find(_edkat.Id)
                editKathgories.KathgoriaName = _edkat.kathgorianame
                editKathgories.ActiveKathgoria = _edkat.ActiveKathgoria
                editKathgories.EditBy = User.Identity.Name
                editKathgories.EditDate = Now()
                pdb.SaveChanges()

                Return RedirectToAction("Index", "Kathgories")

            Catch ex As Exception
                ModelState.AddModelError("error_msg", ex.Message)
                Return View(_edkat)
            End Try


        Else
            ModelState.AddModelError("error_msg", "error with model")
            Return View(_edkat)

        End If

    End Function

    Private Function Fixdate(ByVal str As String) As String

        Dim mydate As Date
        Try
            If str = "1900-01-01 00:00:00" Then
                Return ""
                Exit Function
            End If
            mydate = DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", Nothing)
            Return mydate.ToString("dd/MM/yyyy")
        Catch ex As Exception
            Return str
        End Try

    End Function



End Class



