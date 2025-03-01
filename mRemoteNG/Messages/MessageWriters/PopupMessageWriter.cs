﻿using mRemoteNG.Resources.Language;

using System;
using System.Windows.Forms;

namespace mRemoteNG.Messages.MessageWriters
{
    public class PopupMessageWriter : IMessageWriter
    {
        public void Write(IMessage message)
        {
            switch (message.Class)
            {
                case MessageClass.DebugMsg:
                    MessageBox.Show(message.Text, string.Format(Language.TitleInformation, message.Date),
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageClass.InformationMsg:
                    MessageBox.Show(message.Text, string.Format(Language.TitleInformation, message.Date),
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageClass.WarningMsg:
                    MessageBox.Show(message.Text, string.Format(Language.TitleWarning, message.Date),
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case MessageClass.ErrorMsg:
                    MessageBox.Show(message.Text, string.Format(Language.TitleError, message.Date),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}