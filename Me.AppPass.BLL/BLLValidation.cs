using Me.AppPass.Common;
using Me.AppPass.DAL;
using System;

namespace Me.AppPass.BLL
{

    /// <summary>
    /// Business layer
    /// </summary>
    public class BLLValidation
    {

        public BLLValidation()
        {

        }

        /// <summary>
        /// Create an DAL instance
        /// </summary>
        /// <param name="dalAssemblyName"></param>
        /// <param name="dalType"></param>
        public BLLValidation(string dalAssemblyName, string dalType)
        {

            try
            {
                this.dalValidation = DALValidation.MakeDalValidation(dalAssemblyName, dalType);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// DAL instance
        /// </summary>
        private DALValidation dalValidation;

        /// <summary>
        /// Retreive all tokens search if token is in the list if so return the same token with IsValid to true
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Token IsTokenValid(Token token)
        {
            var tokens = this.dalValidation.GetTokens();

            if (tokens != null)
            {
                if (tokens.Exists(item => item.UserName == token.UserName & item.ID == token.ID))
                {
                        token.IsValid = true;
                }
            }

            return token;
        }

        /// <summary>
        /// Delete token request, no particular business
        /// </summary>
        /// <param name="username"></param>
        public void DeleteToken(string username)
        {
            try
            {
                this.dalValidation.DeleteToken(username);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create token request, no particular business
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"></param>
        public void CreateToken(string username, string id)
        {

            try
            {
                this.dalValidation.CreateToken(username, id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Decrypt tokens request, no particular business
        /// </summary>
        public void DecryptTokens()
        {

            try
            {
                this.dalValidation.DecryptTokens();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Encrypt tokens request, no particular business
        /// </summary>
        public void EncryptTokens()
        {

            try
            {
                this.dalValidation.EncryptTokens();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
