using log4net;
using log4net.Appender;
using log4net.Config;
using System.Diagnostics;

namespace Log4netTest
{
    class Program
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            Process proc = Process.GetCurrentProcess();

            string nomeProcesso = proc.ProcessName;
            int idProcesso = proc.Id;


            string pasta = @"c:\lixo";

            //===============================================================
            // Configura parametros, pasta e nome arquivo para geracao do LOG
            //===============================================================
            GetNewFileApender(pasta , $"{nomeProcesso}_{idProcesso}");
            //===============================================================

            log.Error("Test do lixaoooooooo 1");
          
        }

        private static RollingFileAppender GetNewFileApender(string pasta, string nomeArquivo)
        {
            string pathArquivoLog = $"{pasta}\\Log\\{nomeArquivo}.log";

            RollingFileAppender appender = new RollingFileAppender();

            appender.Name = nomeArquivo;
            appender.File = pathArquivoLog;
            appender.AppendToFile = true;

            appender.MaxSizeRollBackups = 10;
            appender.MaximumFileSize = "10MB";
            appender.StaticLogFileName = true;
            appender.RollingStyle = RollingFileAppender.RollingMode.Size;
            appender.DatePattern = "dd/MM/yyyy";
            appender.Threshold = log4net.Core.Level.Error;

            var layout = new log4net.Layout.PatternLayout("%d{dd/MM/yyyy HH:mm:ss:ms}|%message%n");
            appender.Layout = layout;

            layout.ActivateOptions();
            appender.ActivateOptions();
            BasicConfigurator.Configure(appender);

            return appender;
        }
    }
}