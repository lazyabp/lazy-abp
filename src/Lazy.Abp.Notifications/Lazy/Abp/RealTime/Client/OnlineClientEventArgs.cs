﻿using System;

namespace Lazy.Abp.RealTime.Client
{
    public class OnlineClientEventArgs : EventArgs
    {
        public IOnlineClient Client { get; }

        public OnlineClientEventArgs(IOnlineClient client)
        {
            Client = client;
        }
    }
}
