﻿Imports System.Web.Mvc
Imports System.IO

Namespace Controllers
    Public Class NewTeamController
        Inherits Controller

        Private pdb As New AtlasBlogEntities


        ' GET: Newteam
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Newteam/Details/5
        Function Details(ByVal id As Integer) As ActionResult

            If id > 0 Then


                Dim p = (From t In pdb.BlogNewTeam
                         Where t.Id = id
                         Select t).First

                Dim np As New NewTeam
                np.Id = p.Id
                np.teamname = p.teamname
                np.teamemail = p.teamemail
                np.teamphone = p.teamphone
                np.teamleadername = p.teamleadername
                np.teamrosterext = p.teamrosterext
                np.teamroster = p.teamroster
                Return View(np)

            Else

                Return Nothing

            End If

        End Function

        ' GET: Newteam/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Newteam/Create
        <HttpPost()>
        Function Create(ByVal p As NewTeam, ByVal uploadedroster As HttpPostedFileBase) As ActionResult

            Dim np As New BlogNewTeam

            Dim rosterdata As Byte() = Nothing
            Dim fileext As String = ""
            If uploadedroster IsNot Nothing Then
                If uploadedroster.ContentLength > 0 Then

                    Dim target As New MemoryStream()
                    uploadedroster.InputStream.CopyTo(target)
                    rosterdata = target.ToArray()

                    fileext = System.IO.Path.GetExtension(uploadedroster.FileName).Replace(".", "")
                End If
            End If


            Try

                If ModelState.IsValid Then

                    Try

                        np.teamname = p.teamname
                        np.teamemail = p.teamemail
                        np.teamphone = p.teamphone
                        np.teamleadername = p.teamleadername
                        If Not rosterdata Is Nothing Then
                            np.teamroster = rosterdata
                            np.teamrosterext = fileext
                        End If
                        np.CreatedBy = User.Identity.Name
                        np.CreationDate = Now()
                        np.EditBy = User.Identity.Name
                        np.EditDate = Now()
                        pdb.BlogNewTeam.Add(np)
                        pdb.SaveChanges()

                        Return RedirectToAction("Details", "Newteam", New With {.id = np.Id})

                    Catch ex As Exception
                        ModelState.AddModelError("error_msg", ex.Message)
                        Return View(p)
                    End Try


                Else
                    ModelState.AddModelError("error_msg", "error with model")
                    Return View(p)

                End If

            Catch
                Return View()
            End Try
        End Function


        Function Delete(ByVal id As Integer) As ActionResult

            If id > 0 Then


                Dim p = (From t In pdb.BlogNewTeam
                         Where t.Id = id
                         Select t).First

                Dim np As New NewTeam
                np.Id = p.Id
                np.teamname = p.teamname
                np.teamemail = p.teamemail
                np.teamphone = p.teamphone
                np.teamroster = p.teamroster
                np.teamleadername = p.teamleadername
                np.teamrosterext = p.teamrosterext
                np.createdby = p.CreatedBy
                np.creationdate = p.CreationDate
                np.editby = p.EditBy
                np.editdate = p.EditDate
                Return View(np)

            Else

                Return Nothing

            End If

        End Function

        ' POST: Newteam/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try

                Dim deleteteam = From ps In pdb.BlogNewTeam
                                 Where ps.Id = id
                                 Select ps


                For Each p In deleteteam.ToList

                    pdb.BlogNewTeam.Remove(p)
                    pdb.SaveChanges()

                Next

                Return RedirectToAction("Index", "NewTeam")

            Catch ex As Exception
                Return View()
            End Try
        End Function




        Function GetNewteams() As JsonResult

            Dim q = (From p In pdb.BlogNewTeam
                     Select p.Id, p.teamname, p.CreationDate
                    ).AsEnumerable().[Select](
                    Function(o) New With {.id = o.Id, .name = o.teamname, .date = CDate(o.CreationDate).ToString("dd/MM/yyyy")}).ToList

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
End Namespace