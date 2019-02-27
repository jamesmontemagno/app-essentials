using System;
using Utils;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace AppEssentials.Shared.Pages
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
            BindingContext = this;
		}

        bool rememberMe = false;

        public bool RememberMe
        {
            get => Preferences.Get(nameof(RememberMe), false);
            set
            {
                Preferences.Set(nameof(RememberMe), value);
                if(!value)
                {
                    Preferences.Set(nameof(Username), string.Empty);
                }
                OnPropertyChanged(nameof(RememberMe));
            }
        }

        string username = Preferences.Get(nameof(Username), string.Empty);
        public string Username
        {
            get => username;
            set
            {
                username = value;
                if (RememberMe)
                    Preferences.Set(nameof(Username), value);
                OnPropertyChanged(nameof(RememberMe));
            }
        }


        async void Handle_Clicked(object sender, EventArgs e)
		{

            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("No Intenet", "", "OK");
                return;
            }

			var isValid = true;

			if (string.IsNullOrEmpty(UserNameEntry.Text) || UserNameEntry.Text.Length < 5)
			{
				VisualStateManager.GoToState(UserNameEntry, "Invalid");
				isValid = false;
			}

			if (string.IsNullOrEmpty(PasswordEntry.Text) || PasswordEntry.Text.Length < 5)
			{
				VisualStateManager.GoToState(PasswordEntry, "Invalid");
				isValid = false;
			}

            if (isValid)
            {
                try
                {
                    await SecureStorage.SetAsync("token", PasswordEntry.Text);
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
                //await DisplayAlert("Login Success", "", "Thanks!");
                //await Clipboard.SetTextAsync("1234");
                //await Navigation.PushAsync(new ClipboardPage());
            }
		}
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            InitStates();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            try
            {
                var password = await SecureStorage.GetAsync("token");
                PasswordEntry.Text = password;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                LabelConnection.FadeTo(0).ContinueWith((result) => { });
            }
            else
            {
                LabelConnection.FadeTo(1).ContinueWith((result) => { });
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }



        void InitStates()
        {
            var stateGroup = new VisualStateGroup
            {
                Name = "StrengthStates",
                TargetType = typeof(Label)
            };

            stateGroup.States.Add(CreateState("Blank", "", Color.White));
            stateGroup.States.Add(CreateState("VeryWeak", "\uf023", Color.Red));
            stateGroup.States.Add(CreateState("Weak", "\uf023 \uf023", Color.Orange));
            stateGroup.States.Add(CreateState("Medium", "\uf023 \uf023 \uf023", Color.Yellow));
            stateGroup.States.Add(CreateState("String", "\uf023 \uf023 \uf023 \uf023", Color.Green));
            stateGroup.States.Add(CreateState("VeryStrong", "\uf023 \uf023 \uf023 \uf023 \uf023", Color.Green));

            VisualStateManager.SetVisualStateGroups(this.StrengthIndicator, new VisualStateGroupList { stateGroup });

        }


        void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            var strength = PasswordAdvisor.CheckStrength(e.NewTextValue);
            var strengthName = Enum.GetName(typeof(PasswordScore), strength);
            VisualStateManager.GoToState(this.StrengthIndicator, strengthName);
        }


        string strength;

        public string Strength
        {
            get => strength;
            set
            {
                strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        static VisualState CreateState(string strength, string text, Color color)
        {
            var textSetter = new Setter { Value = text, Property = Label.TextProperty };
            var colorSetter = new Setter { Value = color, Property = Label.TextColorProperty };

            return new VisualState
            {
                Name = strength,
                TargetType = typeof(Label),
                Setters = { textSetter, colorSetter }
            };
        }
    }

}
