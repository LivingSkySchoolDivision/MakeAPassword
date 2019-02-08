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
            StringBuilder complexPasswords_alpha = new StringBuilder();
            StringBuilder complexPasswords_special = new StringBuilder();
            StringBuilder complexPasswords_Yubikey_alpha = new StringBuilder();
            StringBuilder complexPasswords_Yubikey_special = new StringBuilder();

            for (int x = 0; x < numPasswordsToGenerateAtOnce; x++)
            {
                wordPasswords_simple.Append(wordRepo.GetRandomPassword(10, false, false, false));
                wordPasswords_simple.Append("<BR>");

                wordPasswords_short.Append(wordRepo.GetRandomPassword(10, true, true, false));
                wordPasswords_short.Append("<BR>");

                wordPasswords_long.Append(wordRepo.GetRandomPassword(16, true, false, true));
                wordPasswords_long.Append("<BR>");
            }

            for (int x = 0; x < (numPasswordsToGenerateAtOnce / 2); x++)
            {
                complexPasswords_alpha.Append(complexRepo.GetRandomPassword(complexPasswordLength, false));
                complexPasswords_alpha.Append("<BR>");

                complexPasswords_special.Append(complexRepo.GetRandomPassword(complexPasswordLength, true));
                complexPasswords_special.Append("<BR>");

                complexPasswords_Yubikey_alpha.Append(complexRepo.GetRandomPassword(yubikeyPasswordLength, false));
                complexPasswords_Yubikey_alpha.Append("<BR>");

                complexPasswords_Yubikey_special.Append(complexRepo.GetRandomPassword(yubikeyPasswordLength, true));
                complexPasswords_Yubikey_special.Append("<BR>");
            }

            lblWordBasedSimple.Text = wordPasswords_simple.ToString();
            lblWordBasedMedium.Text += wordPasswords_short.ToString();
            lblWordBasedLong.Text += wordPasswords_long.ToString();
            lblComplexPasswords.Text = complexPasswords_alpha.ToString();
            lblComplexPasswords.Text += complexPasswords_special.ToString();
            lblYubikeyPasswords_alpha.Text = complexPasswords_Yubikey_alpha.ToString();
            lblYubikeyPasswords_special.Text = complexPasswords_Yubikey_special.ToString();
        }
    }
}