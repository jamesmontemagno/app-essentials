using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEssentials.Shared.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SharePage : ContentPage
	{
		public SharePage ()
		{
			InitializeComponent ();
		}

        private void ButtonShare_Clicked(object sender, EventArgs e)
        {

        }
    }
}