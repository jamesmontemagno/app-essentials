using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEssentials.Shared.Pages
{
    public partial class ContactPickerPage : ContentPage
    {
        public ContactPickerPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var contact = await Contacts.PickContactAsync();
                if (contact == null)
                    return;

                var info = new StringBuilder();
                info.AppendLine(contact.Id);
                info.AppendLine(contact.NamePrefix);
                info.AppendLine(contact.GivenName);
                info.AppendLine(contact.MiddleName);
                info.AppendLine(contact.FamilyName);
                info.AppendLine(contact.NameSuffix);
                info.AppendLine(contact.DisplayName);
                info.AppendLine(contact.Phones.FirstOrDefault()?.PhoneNumber ?? string.Empty);
                info.AppendLine(contact.Emails.FirstOrDefault()?.EmailAddress ?? string.Empty);

                LabelInfo.Text = info.ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}