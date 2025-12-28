using System.ComponentModel.Composition;
using System.Reflection; // <--- REQUIRED for the AssemblyCompany attribute
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

// ---------------------------------------------------------------------------------------
// THIS LINE FIXES THE "GetCompany" CRASH
// XrmToolBox reads this to identify who made the tool.
// ---------------------------------------------------------------------------------------
[assembly: AssemblyCompany("Teja Tech")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace RandomDataUpdater
{
    // XrmToolBox Metadata
    [Export(typeof(IXrmToolBoxPlugin))]
    [ExportMetadata("Name", "Random Data Updater")]
    [ExportMetadata("Description", "Updates records with random data")]
    [ExportMetadata("Company", "Teja Tech")]
    [ExportMetadata("Version", "1.0.0.0")]
    [ExportMetadata("SmallImageBase64", null)]
    [ExportMetadata("BigImageBase64", null)]
    [ExportMetadata("BackgroundColor", "Lavender")]
    [ExportMetadata("PrimaryFontColor", "#000000")]
    [ExportMetadata("SecondaryFontColor", "Gray")]
    public class Plugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new RandomDataUpdaterControl();
        }
    }
}