namespace WebCar.Models
{
	public class EmailHelperModel
	{
		public static string BuildTemplate(string path, string template)
		{
			StreamReader str = new StreamReader(Path.Combine(path, template));
			string mailText = str.ReadToEnd();
			str.Close();

			return mailText;
		}
	}
}
