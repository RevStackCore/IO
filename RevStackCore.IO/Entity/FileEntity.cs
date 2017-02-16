using System;
using System.Collections.Generic;
using System.IO;
using RevStackCore.Pattern;

namespace RevStackCore.IO
{
	public class FileEntity : IEntity<string>
	{
		public string Id { get; set; }
		public string Extension { get; set; }
		public DateTime CreationTime { get; set; }
		public DateTime CreationTimeUtc { get; set; }
		public DateTime LastAccesTime { get; set; }
		public DateTime LastAccessTimeUtc { get; set; }
		public DateTime LastWriteTime { get; set; }
		public DateTime LastWriteTimeUtc { get; set; }
		public long Size { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public string Url { get; set; }
		public string Base64String { get; set; }
		public Stream Stream { get; set; }
		public Byte[] Content {get; set;}
		public FileAttributes FileAttributes { get; set; }
		public IODataStringFormat DataStringFormat { get; set; }
		public string MimeType { get; set; }
		public IEnumerable<string> Roles { get; set; }

	}
}
