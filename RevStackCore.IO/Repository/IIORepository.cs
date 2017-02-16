using System;
using System.Collections.Generic;
using System.IO;
using RevStackCore.Pattern;

namespace RevStackCore.IO
{
	public interface IIORepository : IRepository<FileEntity,string>
	{
		IEnumerable<FileEntity> Get(string path, string searchPattern, SearchOption searchOption);
		IEnumerable<FileEntity> Get(IOFileEncodingType type);
		FileEntity GetById(string id, IOFileEncodingType type);
		FileEntity GetById(string id, IOFileEncodingType type, IODataStringFormat format);
		FileEntity GetById(string id, IOFileEncodingType type, string format);
	}
}
