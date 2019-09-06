using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class EmbeddedFileViewModel : FreshBasePageModel
    {
        private string fileContents;

        public string FileContents
        {
            get { return fileContents; }
            set
            {
                fileContents = value;
                RaisePropertyChanged(nameof(FileContents));
            }
        }

        public ICommand ClearContentsCommand => new Command(
            () => {
                FileContents = null;
            }
        );

        public ICommand LoadFileCommand => new Command(
            () => {

            }
        );

    }
}