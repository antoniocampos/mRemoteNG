#region

using mRemoteNG.Connection;

using System;

#endregion

namespace mRemoteNG.Config.Serializers.ConnectionSerializers.Csv.RemoteDesktopManager;

public partial class CsvConnectionsDeserializerRdmFormat : ISerializer<ConnectionInfo, string>
{
    public string Serialize(ConnectionInfo model)
    {
        throw new NotImplementedException();
    }

    public Version Version { get; }
}