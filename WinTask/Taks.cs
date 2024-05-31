using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;

namespace WinTask
{
    public class WinTask
    {
        public Dictionary<string, Microsoft.Win32.TaskScheduler.Task> TaskDict = new Dictionary<string, Microsoft.Win32.TaskScheduler.Task>();
        string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string ProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        readonly string ProgramFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

        public static string T_RelativePath = "RelativePath";
        public WinTask()

        {
            TaskService ts = new TaskService();

            string Args;
            var td_Type = ts.NewTask();
            td_Type.RegistrationInfo.Description = T_RelativePath;
            td_Type.Settings.MultipleInstances = TaskInstancesPolicy.Parallel;
            Args = $"/{T_RelativePath}";
            td_Type.Actions.Add(new ExecAction($@"{ProgramFilesPath}\Autodesk\Revit 2021\Revit.exe", $"/language RUS {Args}"));
            var new_Task = ts.RootFolder.RegisterTaskDefinition(T_RelativePath, td_Type);
            new_Task.Run();
        }

    }
}
