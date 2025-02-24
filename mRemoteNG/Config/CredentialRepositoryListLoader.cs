﻿using mRemoteNG.Config.DataProviders;
using mRemoteNG.Config.Serializers.CredentialProviderSerializer;
using mRemoteNG.Credential;

using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace mRemoteNG.Config
{
    public class CredentialRepositoryListLoader : ILoader<IEnumerable<ICredentialRepository>>
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly CredentialRepositoryListDeserializer _deserializer;

        public CredentialRepositoryListLoader(IDataProvider<string> dataProvider, CredentialRepositoryListDeserializer deserializer)
        {
            if (dataProvider == null)
                throw new ArgumentNullException(nameof(dataProvider));
            if (deserializer == null)
                throw new ArgumentNullException(nameof(deserializer));

            _dataProvider = dataProvider;
            _deserializer = deserializer;
        }

        [SupportedOSPlatform("windows")]
        public IEnumerable<ICredentialRepository> Load()
        {
            var data = _dataProvider.Load();
            return _deserializer.Deserialize(data);
        }
    }
}