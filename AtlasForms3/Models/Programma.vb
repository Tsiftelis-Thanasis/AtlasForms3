Imports System.IO
Imports System.Data.Entity
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Web.Script.Serialization

Public Class Programma

    <Key()>
    <Display(Name:="Id#")>
    Public Property Id As Integer

    <Required()>
    <StringLength(50)>
    <Display(Name:="Omada a")>
    Public Property OmadaA As String

    <Required()>
    <StringLength(50)>
    <Display(Name:="Omada b")>
    Public Property OmadaB As String

    <Required()>
    <Display(Name:="gamedate")>
    Public Property gamedate As Date?

    <Display(Name:="Omilos")>
    Public Property Omilosid As Integer

    <Display(Name:="Gipedo")>
    Public Property Gipedoid As Integer


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