Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Skins
Imports DevExpress.XtraBars
Imports DevExpress.ExpressApp
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Controls
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.Win.Templates.ActionContainers

Namespace DisableVisualStylesModule.Win
	Public Class DisableVisualStylesWindowController
		Inherits WindowController
		Public Sub New()
			TargetWindowType = WindowType.Main
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			DisableVisualStyles()
		End Sub
		Protected Overrides Sub OnDeactivated()
			MyBase.OnDeactivated()
			RemoveHandler Application.CustomizeTemplate, AddressOf Application_CustomizeTemplate
		End Sub
		Private Sub Application_CustomizeTemplate(ByVal sender As Object, ByVal e As CustomizeTemplateEventArgs)
			ResolveTemplate(e.Template)
		End Sub
		Protected Overridable Sub DisableVisualStyles()
			If System.Windows.Forms.SystemInformation.TerminalServerSession Then
				AddHandler Application.CustomizeTemplate, AddressOf Application_CustomizeTemplate
				InitGlobalOptions()
			End If
		End Sub
		Protected Overridable Sub InitGlobalOptions()
			Animator.AllowFadeAnimation = False
			SkinManager.DisableFormSkins()
			SkinManager.DisableMdiFormSkins()
			BarAndDockingController.Default.PropertiesBar.MenuAnimationType = AnimationType.None
			BarAndDockingController.Default.PropertiesBar.SubmenuHasShadow = False
			BarAndDockingController.Default.PropertiesBar.AllowLinkLighting = False
			System.Windows.Forms.Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled
		End Sub
		Private Sub ResolveTemplate(ByVal template As IFrameTemplate)
			Dim formTemplate As XtraFormTemplateBase = TryCast(template, XtraFormTemplateBase)
			If formTemplate IsNot Nothing Then
				If formTemplate.FormStyle = RibbonFormStyle.Ribbon Then
					AddHandler formTemplate.RibbonTransformer.Transformed, AddressOf RibbonTransformer_Transformed
				Else
					InitBarOptions(formTemplate.BarManager)
					UserLookAndFeel.Default.SetWindowsXPStyle()
				End If
			End If
		End Sub
		Private Sub RibbonTransformer_Transformed(ByVal sender As Object, ByVal e As EventArgs)
			InitRibbonOptions((CType(sender, ClassicToRibbonTransformer)).Ribbon)
		End Sub
		Protected Overridable Sub InitRibbonOptions(ByVal ribbon As RibbonControl)
			If ribbon IsNot Nothing Then
				ribbon.ItemAnimationLength = 0
				ribbon.GroupAnimationLength = 0
				ribbon.PageAnimationLength = 0
				ribbon.ApplicationButtonAnimationLength = 0
				ribbon.GalleryAnimationLength = 0
				ribbon.TransparentEditors = False
				InitBarOptions(ribbon.Manager)
			End If
		End Sub
		Protected Overridable Sub InitBarOptions(ByVal manager As BarManager)
			If manager IsNot Nothing Then
				manager.AllowItemAnimatedHighlighting = False
			End If
		End Sub
	End Class
End Namespace