using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Utils.Triggers
{
    public class AgeTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            int result;
            bool isValid = int.TryParse(sender.Text, out result);

            if (isValid)
            {
                if (result >= 18)
                {
                    sender.BackgroundColor = Colors.Green;
                }
                else
                {
                    sender.BackgroundColor = Colors.Red;
                }
            }
            else
            {
                sender.BackgroundColor = Colors.PowderBlue;
            }
        }
    }
}
