using Me.AppPass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.AppPass.DAL
{
    public class MSAccess : DALValidation
    {
        public override void DeleteToken(string username)
        {
            // if token exist delete token
            // else throw exception token not exist
        }
        public override void CreateToken(string username, string id)
        {
            // if token not exist create token
            // else throw exception token already exist
        }
        public override void DecryptTokens()
        {
            // if decryption not ok throw exception
        }
        public override void EncryptTokens()
        {
            // if encryption not ok throw exception
        }

        public override List<Token> GetTokens()
        {
            List<Token> tokens = new List<Token>();

            // if retrieve tokens return dictionnary
            // else throw exception

            return tokens;
        }


        public override Token GetTokenByName(string username)
        {
            Token token = null;
            // if username exist return token
            // else throw exception token not exist
            return token;
        }

        public override Token GetTokenByID(string id)
        {
            Token token = null;
            // if id exist return token
            // else throw exception token not exist
            return token;
        }

    }
}
