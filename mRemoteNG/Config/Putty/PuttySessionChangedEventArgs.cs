using mRemoteNG.Connection;

using System;


namespace mRemoteNG.Config.Putty
{
    public class PuttySessionChangedEventArgs : EventArgs
    {
        public PuttySessionInfo Session { get; set; }

        public PuttySessionChangedEventArgs(PuttySessionInfo sessionChanged = null)
        {
            Session = sessionChanged;
        }
    }
}