namespace MAUI_ScanImages.Services
{
    public class ServiceInterest
    {
        private List<string> interestDirs { get; set; }

        public ServiceInterest()
        {
            interestDirs = GetImageDictionary();
        }

        public string GetInterestImage(int percent)
        {
            return interestDirs[percent];
        }

        private List<string> GetImageDictionary()
        {
            interestDirs = new List<string>();

            for (int i = 0; i <= 100; i++)
            {
                string percent = ConvertInterestToName(i);
                string imageDir = $"interest{percent}.png";

                interestDirs.Add(imageDir);
            }

            return interestDirs;
        }

        private string ConvertInterestToName(int i)
        {
            string res = string.Empty;

            if (i == 0)
            {
                res = $"000";
            }
            if (i < 10 && i != 0)
            {
                res = $"00{i}";
            }
            
            if (i <= 99 && i != 0 && i > 9)
            {
                res = $"0{i}";
            }

            if (i == 100)
            {
                res = $"{i}";
            }

            return res ;
        }
    }
}
