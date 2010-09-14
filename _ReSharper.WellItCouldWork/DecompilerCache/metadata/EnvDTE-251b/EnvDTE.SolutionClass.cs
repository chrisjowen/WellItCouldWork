// Type: EnvDTE.SolutionClass
// Assembly: EnvDTE, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\PublicAssemblies\envdte.dll

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EnvDTE
{
    [TypeLibType(2)]
    [Guid("B35CAA8C-77DE-4AB3-8E5A-F038E3FC6056")]
    [ClassInterface(0)]
    [ComImport]
    public class SolutionClass : _Solution, Solution, IEnumerable
    {
        #region _Solution Members

        [DispId(0)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Project _Solution.Item([MarshalAs(UnmanagedType.Struct), In] object index);

        [DispId(-4)]
        [TypeLibFunc(1)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IEnumerator _Solution.GetEnumerator();

        [DispId(14)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void _Solution.SaveAs([MarshalAs(UnmanagedType.BStr), In] string FileName);

        [DispId(15)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Project _Solution.AddFromTemplate([MarshalAs(UnmanagedType.BStr), In] string FileName,
                                          [MarshalAs(UnmanagedType.BStr), In] string Destination,
                                          [MarshalAs(UnmanagedType.BStr), In] string ProjectName,
                                          [In] bool Exclusive = false);

        [DispId(16)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Project _Solution.AddFromFile([MarshalAs(UnmanagedType.BStr), In] string FileName, [In] bool Exclusive = false);

        [DispId(17)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void _Solution.Open([MarshalAs(UnmanagedType.BStr), In] string FileName);

        [DispId(18)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void _Solution.Close([In] bool SaveFirst = false);

        [DispId(25)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void _Solution.Remove([MarshalAs(UnmanagedType.Interface), In] Project proj);

        [DispId(40)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void _Solution.Create([MarshalAs(UnmanagedType.BStr)] string Destination,
                              [MarshalAs(UnmanagedType.BStr)] string Name);

        [DispId(42)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        ProjectItem _Solution.FindProjectItem([MarshalAs(UnmanagedType.BStr)] string FileName);

        [DispId(43)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        string _Solution.ProjectItemsTemplatePath([MarshalAs(UnmanagedType.BStr)] string ProjectKind);

        [DispId(10)]
        DTE _Solution.DTE { [DispId(10)]
        get; }

        [DispId(11)]
        DTE _Solution.Parent { [DispId(11)]
        get; }

        [DispId(12)]
        int _Solution.Count { [DispId(12)]
        get; }

        [DispId(13)]
        string _Solution.FileName { [DispId(13), TypeLibFunc(64)]
        get; }

        [DispId(19)]
        Properties _Solution.Properties { [DispId(19)]
        get; }

        [DispId(22)]
        bool _Solution.IsDirty { [DispId(22), TypeLibFunc(64)]
        get; [TypeLibFunc(64), DispId(22)]
        set; }

        [DispId(26)]
        string _Solution.get_TemplatePath([MarshalAs(UnmanagedType.BStr), In] string ProjectType);

        [DispId(28)]
        string _Solution.FullName { [DispId(28)]
        get; }

        [DispId(29)]
        bool _Solution.Saved { [DispId(29)]
        get; [DispId(29)]
        set; }

        [DispId(31)]
        Globals _Solution.Globals { [DispId(31)]
        get; }

        [DispId(32)]
        AddIns _Solution.AddIns { [DispId(32)]
        get; }

        [TypeLibFunc(1024)]
        [DispId(33)]
        object _Solution.get_Extender([MarshalAs(UnmanagedType.BStr), In] string ExtenderName);

        [DispId(34)]
        object _Solution.ExtenderNames { [TypeLibFunc(1024), DispId(34)]
        get; }

        [DispId(35)]
        string _Solution.ExtenderCATID { [DispId(35), TypeLibFunc(1024)]
        get; }

        [DispId(36)]
        bool _Solution.IsOpen { [DispId(36)]
        get; }

        [DispId(38)]
        SolutionBuild _Solution.SolutionBuild { [DispId(38)]
        get; }

        [DispId(41)]
        Projects _Solution.Projects { [DispId(41)]
        get; }

        #endregion
    }
}
