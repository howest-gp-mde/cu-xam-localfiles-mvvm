using FreshMvvm;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XrnCourse.LocalFiles.Domain;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class CoffeeSettingsViewModel : FreshBasePageModel
    {

        public CoffeeSettings CurrentSettings { get; set; }

        private string coffeeName;
        public string CoffeeName
        {
            get { return coffeeName; }
            set
            {
                coffeeName = value;
                RaisePropertyChanged(nameof(CoffeeName));
            }
        }

        private bool hasSugar;
        public bool HasSugar
        {
            get { return hasSugar; }
            set
            {
                hasSugar = value;
                RaisePropertyChanged(nameof(HasSugar));
            }
        }

        private int milkAmount;
        public int MilkAmount
        {
            get { return milkAmount; }
            set
            {
                milkAmount = value;
                RaisePropertyChanged(nameof(MilkAmount));
            }
        }

        private TimeSpan brewTime;
        public TimeSpan BrewTime
        {
            get { return brewTime; }
            set
            {
                brewTime = value;
                RaisePropertyChanged(nameof(BrewTime));
            }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            string fullPath = Path.Combine(FileSystem.AppDataDirectory, Constants.CoffeeSettingsFileName);
            if (File.Exists(fullPath))
            {
                string jsonText = File.ReadAllText(fullPath);
                try {
                    var savedSettings = JsonConvert.DeserializeObject<CoffeeSettings>(jsonText);
                    this.CoffeeName = savedSettings.CoffeeName;
                    this.HasSugar = savedSettings.HasSugar;
                    this.MilkAmount = savedSettings.MilkAmount;
                    this.BrewTime = savedSettings.BrewTime;
                }
                catch (Exception ex) {
                    Debug.WriteLine($"Error reading settings: {ex.Message}");
                    //todo: log error!
                }
            }
        }


        public ICommand ResetToDefaultsCommand => new Command(
            () => {
                CoffeeName = null;
                HasSugar = false;
                MilkAmount = 0;
                BrewTime = TimeSpan.Zero;
            }
        );

        public ICommand SaveSettingsCommand => new Command(
            () => {
                var settings = new CoffeeSettings
                {
                    CoffeeName = this.CoffeeName,
                    HasSugar = this.HasSugar,
                    MilkAmount = this.milkAmount,
                    BrewTime = this.BrewTime
                };
                
                //object to json string
                string jsonText = JsonConvert.SerializeObject(settings);

                //get appdata dir using Xamaring Essentials
                string folder = FileSystem.AppDataDirectory;
                
                //standard,simple save operation
                string fullPath = Path.Combine(folder, Constants.CoffeeSettingsFileName);
                File.WriteAllText(fullPath, jsonText);
            }
        );
    }
}