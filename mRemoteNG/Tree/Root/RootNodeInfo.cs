﻿using mRemoteNG.Container;
using mRemoteNG.Resources.Language;
using mRemoteNG.Tools;

using System;
using System.ComponentModel;
using System.Runtime.Versioning;

namespace mRemoteNG.Tree.Root
{
    [SupportedOSPlatform("windows")]
    [DefaultProperty("Name")]
    public class RootNodeInfo : ContainerInfo
    {
        private string _name;
        private string _customPassword = "";

        public RootNodeInfo(RootNodeType rootType, string uniqueId)
            : base(uniqueId)
        {
            _name = Language.Connections;
            Type = rootType;
        }

        public RootNodeInfo(RootNodeType rootType)
            : this(rootType, Guid.NewGuid().ToString())
        {
        }

        #region Public Properties

        [LocalizedAttributes.LocalizedCategory(nameof(Language.Miscellaneous)),
         Browsable(true),
         LocalizedAttributes.LocalizedDefaultValue(nameof(Language.Connections)),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.Name)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionName))]
        public override string Name
        {
            get => _name;
            set => _name = value;
        }
        
        [LocalizedAttributes.LocalizedCategory(nameof(Language.Miscellaneous)),
         Browsable(true),
         LocalizedAttributes.LocalizedDisplayName(nameof(Language.PasswordProtect)),
         LocalizedAttributes.LocalizedDescription(nameof(Language.PropertyDescriptionPasswordProtect)),
         TypeConverter(typeof(MiscTools.YesNoTypeConverter))]
        public new bool Password { get; set; }

        [Browsable(false)]
        public string PasswordString
        {
            get => Password ? _customPassword : DefaultPassword;
            set
            {
                _customPassword = value;
                Password = !string.IsNullOrEmpty(value) && _customPassword != DefaultPassword;
            }
        }

        [Browsable(false)] public string DefaultPassword { get; } = "mR3m"; //TODO move password away from code to settings

        [Browsable(false)] public RootNodeType Type { get; set; }

        public override TreeNodeType GetTreeNodeType()
        {
            return Type == RootNodeType.Connection
                ? TreeNodeType.Root
                : TreeNodeType.PuttyRoot;
        }

        #endregion
    }
}