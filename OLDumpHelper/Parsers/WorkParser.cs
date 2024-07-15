using OLDumpHelper.Models;
using System.Text.Json;

namespace OLDumpHelper.Parsers
{
    /// <summary>
    /// Parser for works
    /// </summary>
    public class WorkParser
    {
        private string _filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath"></param>
        public WorkParser(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Read the work file
        /// </summary>
        public void ReadFile()
        {
            int i = 0;
            List<Work?> works = new();
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
                    Work? work = null;

                    try
                    {
                        work = JsonSerializer.Deserialize<Work>(values[4]);
                    }
                    catch (JsonException)
                    {
                        throw;
                    }

                    works.Add(work);
                    i++;

                    if (i == 2000000)
                    {
                        WriteNewFormatToFiles(works, v);

                        works.Clear();
                        v += 1;
                        i = 0;
                    }

                }
            }
        }

        /// <summary>
        /// Write the data to a new file
        /// </summary>
        /// <param name="works"></param>
        /// <param name="v"></param>
        public void WriteNewFormatToFiles(List<Work?> works, int v)
        {
            string newPath = Environment.ExpandEnvironmentVariables(Const.USER_FOLDER) + "\\" + Const.TEMP_FOLDER + "\\OLDumpWorks" + v + ".json";
            IEnumerable<string>? lines = works.Select(obj => JsonSerializer.Serialize(obj));

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
