Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Web.Mvc

Public Class RoleViewModel
    Public Property Id() As String
        Get
            Return m_Id
        End Get
        Set(value As String)
            m_Id = value
        End Set
    End Property
    Private m_Id As String
    <Required(AllowEmptyStrings:=False)> _
    <Display(Name:="RoleName")> _
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = value
        End Set
    End Property
    Private m_Description As String
End Class

Public Class EditUserViewModel
    Public Property Id() As String
        Get
            Return m_Id
        End Get
        Set(value As String)
            m_Id = value
        End Set
    End Property
    Private m_Id As String

    Public Property Company() As Integer
        Get
            Return m_Company
        End Get
        Set(value As Integer)
            m_Company = value
        End Set
    End Property
    Private m_Company As Integer

    <Required(AllowEmptyStrings:=False)> _
    <Display(Name:="Username")> _
    Public Property Username() As String
        Get
            Return m_Username
        End Get
        Set(value As String)
            m_Username = value
        End Set
    End Property
    Private m_Username As String

    <Required(AllowEmptyStrings:=False)> _
    <Display(Name:="Fullname")> _
    Public Property Fullname() As String
        Get
            Return m_Fullname
        End Get
        Set(value As String)
            m_Fullname = value
        End Set
    End Property
    Private m_Fullname As String

   
    <Required(AllowEmptyStrings:=False)> _
    <Display(Name:="Email")> _
    <EmailAddress> _
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = value
        End Set
    End Property
    Private m_Email As String

    
    <Display(Name:="Address")> _
    Public Property Address As String

    <Display(Name:="Perioxi")> _
    Public Property Perioxi As String

    <Display(Name:="Poli")> _
    Public Property Poli As String

    <Display(Name:="Tk")> _
    Public Property Tk As String

    <Display(Name:="Afm")> _
    Public Property Afm As String

    <Display(Name:="Phone")> _
    Public Property Phone As String

    Public Property RolesList() As IEnumerable(Of SelectListItem)
        Get
            Return m_RolesList
        End Get
        Set(value As IEnumerable(Of SelectListItem))
            m_RolesList = value
        End Set
    End Property
    Private m_RolesList As IEnumerable(Of SelectListItem)

    Public Property CompaniesList() As IEnumerable(Of SelectListItem)
        Get
            Return m_CompaniesList
        End Get
        Set(value As IEnumerable(Of SelectListItem))
            m_CompaniesList = value
        End Set
    End Property
    Private m_CompaniesList As IEnumerable(Of SelectListItem)

    Public Property IsLocked() As Integer
        Get
            Return m_IsLocked
        End Get
        Set(value As Integer)
            m_IsLocked = value
        End Set
    End Property
    Private m_IsLocked As Integer

    Public Property IsEnabled() As Integer
        Get
            Return m_IsEnabled
        End Get
        Set(value As Integer)
            m_IsEnabled = value
        End Set
    End Property
    Private m_IsEnabled As Integer

    Public Property _showroles As Boolean
    Public Property _showcompanies As Boolean
    Public Property _showdates As Boolean

End Class
