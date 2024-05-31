using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using Autodesk.Revit.DB.Events;
using static System.Net.Mime.MediaTypeNames;


namespace RelativePath
{
    public class App : IExternalApplication
    {
        ExternalEvent m_Event;
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        public Result OnStartup(UIControlledApplication application)
        {


            m_Event = ExternalEvent.Create(new ExternalEventBatchProcessing());
            application.ControlledApplication.ApplicationInitialized += ControlledApplication_ApplicationInitialized;
            return Result.Succeeded;
        }

        private void ControlledApplication_ApplicationInitialized(object sender, ApplicationInitializedEventArgs e)
        {
            m_Event.Raise();
        }
    }

    public class ExternalEventBatchProcessing : IExternalEventHandler
    {
        public void Execute(UIApplication uiapp)
        {
            string[] f = Environment.GetCommandLineArgs();  


            if (f.Contains("/RelativePath"))
            {
                new P_RVT(uiapp);
            }
        }

        public string GetName()
        {
            return "External Event BatchProcessing";
        }
    }

}
