using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace XrnCourse.LocalFiles.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        public ICommand OpenEmbeddedFilePageCommand => new Command(
            async () => {
                await CoreMethods.PushPageModel<EmbeddedFileViewModel>(true);
            }
        );

        public ICommand OpenBundledPdfPageCommand => new Command(
            async () => {
                await CoreMethods.PushPageModel<ShowBundledPdfViewModel>(true);
            }
        );

        public ICommand OpenMementoPageCommand => new Command(
            async () => {
                await CoreMethods.PushPageModel<MementoViewModel>(true);
            }
        );

        public ICommand OpenCoffeePageCommand => new Command(
            async () => {
                await CoreMethods.PushPageModel<CoffeeSettingsViewModel>(true);
            }
        );

    }
}
