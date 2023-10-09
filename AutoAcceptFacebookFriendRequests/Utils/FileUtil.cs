namespace AutoAcceptFacebookFriendRequests.Utils
{
    public static class FileUtil
    {
        public static string RandomChoice(string filePath)
        {
            string[] lines = ReadFileToLinesArray(filePath);

            if (lines.Length < 1)
                return string.Empty;

            Random rnd = new Random();
            int index = rnd.Next(0, lines.Length);

            return lines[index];
        }

        public static string[] ReadFileToLinesArray(string filePath)
        {
            List<string> lines = new List<string>();

            foreach (string line in ReadLines(filePath))
                lines.Add(line);

            return lines.ToArray();
        }

        public static IEnumerable<string> ReadLines(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                    yield return line.Trim();
            }
        }
    }
}
