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
using System.Xml.Linq;

namespace RelativePath
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RVT_Unload : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            return Execute(uiapp);
        }
        public Result Execute(UIApplication uiapp)
        {

            //string[] f = Environment.GetCommandLineArgs();

            //var ттт = f.Contains("/RelativePath");

            new P_RVT(uiapp);
            return Result.Succeeded;
        }

    }
}
