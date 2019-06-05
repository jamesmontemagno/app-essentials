using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEssentials.Shared.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileSystemPage : ContentPage
    {
        public FileSystemPage()
        {
            InitializeComponent();

            localPath = Path.Combine(FileSystem.CacheDirectory, localFileName);
        }

        const string templateFileName = "FileSystemTemplate.txt";

        const string localFileName = "TheFile.txt";

        string localPath; 

        private async void ButtonTemplate_Clicked(object sender, EventArgs e)
        {

            using (var stream = await FileSystem.OpenAppPackageFileAsync(templateFileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    LabelOutput.Text = await reader.ReadToEndAsync();
                }
            }
            
        }
        
        private void Load(object sender, EventArgs e)
        {
            CurrentContents.Text = File.ReadAllText(localPath);
        }

        private void Save(object sender, EventArgs e)
        {
            File.WriteAllText(localPath, CurrentContents.Text);
        }
    }
}