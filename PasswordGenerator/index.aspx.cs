using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordGenerator
{
    public partial class index : System.Web.UI.Page
    {
        private static WordRepository wordRepo = new WordRepository();
        private int numPasswordsToGenerateAtOnce = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString.AllKeys.Contains("forcereload")) || (Request.QueryString.AllKeys.Contains("dbreload")))
            {
                wordRepo = new WordRepository();
            }

            StringBuilder passwords = new StringBuilder();
            
            for(int x = 0; x < numPasswordsToGenerateAtOnce; x++)
            {
                passwords.Append(wordRepo.GetRandomPassword());
                passwords.Append("<BR>");
            }

            // Remove the last <BR>
            //passwords.Remove(passwords.Length - 4, 4);

            lblPassword.Text = passwords.ToString();
        }
    }
}