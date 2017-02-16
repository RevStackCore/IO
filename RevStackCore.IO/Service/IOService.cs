using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RevStackCore.IO
{
	public class IOService : IIOService
	{
		private readonly IIORepository _repository;
		public IOService(IIORepository repository)
		{
			_repository = repository;
		}

		public FileEntity Add(FileEntity entity)
		{
			return _repository.Add(entity);
		}

		public Task<FileEntity> AddAsync(FileEntity entity)
		{
			return Task.FromResult(Add(entity));
		}

		public void Delete(FileEntity entity)
		{
			_repository.Delete(entity);
		}

		public Task DeleteAsync(FileEntity entity)
		{
			return Task.Run(() => Delete(entity));
		}

		public IQueryable<FileEntity> Find(Expression<Func<FileEntity, bool>> predicate)
		{
			return _repository.Find(predicate);
		}

		public Task<IQueryable<FileEntity>> FindAsync(Expression<Func<FileEntity, bool>> predicate)
		{
			return Task.FromResult(Find(predicate));
		}

		public IEnumerable<FileEntity> Get()
		{
			return _repository.Get();
		}

		public IEnumerable<FileEntity> Get(IOFileEncodingType type)
		{
			return _repository.Get(type);
		}

		public IEnumerable<FileEntity> Get(string path, string searchPattern, SearchOption searchOption)
		{
			return _repository.Get(path,searchPattern,searchOption);
		}

		public Task<IEnumerable<FileEntity>> GetAsync()
		{
			return Task.FromResult(Get());
		}

		public Task<IEnumerable<FileEntity>> GetAsync(IOFileEncodingType type)
		{
			return Task.FromResult(Get(type));
		}

		public Task<IEnumerable<FileEntity>> GetAsync(string path, string searchPattern, SearchOption searchOption)
		{
			return Task.FromResult(Get(path, searchPattern, searchOption));
		}

		public FileEntity GetById(string id)
		{
			return _repository.GetById(id);
		}

		public FileEntity GetById(string id, IOFileEncodingType type)
		{
			return _repository.GetById(id,type);
		}

		public FileEntity GetById(string id, IOFileEncodingType type, string format)
		{
			return _repository.GetById(id, type, format);
		}

		public FileEntity GetById(string id, IOFileEncodingType type, IODataStringFormat format)
		{
			return _repository.GetById(id, type, format);
		}

		public Task<FileEntity> GetByIdAsync(string id)
		{
			return Task.FromResult(GetById(id));
		}

		public Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type)
		{
			return Task.FromResult(GetById(id,type));
		}

		public Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type, string format)
		{
			return Task.FromResult(GetById(id, type,format));
		}

		public Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type, IODataStringFormat format)
		{
			return Task.FromResult(GetById(id, type, format));
		}

		public FileEntity Update(FileEntity entity)
		{
			return _repository.Update(entity);
		}

		public Task<FileEntity> UpdateAsync(FileEntity entity)
		{
			return Task.FromResult(Update(entity));
		}
	}
}
