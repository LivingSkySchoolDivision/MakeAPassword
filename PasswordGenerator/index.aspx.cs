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
        private int numPasswordsToGenerateAtOnce = 10;
        private int complexPasswordLength = 63;
        private int yubikeyPasswordLength = 32;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString.AllKeys.Contains("forcereload")) || (Request.QueryString.AllKeys.Contains("dbreload")))
            {
                wordRepo = new WordRepository();
                complexRepo = new ComplexPasswordRepository();
            }

            StringBuilder wordPasswords_simple = new StringBuilder();
            StringBuilder wordPasswords_short = new StringBuilder();
            StringBuilder wordPasswords_long = new StringBuilder();
            StringBuilder complexPasswords = new StringBuilder();
            StringBuilder complexPasswords_Yubikey = new StringBuilder();

            for (int x = 0; x < numPasswordsToGenerateAtOnce; x++)
            {
                wordPasswords_long.Append(wordRepo.GetRandomPassword(16, true, false));
                wordPasswords_long.Append("<BR>");

                wordPasswords_short.Append(wordRepo.GetRandomPassword(10, true, true));
                wordPasswords_short.Append("<BR>");

                wordPasswords_simple.Append(wordRepo.GetRandomPassword(10, false, false));
                wordPasswords_simple.Append("<BR>");

                complexPasswords.Append(complexRepo.GetRandomPassword(complexPasswordLength));
                complexPasswords.Append("<BR>");

                complexPasswords_Yubikey.Append(complexRepo.GetRandomPassword(yubikeyPasswordLength));
                complexPasswords_Yubikey.Append("<BR>");
            }

            lblWordBasedSimple.Text = wordPasswords_simple.ToString();
            lblWordBasedMedium.Text += wordPasswords_short.ToString();
            lblWordBasedLong.Text += wordPasswords_long.ToString();            
            lblComplexPasswords.Text = complexPasswords.ToString();
            lblYubikeyPasswords.Text = complexPasswords_Yubikey.ToString();
        }
    }
}