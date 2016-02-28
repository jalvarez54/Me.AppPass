using Me.AppPass.Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Me.AppPass.DAL
{
    public abstract class DALValidation
    {

        public abstract void DeleteToken(string username);
        public abstract void CreateToken(string username, string id);
        public abstract void DecryptTokens();
        public abstract void EncryptTokens();
        public abstract List<Token> GetTokens();
        public abstract Token GetTokenByName(string username);
        public abstract Token GetTokenByID(string id);

        /// <summary>
        /// DAL fabric method
        /// </summary>
        /// <param name="dalAssemblyName"></param>
        /// <param name="dalType"></param>
        /// <returns></returns>
        public static DALValidation MakeDalValidation(string dalAssemblyName, string dalType)
        {
            string typeName = string.Format("{0}.{1}", dalAssemblyName, dalType);

            object dalValidation = null;
            Assembly dalAssembly = null;

            try
            {
                dalAssembly = Assembly.Load(dalAssemblyName);
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                dalValidation = dalAssembly.CreateInstance(typeName);
            }
            catch (Exception)
            {
                throw;
            }

            if (dalValidation == null) throw new ApplicationException(string.Format("DAL type: {0} not implemented", typeName));

            return (DALValidation)dalValidation;

        }

    }
}
