using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
namespace FileUtil
{
	class FileGetterFromHTML
	{
		static readonly string url = "http://azurlane.wikiru.jp/index.php?%A5%D6%A5%EB%A5%C9%A5%C3%A5%B0";
		static void Main(string[] args)
		{
			string inputedURL = url;
			string gettedSource = HTMLSouceGetter.GetSource(inputedURL,Encoding.GetEncoding("EUC-JP"));
			var parsedURL =HTMLSouceGetter.ParseLine(gettedSource,"jpg");
			
			
			WebClient web = new WebClient();
			var rawData = web.DownloadData(parsedURL.Where(X=>X.Contains("attach2")).Select(X=>"http://azurlane.wikiru.jp/" +X).First());
			File.WriteAllBytes("C:/Users/fujit/Downloads/donwnloadTool/test.jpg",rawData);

		}


		
	}
}
