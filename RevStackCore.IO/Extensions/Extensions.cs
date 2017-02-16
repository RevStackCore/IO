using System;
namespace RevStackCore.IO
{
	public static class Extensions
	{
		public static string ToDataStringFormat(this IODataStringFormat src)
		{
			switch (src)
			{
				case IODataStringFormat.Gif:
				    return "data:image/gif;base64,";
				case IODataStringFormat.Jpg:
					return "data:image/jpeg;base64,";
				case IODataStringFormat.Mp4:
					return "data:video/mp4;base64,";
				case IODataStringFormat.Mp3:
					return "data:audio/mpeg;base64,";
				case IODataStringFormat.Mpeg:
					return "data:video/mpeg;base64,";
				case IODataStringFormat.None:
					return "";
				case IODataStringFormat.Pdf:
					return "data:application/pdf;base64,";
				case IODataStringFormat.Png:
					return "data:image/png;base64,";
				case IODataStringFormat.Html:
					return "data:text/html;base64,";
				case IODataStringFormat.Zip:
					return "data:application/zip;base64,";
				case IODataStringFormat.Log:
					return "data:text/plain;base64,";
				case IODataStringFormat.Svg:
					return "data:image/svg+xml;base64,";
				case IODataStringFormat.Txt:
					return "data:text/plain;base64,";
					default:
					return "";			   
			}
		}
	}
}
