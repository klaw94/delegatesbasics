namespace DelegateTutorials
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();
            LogDel LogDelToScreenDel, LogTextToFileDel;
            LogDelToScreenDel = new LogDel(log.LogTextToScreen);
            LogTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogDelToScreenDel + LogTextToFileDel;

            Console.WriteLine("Please enter your name");
            var name = Console.ReadLine();

            LogText(multiLogDel, name);
            
            Console.ReadKey();
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
   
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}:{text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}:{text}");
            }
        }
    }
}