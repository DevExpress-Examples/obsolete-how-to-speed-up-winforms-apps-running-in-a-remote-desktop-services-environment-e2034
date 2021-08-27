<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128615359/13.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2034)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[DisableVisualStylesWindowController.cs](./CS/DisableVisualStylesModule.Win/DisableVisualStylesWindowController.cs) (VB: [DisableVisualStylesWindowController.vb](./VB/DisableVisualStylesModule.Win/DisableVisualStylesWindowController.vb))**
<!-- default file list end -->
# How to speed up WinForms apps, running in a Remote Desktop Services environment


<p>To achieve this goal, you can disable visual styles, skins, animations, and set various controls options. Note that here we additionally disable visual effects of two most "expensive" controls: RibbonControl and BarManager, which provide bars, docking functionality, context menus, alert windows and a Ribbon interface for your .NET WinForms applications. The attached example shows how to do this by an example of an XAF Windows Forms application. If you do not use XAF, then you can obtain the necessary code from this example, and put it in the entry point of your application (usually it's the Main method).</p>
<p><strong>IMPORTANT NOTE</strong><br /> 1. You can greatly reduce memory consumption if you use the BarManager instead of RibbonControl on your forms. For example, an XAF Windows Forms application with BarManager consumes half as much memory than the same application using the RibbonControl. In XAF you can switch between the standard bars and ribbon menu using the FormStyle property of the Options node in the Model Editor.<br /> 2. To avoid painting problems when using the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument2642"><u>RibbonForm</u></a> and RibbonControl on Vista or Windows 7 with the Aero theme enabled, don't set the <a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.application.visualstylestate.aspx"><u>System.Windows.Forms.Application.VisualStyleState property</u></a> to VisualStyleState.NoneEnabled. Alternatively, you can set the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraBarsRibbonRibbonForm_AllowFormGlasstopic"><u>RibbonForm.AllowFormGlass</u></a> property to false. This is because we use the VisualStyleRenderer to draw text on transparent headers.</p>
<p><strong>See Also:</strong><br /> <a href="https://community.devexpress.com/blogs/winforms/archive/2018/07/12/winforms-tips-amp-tricks-boosting-application-performance.aspx">WinForms Tips & Tricks - Boosting Application Performance</a><br /> <a href="https://www.devexpress.com/Support/Center/p/S33335">Add a new static property to the XtraAnimator class which will allow a developer to disable animation in all DevExpress controls</a><br /> <a href="http://support.microsoft.com/kb/186628"><u>Performance Tuning CPU Use for 16 and 32-bit Windows Applications</u></a><br /> <a href="http://www.techrepublic.com/article/build-your-skills-how-to-optimize-apps-to-run-in-terminal-services/"><u>Build Your Skills: How to optimize apps to run in Terminal Services</u></a><br /> <a href="http://www.techrepublic.com/article/solutionbase-tuning-applications-for-the-terminal-services/"><u>Tuning applications for the Terminal Services</u></a><br /> <a href="http://www.microsoft.com/whdc/system/sysperf/Perf_tun_srv.mspx"><u>Performance Tuning Guidelines for Windows Server 2008</u></a></p>

<br/>


