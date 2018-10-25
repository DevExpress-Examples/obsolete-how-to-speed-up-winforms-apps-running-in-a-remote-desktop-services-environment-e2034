using System;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.ExpressApp;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Controls;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;

namespace DisableVisualStylesModule.Win {
    public class DisableVisualStylesWindowController : WindowController {
        public DisableVisualStylesWindowController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            DisableVisualStyles();
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            Application.CustomizeTemplate -= Application_CustomizeTemplate;
        }
        private void Application_CustomizeTemplate(object sender, CustomizeTemplateEventArgs e) {
            ResolveTemplate(e.Template);
        }
        protected virtual void DisableVisualStyles() {
            if(System.Windows.Forms.SystemInformation.TerminalServerSession) {
                Application.CustomizeTemplate += Application_CustomizeTemplate;
                InitGlobalOptions();
            }
        }
        protected virtual void InitGlobalOptions() {
            Animator.AllowFadeAnimation = false;
            SkinManager.DisableFormSkins();
            SkinManager.DisableMdiFormSkins();
            BarAndDockingController.Default.PropertiesBar.MenuAnimationType = AnimationType.None;
            BarAndDockingController.Default.PropertiesBar.SubmenuHasShadow = false;
            BarAndDockingController.Default.PropertiesBar.AllowLinkLighting = false;
            System.Windows.Forms.Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
        }
        private void ResolveTemplate(IFrameTemplate template) {
            XtraFormTemplateBase formTemplate = template as XtraFormTemplateBase;
            if(formTemplate != null) {
                if(formTemplate.FormStyle == RibbonFormStyle.Ribbon) {
                    formTemplate.RibbonTransformer.Transformed += RibbonTransformer_Transformed;
                }
                else {
                    InitBarOptions(formTemplate.BarManager);
                    UserLookAndFeel.Default.SetWindowsXPStyle();
                }
            }
        }
        private void RibbonTransformer_Transformed(object sender, EventArgs e) {
            InitRibbonOptions(((ClassicToRibbonTransformer)sender).Ribbon);
        }
        protected virtual void InitRibbonOptions(RibbonControl ribbon) {
            if(ribbon != null) {
                ribbon.ItemAnimationLength = 0;
                ribbon.GroupAnimationLength = 0;
                ribbon.PageAnimationLength = 0;
                ribbon.ApplicationButtonAnimationLength = 0;
                ribbon.GalleryAnimationLength = 0;
                ribbon.TransparentEditors = false;
                InitBarOptions(ribbon.Manager);
            }
        }
        protected virtual void InitBarOptions(BarManager manager) {
            if(manager != null) {
                manager.AllowItemAnimatedHighlighting = false;
            }
        }
    }
}