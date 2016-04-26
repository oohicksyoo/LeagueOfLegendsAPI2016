namespace StringExtensions
{
    public static class StringExtensions
    {
        public static string FormatSummonerName(this string name)
        {
            string[] splitName = name.Split(' ');
            string formattedString = "";

            for (int i = 0; i < splitName.Length - 1; i++)
            {
                formattedString += splitName[i] + "%20";
            }
            formattedString += splitName[splitName.Length - 1];
            return formattedString;
        }
    }
}
