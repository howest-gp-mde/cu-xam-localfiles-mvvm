using FreshMvvm;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.ViewModels
{
    
    public class MementoViewModel : FreshBasePageModel
    {
        private string mementoValue;

        public string MementoValue
        {
            get { return mementoValue; }
            set
            {
                mementoValue = value;
                RaisePropertyChanged(nameof(MementoValue));
            }
        }

        public ICommand ClearMementoCommand => new Command(
            () => {
                MementoValue = null;
            }
        );

        public ICommand LoadMementoCommand => new Command(
            () => {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fullPath = Path.Combine(folder, Constants.MementoFileName);
                if(File.Exists(fullPath))
                    MementoValue = File.ReadAllText(fullPath);
            }
        );

        public ICommand SaveMementoCommand => new Command(
            () => {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fullPath = Path.Combine(folder, Constants.MementoFileName);
                File.WriteAllText(fullPath, MementoValue);
            }
        );
    }
}
