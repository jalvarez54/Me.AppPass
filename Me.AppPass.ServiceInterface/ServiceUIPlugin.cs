using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Me.AppPass.ServiceInterface
{
    public class ServiceUIPlugin
    {

        public struct PluginPresent
        {
            public string PathAssembly;
            public string ClassName;
        }

        public static PluginPresent[] GetPlugins(string pathDlls, string piInterface)
        {
            ArrayList listPlugins = new ArrayList();
            string[] listeDlls = null;
            int index = 0;
            Assembly dllAssembly = default(Assembly);

            // Get all dlls.
            listeDlls = Directory.GetFileSystemEntries(pathDlls, "*.dll");
            for (index = 0; index <= listeDlls.Length - 1; index++)
            {
                try
                {
                    dllAssembly = Assembly.LoadFrom(listeDlls[index]);
                    ServiceUIPlugin.ExamineAssembly(dllAssembly, piInterface, listPlugins);
                }
                catch (Exception)
                {
                    // Nothing to do.
                }
            }

            // Return all plugins found.
            PluginPresent[] listePluginPresents = new PluginPresent[listPlugins.Count];

            if (listPlugins.Count != 0)
            {
                listPlugins.CopyTo(listePluginPresents);
                return listePluginPresents;
            }
            else {
                return null;
            }

        }

        private static void ExamineAssembly(Assembly dllAssembly, string piInterface, ArrayList plugins)
        {
            Type typeInterface;
            PluginPresent plugin = default(PluginPresent);

            foreach (Type item in dllAssembly.GetTypes())
            {
                // Public types only
                if (item.IsPublic == true)
                {
                    // Ignore abstract class.
                    if (!((item.Attributes & TypeAttributes.Abstract) == TypeAttributes.Abstract))
                    {
                        // Is our Interface implemented ?
                        typeInterface = item.GetInterface(piInterface, true);

                        // If Not (typeInterface Is Nothing) 
                        if ((typeInterface != null))
                        {
                            // Yes he implement.
                            plugin = new PluginPresent();
                            plugin.PathAssembly = dllAssembly.Location;
                            plugin.ClassName = item.FullName;
                            // Add plugin to the ArrayList plugins list
                            plugins.Add(plugin);
                        }

                    }
                }
            }

        }

        public static object CreatePluginInstance(PluginPresent plugin)
        {
            Assembly dllAssembly = default(Assembly);
            object objPlugin = null;

            try
            {
                dllAssembly = Assembly.LoadFrom(plugin.PathAssembly);

                objPlugin = dllAssembly.CreateInstance(plugin.ClassName);
            }
            catch (Exception)
            {
                return null;
            }

            return objPlugin;

        }

    }
}
