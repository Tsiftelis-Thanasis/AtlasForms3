Imports System.IO
Imports System.Data.Entity
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Web.Script.Serialization

Public Class NewPlayer

    <Key()>
    <Display(Name:="Id#")>
    Public Property Id As Integer

    <Required()>
    <StringLength(200)>
    <Display(Name:="Ονοματεπώνυμο")>
    Public Property playername As String

    <StringLength(100)>
    <Display(Name:="Email")>
    Public Property playeremail As String

    <Required()>
    <StringLength(50)>
    <Display(Name:="Τηλέφωνο")>
    Public Property playerphone As String

    <StringLength(50)>
    <Display(Name:="Ημερομηνία γέννησης")>
    Public Property playerbirthdate As String

    <StringLength(10)>
    <Display(Name:="Ύψος")>
    Public Property playerheight As String

    <StringLength(10)>
    <Display(Name:="Θέση")>
    Public Property playerposition As String


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