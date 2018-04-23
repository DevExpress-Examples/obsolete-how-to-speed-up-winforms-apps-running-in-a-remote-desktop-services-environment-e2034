using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.SystemModule;

namespace DisableVisualStylesModule.Win {
    public sealed class DisableVisualStylesModuleWindowsFormsModule : ModuleBase {
        public DisableVisualStylesModuleWindowsFormsModule() {
            RequiredModuleTypes.Add(typeof(SystemWindowsFormsModule));
        }
    }
}