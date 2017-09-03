Imports System.Net.Mail
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports System.Threading.Tasks
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class Utils


    Private pdb As New AtlasBlogEntities
    Private pdb2 As New AtlasStatisticsEntities



    Public Sub resizepostimages()

        Dim teamsfolder As String = HttpContext.Current.Server.MapPath("~/resizedimages/")
        Dim teamsfolderResized As String = HttpContext.Current.Server.MapPath("~/resizedimages/resized/")

        Dim exists As Boolean = System.IO.Directory.Exists(teamsfolder)
        If Not exists Then
            Directory.CreateDirectory(teamsfolder)
        End If
        exists = System.IO.Directory.Exists(teamsfolderResized)
        If Not exists Then
            Directory.CreateDirectory(teamsfolderResized)
        End If

        Dim db As New AtlasBlogEntities

        Dim teams = From s In db.BlogPostsTable
                    Where s.PostPhoto IsNot Nothing
                    Select s.Id, s.PostPhoto

        For Each t In teams.ToList

            Dim imageStr As String = teamsfolder & t.Id & ".png"
            Dim imageStr1 As String = teamsfolderResized & "mediumsize_" & t.Id & ".png"
            Dim imageStr2 As String = teamsfolderResized & "smallsize_" & t.Id & ".png"

            If Not t.PostPhoto Is Nothing Then
                Dim imageInBytes As Byte() = t.PostPhoto


                Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                    Using image1 As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                        If (System.IO.File.Exists(imageStr)) Then System.IO.File.Delete(imageStr)
                        image1.Save(imageStr)
                    End Using
                End Using
                imageInBytes = Nothing

                Using original As Image = Image.FromFile(imageStr)
                    Using mediumresize As Image = ResizeImage(original, New Size(160, 160))
                        mediumresize.Save(imageStr1) ', ImageFormat.Jpeg)
                    End Using

                    Using smallsize As Image = ResizeImage(original, New Size(30, 30))
                        smallsize.Save(imageStr2) ', ImageFormat.Jpeg)
                    End Using
                End Using

                Dim mData As Byte()
                Using br As BinaryReader = New BinaryReader(System.IO.File.OpenRead(imageStr1))
                    mData = br.ReadBytes(br.BaseStream.Length)
                End Using

                Dim sData As Byte()
                Using br2 As BinaryReader = New BinaryReader(System.IO.File.OpenRead(imageStr2))
                    sData = br2.ReadBytes(br2.BaseStream.Length)
                End Using


                Dim editpost = db.BlogPostsTable.Find(t.Id)
                editpost.PostPhoto160_160 = mData
                editpost.PostPhoto30_30 = sData


                db.SaveChanges()

                mData = Nothing
                sData = Nothing


                If (System.IO.File.Exists(imageStr)) Then System.IO.File.Delete(imageStr)
                If (System.IO.File.Exists(imageStr1)) Then System.IO.File.Delete(imageStr1)
                If (System.IO.File.Exists(imageStr2)) Then System.IO.File.Delete(imageStr2)


            End If


        Next



    End Sub



    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                        percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Public Async Function sendEmailsync(ByVal useremailaddress As String,
                                        ByVal subject As String,
                                         ByVal body As String,
                                         ByVal copytome As Boolean) As Task


        Dim fromAddress = New MailAddress("atlassupport@atlasbasket.gr", "Support @ atlas basket")

        Dim smtp = New SmtpClient() With {
             .Host = "mail.yourideas.gr",
            .Port = 25,
            .DeliveryMethod = SmtpDeliveryMethod.Network,
            .UseDefaultCredentials = False,
            .Credentials = New NetworkCredential("admin@yourideas.gr", "aayi2004!")
        }

        Dim message As New MailMessage()
        message.From = fromAddress
        If copytome Then
            message.CC.Add(useremailaddress)
        End If
        message.Subject = subject
        message.Body = body
        message.IsBodyHtml = True
        message.To.Add(useremailaddress)
        Try

            Await smtp.SendMailAsync(message)

        Catch ex As Exception

        End Try


    End Function



    Public Async Function sendContactformEmailAsync(ByVal fromuser As String,
                                                    ByVal fromemail As String,
                                    ByVal subject As String,
                                        ByVal body As String,
                                        ByVal copytome As Boolean) As Task

        Try
            Dim fromAddress = New MailAddress(fromemail, fromuser)

            Dim smtp = New SmtpClient() With {
             .Host = "mail.yourideas.gr",
            .Port = 25,
            .DeliveryMethod = SmtpDeliveryMethod.Network,
            .UseDefaultCredentials = False,
            .Credentials = New NetworkCredential("admin@yourideas.gr", "aayi2004!")
        }

            Dim message As New MailMessage()




            message.From = fromAddress
            If copytome Then
                message.CC.Add(fromemail)
            End If
            message.Subject = subject
            message.Body = body
            message.IsBodyHtml = True
            message.To.Add("ATLASBASKETBALLTEAM@GMAIL.COM")

            Await smtp.SendMailAsync(message)

        Catch ex As Exception

        End Try


    End Function


    <Compress>
    Public Function GetSimplePosts(ByVal nCount As Integer, ByVal AtlasKathgoria As Integer?, ByVal k As Integer?, ByVal k2 As Integer?) As List(Of Object)

        If AtlasKathgoria Is Nothing Then AtlasKathgoria = 0
        If k Is Nothing Then k = 3 'Teleutaia nea!
        If k2 Is Nothing Then k2 = 11 'Teleutaia nea omilou!


        If AtlasKathgoria = 0 Then

            Dim q = (From p In pdb.BlogPostsTable
                     Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                     Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                     Where p.Activepost = True And (p1.KathgoriaId = k And p1.IsKathgoria = True)
                     Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, KatName = p2.KathgoriaName).Take(nCount).
                            AsEnumerable().[Select](
                            Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .KatName = o.KatName}).ToList

            Return q.Cast(Of Object).ToList

            'Dim dtm As New DataTableModel
            'If q IsNot Nothing Then
            '    dtm.data = q.Cast(Of Object).ToList
            'End If
            'dtm.draw = 0
            'dtm.recordsTotal = dtm.data.Count
            'dtm.recordsFiltered = dtm.recordsTotal

            'Return Json(dtm, JsonRequestBehavior.AllowGet)

        Else

            Dim kl = (From o In pdb2.KathgoriesTable
                      Where o.Id = AtlasKathgoria
                      Select o.Id).ToList

            Dim q = (From p In pdb.BlogPostsTable
                     Join p1 In pdb.BlogPostandKathgoriaTable On p1.PostId Equals p.Id
                     Join p2 In pdb.BlogKathgoriesTable On p2.Id Equals p1.KathgoriaId
                     Join klist In kl On klist Equals p1.AtlasKathgoriaId
                     Where p.Activepost = True And (p1.KathgoriaId = k2 And p1.IsAtlasKathgoria = True)
                     Select Id = p.Id, PostTitle = p.PostTitle, PostSummary = p.PostSummary, KatName = p2.KathgoriaName).Take(nCount).
                            AsEnumerable().[Select](
                            Function(o) New With {.Id = o.Id, .PostTitle = o.PostTitle, .PostSummary = o.PostSummary, .KatName = o.KatName}).ToList

            'Dim dtm As New DataTableModel
            'If q IsNot Nothing Then
            '    dtm.data = q.Cast(Of Object).ToList
            'End If
            'dtm.draw = 0
            'dtm.recordsTotal = dtm.data.Count
            'dtm.recordsFiltered = dtm.recordsTotal

            'Return json(dtm, JsonRequestBehavior.AllowGet)

            Return q.Cast(Of Object).ToList

        End If

    End Function


    <Compress>
    Public Function Getdiorganwseis() As List(Of Object)

        Dim kat = (From d In pdb2.DiorganwshTable
                   Join s In pdb2.SeasonTable On s.Id Equals d.Seasonid
                   Where s.ActiveSeason = True
                   Order By d.DiorganwshName
                   Select d.DiorganwshName, d.Id).ToList

        Return kat.Cast(Of Object).ToList

        'Return Json(kat, JsonRequestBehavior.AllowGet)


    End Function


End Class
