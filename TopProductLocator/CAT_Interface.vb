Imports INFITF

Module CAT_Interface
    Public Property CATIA As Application = Nothing

    Function GetCATIA() As Boolean

        If CAT_InstanceCount() = 0 Then
            MsgBox("CATIA is not running.", MessageBoxIcon.Warning, "Error")
            Return False
        End If

        'Get CATIA object
        Try
            CATIA = GetObject(, "CATIA.application")
        Catch
            Return False
        End Try

        Return True
    End Function

    Function CAT_InstanceCount() As Integer
        Dim countTest As Integer = 0

        For Each p As Process In Process.GetProcesses()
            If p.ProcessName = "CNEXT" Then
                If countTest = 1 Then
                    MsgBox("More than one instance of CATIA is running please make sure only one instance is running prior to running this macro",, "Error")
                    Return False
                End If
                countTest = 1
            End If
        Next

        Return countTest
    End Function
End Module
