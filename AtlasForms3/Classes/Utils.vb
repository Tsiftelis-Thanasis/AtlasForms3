Imports System.Net.Mail
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports System.Threading.Tasks
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class Utils


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



    Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
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

    Public Async Function sendEmailsync(ByVal usernameto As String,
                                        ByVal subject As String,
                                         ByVal body As String) As Task


        Dim fromAddress = New MailAddress("atlassupport@atlasbasket.gr", "Support @ atlas basket")

        Dim smtp = New SmtpClient() With {
             .Host = "mail.atlasstatistics.gr",
            .Port = 465,
            .DeliveryMethod = SmtpDeliveryMethod.Network,
            .EnableSsl = True,
            .UseDefaultCredentials = False,
            .Credentials = New NetworkCredential("atlassupport@atlasstatistics.gr", "rAv84*8c")
        }

        Dim message As New MailMessage()
            message.From = fromAddress
            message.Subject = subject
            message.Body = body
        message.To.Add(usernameto)

        Try


            Await smtp.SendMailAsync(message)

        Catch ex As Exception

        End Try


    End Function

End Class
