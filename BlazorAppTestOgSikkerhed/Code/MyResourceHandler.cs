namespace BlazorAppTestOgSikkerhed.Code
{
    public class MyResourceHandler
    {
        public bool CreateTestFile()
        {
            bool success = true;

            try
            {
                var testFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string folderPath = Path.Combine(testFolder, "BlazorAppTest.txt"); // Opretter en fil cross platform (Path.Combine)
                File.CreateText(folderPath);

            } catch (Exception) { 
                
                success = false;
            }

            return success;
        }
    }
}
