
Imports System.IO.Compression

Public Class CompressAttribute
    Inherits ActionFilterAttribute
    Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)

        Dim encodingsAccepted = filterContext.HttpContext.Request.Headers("Accept-Encoding")
        If String.IsNullOrEmpty(encodingsAccepted) Then
            Return
        End If

        encodingsAccepted = encodingsAccepted.ToLowerInvariant()
        Dim response = filterContext.HttpContext.Response

        If encodingsAccepted.Contains("deflate") Then
            response.AppendHeader("Content-encoding", "deflate")
            response.Filter = New DeflateStream(response.Filter, CompressionMode.Compress)
        ElseIf encodingsAccepted.Contains("gzip") Then
            response.AppendHeader("Content-encoding", "gzip")
            response.Filter = New GZipStream(response.Filter, CompressionMode.Compress)
        End If
    End Sub
End Class
