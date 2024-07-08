using OLDumpHelper.Models;
using OLDumpHelper.Parsers;
using System.Text.RegularExpressions;

namespace OLDumpHelper
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// tempFolder
        /// </summary>
        public static readonly string tempFolder = Environment.ExpandEnvironmentVariables(Const.USER_FOLDER) + Path.DirectorySeparatorChar + Const.TEMP_FOLDER;

        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Choose file to import:");
            Console.WriteLine("1) Authors");
            Console.WriteLine("2) Works");
            //Console.WriteLine("3) Editions");
            //Console.WriteLine("4) Ratings");

            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ManageAuthors();
                    break;
                case "2":
                    ManageWorks();
                    break;
                default:
                    Console.WriteLine("Error. Please enter a valid value.\n");
                    Main(args);
                    break;
            }
        }

        /// <summary>
        /// Manage the works dump file
        /// </summary>
        private static void ManageWorks()
        {
            Console.WriteLine("Path of file:");
            string? filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("Error: file not found");
                ManageWorks();
            }

            ClearFiles();
            //AuthorParser authorParser = new AuthorParser(filePath!);
            //List<Author>? authors = authorParser.ReadFile();
            //List<string> listAuthors = ReadAuthorFile();

        }

        /// <summary>
        /// Manage the authors dump file
        /// </summary>
        private static void ManageAuthors()
        {
            Console.WriteLine("Path of file:");
            string? filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("Error: file not found");
                ManageAuthors();
            }

            ClearFiles();
            AuthorParser authorParser = new AuthorParser(filePath!);
            List<Author?> authors = authorParser.ReadFile();
        }

        /// <summary>
        /// Delete ancient files before creating the new ones
        /// </summary>
        private static void ClearFiles()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(tempFolder);

            Regex reg = new Regex(Const.REG_OL);

            new List<string>(Directory.GetFiles(tempFolder)).ForEach(file =>
            {
                if (reg.IsMatch(file))
                    File.Delete(file);
            });
        }
    }
}
