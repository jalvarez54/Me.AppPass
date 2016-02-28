using Me.AppPass.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Me.AppPass.DAL
{
    public class AppSettings : DALValidation
    {
        public override void DeleteToken(string username)
        {
            // if token exist delete token
            try
            {
                // Get the configuration file.
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings.AllKeys.Contains(username))
                {
                    // Delete an entry from appSettings.
                    config.AppSettings.Settings.Remove(username);
                    // Save the configuration file.
                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of the changed section.
                    ConfigurationManager.RefreshSection("appSettings");

                }
                else
                {
                    throw new Exception("Key already not exist");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override void CreateToken(string username, string id)
        {
            // if token not exist create token
            try
            {
                // Get the configuration file.
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (!config.AppSettings.Settings.AllKeys.Contains(username))
                {
                    // Add an entry to appSettings.
                    config.AppSettings.Settings.Add(username, id);
                    // Save the configuration file.
                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of the changed section.
                    ConfigurationManager.RefreshSection("appSettings");

                }
                else
                {
                    throw new Exception("Key already exist");
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
        public override void DecryptTokens()
        {
            // Get the configuration file.
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            try
            {
                // Get the section.
                ConfigurationSection section = config.GetSection("appSettings");

                // Unprotect (decrypt) the section.
                config.AppSettings.SectionInformation.UnprotectSection();
                // Save the configuration file.
                config.AppSettings.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of the changed section.
                ConfigurationManager.RefreshSection("appSettings");

            }
            catch (Exception)
            {
                throw;
            }
        }
        public override void EncryptTokens()
        {
            // Get the configuration file.
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            try
            {
                // Get the section.
                ConfigurationSection section = config.GetSection("appSettings");

                // Protect (encrypt) the section.
                config.AppSettings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                // Save the configuration file.
                config.AppSettings.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of the changed section.
                ConfigurationManager.RefreshSection("appSettings");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<Token> GetTokens()
        {
            List<Token> tokens = new List<Token>();

            var appSettingKeys = ConfigurationManager.AppSettings.AllKeys;
            var appSettings = ConfigurationManager.AppSettings;

            for (int i = 0; i < appSettings.Count - 1; i++)
            {
                if (appSettingKeys[i] != "DalAssemblyName" & appSettingKeys[i] != "DalType")
                {
                    tokens.Add(new Token() { UserName = appSettingKeys[i], ID = appSettings[i] });
                }
            }
            return tokens;
        }

        /// <summary>
        /// Return null is token not found in the store
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override Token GetTokenByName(string username)
        {
            Token token = null;
            // if username exist return token
            // else throw exception token not exist
            return token;
        }

        /// <summary>
        /// Return null is token not found in the store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Token GetTokenByID(string id)
        {
            Token token = null;
            // if id exist return token
            // else throw exception token not exist
            return token;
        }

    }
}
