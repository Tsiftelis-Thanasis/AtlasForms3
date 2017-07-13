Public Class DataTableModel

    Public Property draw As Integer
    Public Property recordsTotal As Integer
    Public Property recordsFiltered As Integer
    Public Property data As New List(Of Object)
    'Public Property aaDicData() As New Dictionary(Of String, Double)

End Class

Public Class QueryResult
    Public Property DT_RowId As String
    Public Property chk As Integer
End Class