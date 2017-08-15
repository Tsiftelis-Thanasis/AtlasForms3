Imports System.IO
Imports System.Data.Entity
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Web.Script.Serialization

Public Class NewTeam

    <Key()>
    <Display(Name:="Id#")>
    Public Property Id As Integer

    <Required()>
    <StringLength(200)>
    <Display(Name:="Ονομα")>
    Public Property teamname As String

    <StringLength(100)>
    <Display(Name:="Email αρχηγού")>
    Public Property teamemail As String

    <Required()>
    <StringLength(50)>
    <Display(Name:="Τηλέφωνο αρχηγού")>
    Public Property teamphone As String

    <Display(Name:="Roster")>
    Public Property teamroster As Byte()


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