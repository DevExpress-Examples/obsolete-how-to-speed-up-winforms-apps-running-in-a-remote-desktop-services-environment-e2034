Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win.SystemModule

Namespace DisableVisualStylesModule.Win
	Public NotInheritable Class DisableVisualStylesModuleWindowsFormsModule
		Inherits ModuleBase
		Public Sub New()
			RequiredModuleTypes.Add(GetType(SystemWindowsFormsModule))
		End Sub
	End Class
End Namespace