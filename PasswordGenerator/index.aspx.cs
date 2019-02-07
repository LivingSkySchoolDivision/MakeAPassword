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
        private static ComplexPasswordRepository complexRepo = new ComplexPasswordRepository();
        private int numPasswordsToGenerateAtOnce = 5;
        private int complexPasswordLength = 63;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString.AllKeys.Contains("forcereload")) || (Request.QueryString.AllKeys.Contains("dbreload")))
            {
                wordRepo = new WordRepository();
                complexRepo = new ComplexPasswordRepository();
            }

            StringBuilder wordPasswords_short = new StringBuilder();
            StringBuilder wordPasswords_long = new StringBuilder();
            StringBuilder complexPasswords = new StringBuilder();
            
            for(int x = 0; x < numPasswordsToGenerateAtOnce; x++)
            {
                wordPasswords_long.Append(wordRepo.GetRandomPassword(16));
                wordPasswords_long.Append("<BR>");

                wordPasswords_short.Append(wordRepo.GetRandomPassword(10));
                wordPasswords_short.Append("<BR>");

                complexPasswords.Append(complexRepo.GetRandomPassword(complexPasswordLength));
                complexPasswords.Append("<BR>");                
            }

            lblPassword.Text = wordPasswords_short.ToString();
            lblPassword.Text += wordPasswords_long.ToString();
            lblComplexPasswords.Text = complexPasswords.ToString();
        }
    }
}