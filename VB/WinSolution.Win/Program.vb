Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports DevExpress.ExpressApp.Security

Namespace WinSolution.Win
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
#If EASYTEST Then
            DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
            Dim winApplication As New WinSolutionWindowsFormsApplication()
#If EASYTEST Then
            If ConfigurationManager.ConnectionStrings("EasyTestConnectionString") IsNot Nothing Then
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings("EasyTestConnectionString").ConnectionString
            End If
#End If
            winApplication.ConnectionString = DevExpress.ExpressApp.Xpo.InMemoryDataStoreProvider.ConnectionString
            If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            End If
            Try
                winApplication.Setup()
                winApplication.Start()
            Catch e As Exception
                winApplication.HandleException(e)
            End Try
        End Sub
    End Class
End Namespace
