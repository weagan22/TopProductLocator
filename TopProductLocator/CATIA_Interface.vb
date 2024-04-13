Module CATIA_Interface
    Function GetCATIA() As Boolean
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


        If countTest = 0 Then
            MsgBox("CATIA is not running.", MessageBoxIcon.Warning, "Error")
            Return False
        End If


        'Get CATIA object
        Try
            MainForm.CATIA = GetObject(, "CATIA.application")
        Catch
            Return False
        End Try

        Return True
    End Function
End Module
