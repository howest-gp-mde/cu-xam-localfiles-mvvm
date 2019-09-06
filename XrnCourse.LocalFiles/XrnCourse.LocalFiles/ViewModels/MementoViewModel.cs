using FreshMvvm;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.ViewModels
{
    
    public class MementoViewModel : FreshBasePageModel
    {

        public MementoViewModel()
        {
        }

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

            }
        );

        public ICommand SaveMementoCommand => new Command(
            () => {

            }
        );
    }
}
