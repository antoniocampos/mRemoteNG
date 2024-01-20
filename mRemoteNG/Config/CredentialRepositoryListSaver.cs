using mRemoteNG.Config.DataProviders;
using mRemoteNG.Config.Serializers.CredentialProviderSerializer;
using mRemoteNG.Credential;

using System;
using System.Collections.Generic;

namespace mRemoteNG.Config
{
    public class CredentialRepositoryListSaver : ISaver<IEnumerable<ICredentialRepository>>
    {
        private readonly IDataProvider<string> _dataProvider;

        public CredentialRepositoryListSaver(IDataProvider<string> dataProvider)
        {
            if (dataProvider == null)
                throw new ArgumentNullException(nameof(dataProvider));

            _dataProvider = dataProvider;
        }

        public void Save(IEnumerable<ICredentialRepository> repositories, string propertyNameTrigger = "")
        {
            var serializer = new CredentialRepositoryListSerializer();
            var data = serializer.Serialize(repositories);
            _dataProvider.Save(data);
        }
    }
}