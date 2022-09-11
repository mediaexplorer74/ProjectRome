using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;
using Windows.Storage;
using System.Threading.Tasks;

namespace ProjectRomeRemote
{
    public static class PrivilegeHelper
    {
        internal static bool IsRunAsAdmin()
        {
            var Principle = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return Principle.IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static bool Elevate()
        {
            var SelfProc = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Assembly.GetExecutingAssembly().Location,
                Verb = "runas"
            };
            try
            {
                Process.Start(SelfProc);
                return true;
            }
            catch
            {
                Debug.WriteLine("Unable to elevate!");
                return false;
            }
        }
    }
}

