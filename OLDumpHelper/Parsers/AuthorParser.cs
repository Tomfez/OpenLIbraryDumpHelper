﻿using OLDumpHelper.Models;
using System.Text.Json;

namespace OLDumpHelper.Parsers
{
    /// <summary>
    /// Parser for authors
    /// </summary>
    public class AuthorParser
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
        public void ReadFile()
        {
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

                    // If we hit 2000000 rows, we create another file to avoid huge file
                    if (i == 2000000)
                    {
                        WriteNewFormatToFiles(authors, v);

                        authors.Clear();
                        v += 1;
                        i = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Create new Json file and write new format into it
        /// </summary>
        /// <param name="authors"></param>
        /// <param name="v"></param>
        private void WriteNewFormatToFiles(List<Author?> authors, int v)
        {
            string newPath = Environment.ExpandEnvironmentVariables(Const.USER_FOLDER) + "\\" + Const.TEMP_FOLDER + "\\OLDumpAuthors" + v + ".json";
            IEnumerable<string>? lines = authors.Select(obj => JsonSerializer.Serialize(obj));

            using (StreamWriter sw = new StreamWriter(newPath))
            {
                int linesLength = lines.Count();
                sw.Write('[');

                for (int i = 0; i < linesLength - 1; i++)
                {
                    sw.Write(lines.ElementAt(i) + ",");
                }

                sw.Write(lines.ElementAt(linesLength - 1));
                sw.Write(']');
            }
        }
    }

}
