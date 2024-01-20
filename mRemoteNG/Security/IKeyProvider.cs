using mRemoteNG.Tools;

using System.Security;

namespace mRemoteNG.Security
{
    public interface IKeyProvider
    {
        Optional<SecureString> GetKey();
    }
}