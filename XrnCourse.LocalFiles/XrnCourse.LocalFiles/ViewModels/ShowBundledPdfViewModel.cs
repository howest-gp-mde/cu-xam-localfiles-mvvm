using FreshMvvm;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class ShowBundledPdfViewModel : FreshBasePageModel
    {

        private Stream pdfDocumentStream;

        public Stream PdfDocumentStream
        {
            get { return pdfDocumentStream; }
            set
            {
                pdfDocumentStream = value;
                RaisePropertyChanged();
            }
        }

        private string pdfSize;

        public string PdfSize
        {
            get { return pdfSize; }
            set
            {
                pdfSize = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoadFileCommand => new Command(
            () => {
                
            }
        );
    }
}
