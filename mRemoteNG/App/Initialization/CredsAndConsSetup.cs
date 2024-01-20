using mRemoteNG.Config.Connections;

using System.IO;
using System.Runtime.Versioning;

namespace mRemoteNG.App.Initialization
{
    [SupportedOSPlatform("windows")]
    public class CredsAndConsSetup
    {
        public void LoadCredsAndCons()
        {
            new SaveConnectionsOnEdit(Runtime.ConnectionsService);

            if (Properties.App.Default.FirstStart && !Properties.OptionsBackupPage.Default.LoadConsFromCustomLocation && !File.Exists(Runtime.ConnectionsService.GetStartupConnectionFileName()))
                Runtime.ConnectionsService.NewConnectionsFile(Runtime.ConnectionsService.GetStartupConnectionFileName());

            Runtime.LoadConnections();
        }
    }
}