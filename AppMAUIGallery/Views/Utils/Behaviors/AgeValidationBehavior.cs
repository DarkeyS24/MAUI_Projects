using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Utils.NovaPasta
{
    class AgeValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            int age;
            if(int.TryParse(e.NewTextValue, out age))
            {
                if(age >= 18)
                {
                    ((Entry)sender).TextColor = Colors.Green;
                }
                else
                {
                    ((Entry)sender).TextColor = Colors.Red;
                }
            }
            else
            {
                ((Entry)sender).TextColor = Colors.Yellow;
            }
        }
    }
}
