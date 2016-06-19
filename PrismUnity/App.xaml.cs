using System;
using System.IO;
using System.Text;
using System.Windows;

namespace PrismUnity
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
            : base()
        {
            this.Dispatcher.UnhandledException += OnUnhandledException;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bs = new Bootstrapper();
            bs.Run();
        }
        void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var logFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log_error.txt");

            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath);
            }

            var sb = new StringBuilder();

            sb.Append(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append(" : ");
            sb.Append(e.Exception.Message);
            sb.AppendLine("## debug");
            sb.Append(e.Exception.ToString());
            sb.AppendLine("end debug ##");

            // If it raise an Exception, on the line below, in dev (visual studio). If you are on "Release" configuration, activate "Debug" configuration and re-build, 
            // and then re-activate "Release" and re-build and Run. Vice-Versa.
            var errorFileWriter = new StreamWriter(logFilePath, true);

            errorFileWriter.WriteLine(sb.ToString());
            errorFileWriter.Close();
            e.Handled = true;
        }
    }
}
