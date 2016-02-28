using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Me.AppPass.ServiceInterface;
using System.IO;
using Me.Utils;

namespace Me.AppPass.UI
{
    /// <summary>
    /// User control hosting hardware user control (RFID, USB...)
    /// Load plugin selected by the user in the comboBoxAuthenticationProvider.
    /// Implement IHost in order to plugin can access some UcHost local controls.
    /// </summary>
    public partial class UcHost : UserControl, IHost
    {
        public UcHost()
        {

            InitializeComponent();

            this.toolStripStatusLabelHost.Text = "Welcome";

        }

        /// <summary>
        /// Plugin interface type name
        /// </summary>
        private const string INTERFACE_PLUGIN_NAME = "Me.AppPass.ServiceInterface.IPlugin";
        /// <summary>
        /// Base usercontrol type name
        /// </summary>
        private const string USER_CONTROL_CLASS_BASE_NAME = "Me.AppPass.UI.Base.UcBase";
        /// <summary>
        /// Folder containing plugins
        /// </summary>
        private const string DLL_FOLDER_NAME = @"\Plugins";
        /// <summary>
        /// Control actually loaded
        /// </summary>
        private Control controlLoaded = null;
        /// <summary>
        /// Plugins list
        /// </summary>
        private ServiceUIPlugin.PluginPresent[] plugins;
        /// <summary>
        /// Current plugin selected in the combobox
        /// </summary>
        private string currentSelectionPluginValue = string.Empty;

        /// <summary>
        /// When UcHost is loaded retrieve plugins by calling GetPlugins()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcHost_Load(object sender, EventArgs e)
        {
            try
            {
                this.GetPlugins();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Call this.LoadSelectedPlugin to laod the selected plugin user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonValidateAuthentication_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabelHost.Text = "Welcome";

            // Remove actual control loaded
            if (this.controlLoaded != null)
            {
                this.controlLoaded.Dispose();
                this.controlLoaded = null;
            }

            // Load selected plugin
            if (this.comboBoxAuthenticationProvider.SelectedIndex > -1)
            {
                try
                {
                    this.LoadSelectedPlugin(this.currentSelectionPluginValue);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select an hardware authentification provider",Application.ProductName, MessageBoxButtons.OK,  MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Store in this.currentSelectionPluginValue the item selected value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAuthenticationProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxAuthenticationProvider = (ComboBox)sender;
            ComboBoxAuthenticationProviderItem itemSelected = (ComboBoxAuthenticationProviderItem)comboBoxAuthenticationProvider.SelectedItem;

            this.currentSelectionPluginValue = itemSelected.Value.ToString();
        }

        #region IHost implementation

        string IHost.AuthenticationProvider
        {
            get
            {
                return this.comboBoxAuthenticationProvider.SelectedItem.ToString();
            }

        }

        /// <summary>
        /// Child plugin can read and write on toolStripStatusLabelHost control using this property
        /// </summary>
        string IHost.StatusMessage
        {
            get
            {
                return this.toolStripStatusLabelHost.Text;
            }

            set
            {
                this.toolStripStatusLabelHost.Text = value;
            }
        }

        #endregion

        /// <summary>
        /// Class used by GetPlugins() to fill ComboBox authentication provider
        /// with Displayname and Value
        /// </summary>
        internal class ComboBoxAuthenticationProviderItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        /// <summary>
        /// Get plugins and fill comboBoxAuthenticationProvider
        /// </summary>
        private void GetPlugins()
        {

            // retrieve plugins  list
            try
            {
                plugins = ServiceUIPlugin.GetPlugins(Path.GetDirectoryName(Application.ExecutablePath) + DLL_FOLDER_NAME, INTERFACE_PLUGIN_NAME);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (plugins == null)
            {
                MessageBox.Show("No plugin found !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Fill comboBoxAuthenticationProvider ignore UcBase
            foreach (var plugin in plugins)
            {
                if (plugin.ClassName != USER_CONTROL_CLASS_BASE_NAME)
                {
                    ComboBoxAuthenticationProviderItem comboBoxItem = new ComboBoxAuthenticationProviderItem();
                    // Use item 3 as display value: example RFID for Me.AppPass.UI.RFID.UcRFID
                    comboBoxItem.Text = plugin.ClassName.Split('.')[3];
                    // Value is uc type: example Me.AppPass.UI.RFID.UcRFID
                    comboBoxItem.Value = plugin.ClassName;
                    this.comboBoxAuthenticationProvider.Items.Add(comboBoxItem);
                }
            }

        }

        /// <summary>
        /// Load className plugin call SetHostHandleToBaseUserControl with UcHost handle
        /// as parameter and add the plugin control in groupBoxChild GroupBox
        /// </summary>
        /// <param name="className"></param>
        private void LoadSelectedPlugin(string className)
        {


            IPlugin plugin = default(IPlugin);

            // Create className plugin instance and load it
            for (int index = 0; index <= plugins.Length - 1; index++)
            {
                if (plugins[index].ClassName == className)
                {

                    plugin = (IPlugin)ServiceUIPlugin.CreatePluginInstance(plugins[index]);

                    // Pass UcHost handle to the uc, now uc can use UcHost properties and methods
                    plugin.SetHostHandleToBaseUserControl(this);

                    // Cache the uc loaded and dock it
                    this.controlLoaded = (Control)plugin;
                    this.controlLoaded.Dock = DockStyle.Fill;

                    // Init some UcHost properties
                    this.groupBoxChild.Text = plugin.PluginName;
                    // Add plugin controlLoaded in the groupBoxChild
                    this.groupBoxChild.Controls.Add(this.controlLoaded);
                }
            }

        }



    }
}
