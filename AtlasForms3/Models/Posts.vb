Imports System.IO
Imports System.Data.Entity
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Web.Script.Serialization


Public Class Posts

    <Key()>
    <Display(Name:="Id#")>
    Public Property Id As Integer

    <Required()>
    <Display(Name:="Ενεργό/Μή ενεργό")>
    Public Property Activepost As Boolean

    <Required()>
    <StringLength(100)>
    <Display(Name:="Τίτλος")>
    Public Property PostTitle As String

    <StringLength(2000)>
    <Display(Name:="Περίληψη")>
    Public Property PostSummary As String

    <AllowHtml()>
    <Display(Name:="Κείμενο")>
    Public Property PostBody As String

    <Display(Name:="Φωτογραφία ")>
    Public Property PostPhoto As Byte()

    <Display(Name:="Βίντεο")>
    Public Property Youtubelink As String

    <Display(Name:="Στατιστικά")>
    Public Property Statslink As String

    <Display(Name:="Δημιουργία απο")>
    Public Property createdby As String

    <Display(Name:="Ημ/νια δημιουργίας")>
    Public Property creationdate As DateTime
    <Display(Name:="Αλλαγή απο")>
    Public Property editby As String

    <Display(Name:="Ημ/νια αλλαγής")>
    Public Property editdate As DateTime



    Public Sub New()

    End Sub

End Class