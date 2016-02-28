using System;
using System.Collections.Generic;
using System.Text;

namespace Me.AppPass.ServiceInterface
{
    public interface IHost
    {
        /// <summary>
        /// Hardware authentication provider: USB, RFID...
        /// </summary>
        string AuthenticationProvider { get; }
        /// <summary>
        /// StatusStrip control must be acceded by childs usercontrols
        /// </summary>
        string StatusMessage { get; set; }

    }
}
