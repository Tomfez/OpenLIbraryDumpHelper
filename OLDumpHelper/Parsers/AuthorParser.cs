using OLDumpHelper.Models;
using System.Text.Json;

namespace OLDumpHelper.Parsers
{
    internal class AuthorParser
    {
        private string _filePath;

        /// <summary>
        /// AuthorParser
        /// </summary>
        /// <param name="filePath"></param>
        public AuthorParser(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Read the authors file and parse data to Json format
        /// </summary>
        /// <returns></returns>
        internal List<Author?> ReadFile()
        {
            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    PropertyNameCaseInsensitive = true,
            //    //Converters =
            //    //{
            //    //    new CustomJsonConverter() 
            //    //}
            //};

            int i = 0;
            List<Author?> authors = new();
            int v = 0;

            using (StreamReader sr = new StreamReader(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    if (line == null)
                        break;

                    string[]? values = line.Split('\t');

                    Author? author = JsonSerializer.Deserialize<Author>(values[4]);
                    authors.Add(author);
                    i++;

                    //Save to database ?

                    // If we hit 2000000 rows, we create another file to avoid excessive memory
                    if (i == 2000000)
                    {
                        WriteNewFormatToFiles(authors, v);

                        authors.Clear();
                        v += 1;
                        i = 0;
                    }
                }
            }

            return authors;
        }

        /// <summary>
        /// Create new Json file and write new format into it
        /// </summary>
        /// <param name="authors"></param>
        /// <param name="v"></param>
        private void WriteNewFormatToFiles(List<Author?> authors, int v)
        {
            string newPath = Environment.ExpandEnvironmentVariables(Const.USER_FOLDER) + "\\" + Const.TEMP_FOLDER + "\\OLDumpauthors" + v + ".json";
            IEnumerable<string>? lines = authors.Select(obj => JsonSerializer.Serialize(obj));

            File.WriteAllLines(newPath, lines);

        }
    }
}
