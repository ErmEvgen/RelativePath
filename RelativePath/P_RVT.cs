using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using System.IO;
using Autodesk.Revit.UI.Events;
using System.Runtime.CompilerServices;


namespace RelativePath
{
    public class P_RVT
    {

        List<String> allRVTFiles = new List<string>() { };

        public P_RVT(UIApplication UIApp) 
        {
            //TaskDialog.Show("323", "fsdfsdfs");
            var ggg = new Form1();
            ggg.ShowDialog();
            allRVTFiles.Add(ggg.resPath);

            foreach (var loadFilePath in allRVTFiles)
            {
                var mPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(loadFilePath);
                var data = TransmissionData.ReadTransmissionData(mPath);
                var file_ref_id = data.GetAllExternalFileReferenceIds();
                foreach (var id in file_ref_id)
                {
                    var file_ref = data.GetLastSavedReferenceData(id);
                    if (file_ref.ExternalFileReferenceType == ExternalFileReferenceType.RevitLink)
                    {
                        var fPath = ModelPathUtils.ConvertModelPathToUserVisiblePath(file_ref.GetPath());
                        var newPath = fPath.Replace("\\", "/").Split('/').Last();
                        data.SetDesiredReferenceData(id, ModelPathUtils.ConvertUserVisiblePathToModelPath(newPath), PathType.Relative, true);
                    }
                }

                data.IsTransmitted = true;
                TransmissionData.WriteTransmissionData(mPath, data);
            }
        }
    }
}