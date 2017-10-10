using System;
using System.Linq;
using System.Text;
using System.IO;
namespace Fileutil
{
	class FileGetterFromHTML
	{
		static readonly string url = "http://azurlane.wikiru.jp/index.php?%A5%AB%A5%C3%A5%B7%A5%F3";
		static void Main(string[] args)
		{
			string inputedURL = url;
			string gettedSource = HTMLSouceGetter.GetSource(inputedURL,Encoding.GetEncoding("EUC-JP"));
			Console.Write(ParseLine(gettedSource,"jpg","attach2"));
			Console.ReadKey();

		}


		static string ParseLine(string gettedSource,params string[]  search)
		{
			string currentLine = "";
			StringReader stringReader = new StringReader(gettedSource);
			while(currentLine!=null)
			{
				string[] parsed = currentLine.Split('"');
				if(parsed.Length>0)
				{
					var s = parsed.Where(X=>X.Contains(search[0]) && X.Contains(search[1]));
					if(s.Count()>0)
						return s.First();

				}
				currentLine = stringReader.ReadLine();
			}

			return null;
		}
	}
}
