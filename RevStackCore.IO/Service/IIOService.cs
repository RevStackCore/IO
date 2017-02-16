using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RevStackCore.Pattern;


namespace RevStackCore.IO
{
	public interface IIOService : IService<FileEntity,string>
	{
		IEnumerable<FileEntity> Get(string path, string searchPattern, SearchOption searchOption);
		IEnumerable<FileEntity> Get(IOFileEncodingType type);
		FileEntity GetById(string id, IOFileEncodingType type);
		FileEntity GetById(string id, IOFileEncodingType type, IODataStringFormat format);
		FileEntity GetById(string id, IOFileEncodingType type, string format);
		Task<IEnumerable<FileEntity>> GetAsync(string path, string searchPattern, SearchOption searchOption);
		Task<IEnumerable<FileEntity>> GetAsync(IOFileEncodingType type);
		Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type);
		Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type, IODataStringFormat format);
		Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type, string format);
	}
}
