﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DalApi;



[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}

static class DalConfig
{
    internal class DalImplementation
    {
        internal string? _package;
        internal string? _namespace;
        internal string? _class;
    }
    internal static string? s_dalName;
    internal static Dictionary<string, DalImplementation> s_dalPackages;

    static DalConfig()
    {
        XElement dalConfig = XElement.Load(@"..\xml\dal-config.xml") ?? throw new DalConfigException("dal-config.xml file is not found");
        s_dalName = dalConfig?.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");
        var packages = dalConfig?.Element("dal-packages")?.Elements() ?? throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = (from item in packages
                         let pkg = item.Value
                         let ns = item.Attribute("namespace")?.Value ?? "Dal"
                         let cls = item.Attribute("class")?.Value ?? pkg
                         select new
                         {
                             item.Name,
                             Value = new DalImplementation { _package = pkg, _namespace = ns, _class = cls }
                         }
        ).ToDictionary(p => "" + p.Name, p => p.Value);
    }
}


// סתם כי אני מפחדת למחוק
//static class DalConfig
//{
//    internal static string? s_dalName;
//    internal static Dictionary<string, string> s_dalPackages;

//    static DalConfig()
//    {
//        XElement dalConfig = XElement.Load(@"xml\dal-config.xml")
//            ?? throw new DalConfigException("dal-config.xml file is not found");
//        s_dalName = dalConfig?.Element("dal")?.Value
//            ?? throw new DalConfigException("<dal> element is missing");
//        var packages = dalConfig?.Element("dal-packages")?.Elements()
//            ?? throw new DalConfigException("<dal-packages> element is missing");
//        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
//    }
//}