Imports System.Web.Mvc



Namespace Controllers
    <Compress>
    Public Class NewPlayerController
        Inherits Controller

        Private pdb As New AtlasBlogEntities


        ' GET: NewPlayer
        <Authorize(Roles:="Admins")>
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: NewPlayer/Details/5
        Function Details(ByVal id As Integer) As ActionResult

            If id > 0 Then


                Dim p = (From t In pdb.BlogNewPlayer
                         Where t.Id = id
                         Select t).First

                Dim np As New NewPlayer
                np.Id = p.Id
                np.playername = p.playername
                np.playeremail = p.playeremail
                np.playerphone = p.playerphone
                np.playerbirthdate = p.playerbirthdate
                np.playerheight = p.playerheight
                np.playerposition = p.playerposition
                Return View(np)

            Else

                Return Nothing

            End If

        End Function

        ' GET: NewPlayer/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: NewPlayer/Create
        <HttpPost()>
        Function Create(ByVal p As NewPlayer) As ActionResult

            Dim np As New BlogNewPlayer

            Try

                If ModelState.IsValid Then

                    Try

                        np.playername = p.playername
                        np.playeremail = p.playeremail
                        np.playerphone = p.playerphone
                        np.playerbirthdate = p.playerbirthdate
                        np.playerheight = p.playerheight
                        np.playerposition = p.playerposition
                        np.CreatedBy = User.Identity.Name
                        np.CreationDate = Now()
                        np.EditBy = User.Identity.Name
                        np.EditDate = Now()
                        pdb.BlogNewPlayer.Add(np)
                        pdb.SaveChanges()

                        Return RedirectToAction("Details", "NewPlayer", New With {.id = np.Id})

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


        ' GET: NewPlayer/Delete/5
        <Authorize(Roles:="Admins")>
        Function Delete(ByVal id As Integer) As ActionResult

            If id > 0 Then


                Dim p = (From t In pdb.BlogNewPlayer
                         Where t.Id = id
                         Select t).First

                Dim np As New NewPlayer
                np.Id = p.Id
                np.playername = p.playername
                np.playeremail = p.playeremail
                np.playerphone = p.playerphone
                np.playerbirthdate = p.playerbirthdate
                np.playerheight = p.playerheight
                np.playerposition = p.playerposition
                np.createdby = p.CreatedBy
                np.creationdate = p.CreationDate
                np.editby = p.EditBy
                np.editdate = p.EditDate
                Return View(np)

            Else

                Return Nothing

            End If

        End Function


        ' POST: NewPlayer/Delete/5
        <Authorize(Roles:="Admins")>
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try

                Dim deleteplayer = From ps In pdb.BlogNewPlayer
                                   Where ps.Id = id
                                   Select ps


                For Each p In deleteplayer.ToList

                    pdb.BlogNewPlayer.Remove(p)
                    pdb.SaveChanges()

                Next

                Return RedirectToAction("Index", "NewPlayer")

            Catch ex As Exception
                Return View()
            End Try
        End Function


        Function GetNewPlayers() As JsonResult

            Dim q = (From p In pdb.BlogNewPlayer
                     Select p.Id, p.playername, p.CreationDate
                    ).AsEnumerable().[Select](
                    Function(o) New With {.id = o.Id, .name = o.playername, .date = CDate(o.CreationDate).ToString("dd/MM/yyyy")}).ToList

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