using System;
using System.Collections.Generic;
using System.Text;

namespace Me.AppPass.ServiceInterface
{
    public interface IPlugin
    {
        /// <summary>
        /// Plugin name for info only
        /// </summary>
        string PluginName { get; }
        /// <summary>
        /// Used by UcHost parent to pass it's handle
        /// </summary>
        /// <param name="hostHandle"></param>
        void SetHostHandleToBaseUserControl(IHost hostHandle);

    }
}
