using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RevStackCore.IO
{
	public class IODbContext
	{
		private const string SEARCH_PATTERN= "*.*";
		private const SearchOption SEARCH_OPTION = SearchOption.TopDirectoryOnly;
		public IODbContext(string path, string searchPattern, SearchOption searchOption)
		{
			Path = path;
			SearchPattern = searchPattern;
			SearchOption = searchOption;
		}

		public IODbContext(string path)
		{
			Path = path;
			SearchPattern = SEARCH_PATTERN;
			SearchOption = SEARCH_OPTION;
		}

		public string Path { get; set; }
		public string SearchPattern;
		private SearchOption SearchOption;

		public IEnumerable<FileEntity> Get()
		{
			return get(Path, SearchPattern, SearchOption);
		}

		public IEnumerable<FileEntity> Get(IOFileEncodingType type)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<FileEntity> Get(string path, string searchPattern, SearchOption searchOption)
		{
			return get(path, searchPattern, searchOption);
		}

		public FileEntity GetById(string id)
		{
			return getById(id);
		}

		public FileEntity GetById(string id, IOFileEncodingType type)
		{
			var entity = getById(id);
			using (var stream = new FileStream(id, FileMode.Open, FileAccess.Read))
			{
				if (type == IOFileEncodingType.Stream)
				{
					entity.Stream = stream;
				}
				else if (type == IOFileEncodingType.Bytes)
				{
					var mem = new MemoryStream();
					stream.CopyTo(mem);
					entity.Content = mem.ToArray();
				}
				else if (type == IOFileEncodingType.Base64String)
				{
					var mem = new MemoryStream();
					stream.CopyTo(mem);
					entity.Base64String = Convert.ToBase64String(mem.ToArray());
				}
				return entity;
			}
		}

		public FileEntity GetById(string id, IOFileEncodingType type, string format)
		{
			if (type == IOFileEncodingType.Bytes || type == IOFileEncodingType.Stream)
			{
				return GetById(id, type);
			}
			else
			{
				var entity = getById(id);
				using (var stream = new FileStream(id, FileMode.Open, FileAccess.Read))
				{
					var mem = new MemoryStream();
					stream.CopyTo(mem);
					string base64=Convert.ToBase64String(mem.ToArray());
					entity.Base64String = format + base64;
					return entity;
				}
			}
		}

		public FileEntity GetById(string id, IOFileEncodingType type, IODataStringFormat format)
		{
			string strFormat = format.ToDataStringFormat();
			return GetById(id, type, strFormat);
		}

		public FileEntity Add(FileEntity entity)
		{
			var newStream = new FileStream(entity.Path, FileMode.Create, FileAccess.Write);
			entity.Stream.Seek(0, SeekOrigin.Begin);
			entity.Stream.CopyTo(newStream);
			return entity;
		}

		public FileEntity Update(FileEntity entity)
		{
			var newStream = new FileStream(entity.Path, FileMode.OpenOrCreate, FileAccess.Write);
			entity.Stream.Seek(0, SeekOrigin.Begin);
			entity.Stream.CopyTo(newStream);
			return entity;
		}

		public void Delete(string id)
		{
			try
			{
				var f = new FileInfo(id);
				f.Delete();
			}
			catch (Exception)
			{
				
			}
		}

		private IEnumerable<FileEntity> get(string path,string searchPattern,SearchOption searchOption)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			var files = dirInfo.EnumerateFiles(searchPattern, searchOption)
					   .AsParallel()
					   .Select(x => new FileEntity
					   {
						   Id = x.Name,
						   Extension = x.Extension,
						   CreationTime = x.CreationTime,
						   CreationTimeUtc = x.CreationTimeUtc,
						   LastAccesTime = x.LastAccessTime,
						   LastAccessTimeUtc = x.LastAccessTimeUtc,
						   LastWriteTime = x.LastWriteTime,
						   LastWriteTimeUtc = x.LastWriteTimeUtc,
						   Size = x.Length,
						   Name = x.Name,
						   FileAttributes = x.Attributes,
				           Path=x.FullName

					   });

			return files;
		}

		private FileEntity getById(string id)
		{
			var x = new FileInfo(id);
			return new FileEntity
			{
				Id = x.Name,
				Extension = x.Extension,
				CreationTime = x.CreationTime,
				CreationTimeUtc = x.CreationTimeUtc,
				LastAccesTime = x.LastAccessTime,
				LastAccessTimeUtc = x.LastAccessTimeUtc,
				LastWriteTime = x.LastWriteTime,
				LastWriteTimeUtc = x.LastWriteTimeUtc,
				Size = x.Length,
				Name = x.Name,
				FileAttributes = x.Attributes,
				Path = x.FullName
			};
		}


	}
}
