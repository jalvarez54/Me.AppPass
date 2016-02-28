using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Me.AppPass.Common
{
    public class Token
    {
        private string userName;
        private string iD;
        private bool isValid;

        /// <summary>
        /// Secret
        /// </summary>
        public string ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        /// <summary>
        /// Write by business layer only
        /// </summary>
        public bool IsValid
        {
            get
            {
                return isValid;
            }

            set
            {
                isValid = value;
            }
        }

        /// <summary>
        /// Used as key
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }
    }
}
