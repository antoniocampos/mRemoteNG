﻿using mRemoteNG.App;

using System;
using System.Runtime.Versioning;

namespace mRemoteNG.Messages.MessageWriters
{
    [SupportedOSPlatform("windows")]
    public class TextLogMessageWriter : IMessageWriter
    {
        private readonly Logger _logger;

        public TextLogMessageWriter(Logger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Write(IMessage message)
        {
            switch (message.Class)
            {
                case MessageClass.InformationMsg:
                    _logger.Log.Info(message.Text);
                    break;
                case MessageClass.DebugMsg:
                    _logger.Log.Debug(message.Text);
                    break;
                case MessageClass.WarningMsg:
                    _logger.Log.Warn(message.Text);
                    break;
                case MessageClass.ErrorMsg:
                    _logger.Log.Error(message.Text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}