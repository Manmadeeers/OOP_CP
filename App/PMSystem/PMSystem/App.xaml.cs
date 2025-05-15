using DAL;
using System.Windows;

namespace PMSystem
{

    public partial class App : Application
    {
        public static Context DatContext { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DatContext = new Context();
            DatContext.Database.EnsureCreated();

        }
        protected override void OnExit(ExitEventArgs e)
        {
            DatContext.Dispose();
            base.OnExit(e);

        }
        public void ChangeLanguage(string lang)
        {
            var dictUri = new Uri($"Resources/lang.{lang}.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;

            var oldDict = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang."));
            if (oldDict != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
            }

            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }

}
