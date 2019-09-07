using FreshMvvm;
using System.IO;
using System.Reflection;
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
                var assembly = typeof(EmbeddedFileViewModel).GetTypeInfo().Assembly;
                Stream stream =
                    assembly.GetManifestResourceStream("XrnCourse.LocalFiles.EmbeddedFiles.translations.txt");
                using (var reader = new StreamReader(stream))
                {
                    FileContents = reader.ReadToEnd();
                }
            }
        );


    }
}