﻿using mRemoteNG.UI;
using mRemoteNG.UI.Window;

using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace mRemoteNG.Messages.MessageWriters
{
    [SupportedOSPlatform("windows")]
    public class NotificationPanelMessageWriter : IMessageWriter
    {
        private readonly ErrorAndInfoWindow _messageWindow;

        public NotificationPanelMessageWriter(ErrorAndInfoWindow messageWindow)
        {
            _messageWindow = messageWindow ?? throw new ArgumentNullException(nameof(messageWindow));
        }

        public void Write(IMessage message)
        {
            var lvItem = new NotificationMessageListViewItem(message);

            AddToList(lvItem);
        }

        private void AddToList(ListViewItem lvItem)
        {
            if (_messageWindow.lvErrorCollector.InvokeRequired)
            {
                _messageWindow.lvErrorCollector.Invoke((MethodInvoker)(() => AddToList(lvItem)));
            }
            else
            {
                _messageWindow.lvErrorCollector.Items.Insert(0, lvItem);

                if (_messageWindow.lvErrorCollector.Items.Count > 0)
                {
                    _messageWindow.pbError.Visible = true;
                }
            }
        }
    }
}