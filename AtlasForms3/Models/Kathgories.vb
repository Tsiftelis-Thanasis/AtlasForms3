Imports System.IO
Imports System.Data.Entity
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Web.Script.Serialization

Public Class Kathgories

    <Key()>
    <Display(Name:="Id#")>
    Public Property Id As Integer

    <Required()>
    <StringLength(50)>
    <Display(Name:="Κατηγορία")>
    Public Property kathgorianame As String

    <Required()>
    <Display(Name:="Ενεργή/Μή ενεργή")>
    Public Property ActiveKathgoria As Boolean

    <Display(Name:="Δημιουργία απο")>
    Public Property createdby As String
    <Display(Name:="Ημ/νια δημιουργίας")>
    Public Property creationdate As Date
    <Display(Name:="Αλλαγή απο")>
    Public Property editby As String
    <Display(Name:="Ημ/νια αλλαγής")>
    Public Property editdate As Date


    Public Sub New()
    End Sub

End Class