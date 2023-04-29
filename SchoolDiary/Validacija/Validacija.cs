using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDiary.Validacija
{
    public class Validacija
    {
        public static bool ValidirajKontrolu(Control kontrola, ErrorProvider err, string kljuc)
        {
            var valid = true;
            if (kontrola is TextBox && string.IsNullOrWhiteSpace(kontrola.Text))
                valid = false;
            else if (kontrola is ComboBox && (kontrola as ComboBox).SelectedIndex < 0)
                valid = false;
            else if (kontrola is PictureBox && (kontrola as PictureBox).Image == null)
                valid = false;

            if (!valid)
                err.SetError(kontrola, "Obavezno polje!");
            else
                err.Clear();
            return valid;
        }
    }
}
