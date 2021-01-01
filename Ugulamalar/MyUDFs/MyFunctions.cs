using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;
//excel de fgerekebilir

namespace MyUDFs
{
    [Guid("3ADF6501-4D91-4B40-A374-23946CE29E6D")] //Bu GUID sizde farklı olacak
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MyFunctions
    {
        public double Topla(double number1, double number2)
        {
            return number1+number2;
        }

        public double Katla(double number1, double number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Burdan itibaren registry ayarları için
        /// </summary>
        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type type)
        {
            Registry.ClassesRoot.CreateSubKey(GetSubKeyName(type, "Programmable"));
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(GetSubKeyName(type, "InprocServer32"), true);
            key.SetValue("", System.Environment.SystemDirectory + @"\mscoree.dll", RegistryValueKind.String);
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(Type type)
        {
            Registry.ClassesRoot.DeleteSubKey(GetSubKeyName(type, "Programmable"), false);
        }

        private static string GetSubKeyName(Type type, string subKeyName)

        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append(@"CLSID\{");
            s.Append(type.GUID.ToString().ToUpper());
            s.Append(@"}\");
            s.Append(subKeyName);
            return s.ToString();
        }

        public void Register()
        {
            RegisterFunction(typeof(MyFunctions));
        }

    }
}
