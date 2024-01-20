using mRemoteNG.Connection.Protocol;

using System;
using System.Linq;

namespace mRemoteNG.Tools.Attributes
{
    public class AttributeUsedInAllProtocolsExcept : AttributeUsedInProtocol
    {
        public AttributeUsedInAllProtocolsExcept(params ProtocolType[] exceptions)
            : base(Enum
                .GetValues(typeof(ProtocolType))
                .Cast<ProtocolType>()
                .Except(exceptions)
                .ToArray())
        {
        }
    }
}
