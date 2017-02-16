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

		public virtual FileEntity Add(FileEntity entity)
		{
			return _repository.Add(entity);
		}

		public virtual Task<FileEntity> AddAsync(FileEntity entity)
		{
			return Task.FromResult(Add(entity));
		}

		public virtual void Delete(FileEntity entity)
		{
			_repository.Delete(entity);
		}

		public virtual Task DeleteAsync(FileEntity entity)
		{
			return Task.Run(() => Delete(entity));
		}

		public virtual IQueryable<FileEntity> Find(Expression<Func<FileEntity, bool>> predicate)
		{
			return _repository.Find(predicate);
		}

		public virtual Task<IQueryable<FileEntity>> FindAsync(Expression<Func<FileEntity, bool>> predicate)
		{
			return Task.FromResult(Find(predicate));
		}

		public virtual IEnumerable<FileEntity> Get()
		{
			return _repository.Get();
		}

		public virtual IEnumerable<FileEntity> Get(IOFileEncodingType type)
		{
			return _repository.Get(type);
		}

		public virtual IEnumerable<FileEntity> Get(string path, string searchPattern, SearchOption searchOption)
		{
			return _repository.Get(path,searchPattern,searchOption);
		}

		public virtual Task<IEnumerable<FileEntity>> GetAsync()
		{
			return Task.FromResult(Get());
		}

		public virtual Task<IEnumerable<FileEntity>> GetAsync(IOFileEncodingType type)
		{
			return Task.FromResult(Get(type));
		}

		public virtual Task<IEnumerable<FileEntity>> GetAsync(string path, string searchPattern, SearchOption searchOption)
		{
			return Task.FromResult(Get(path, searchPattern, searchOption));
		}

		public virtual FileEntity GetById(string id)
		{
			return _repository.GetById(id);
		}

		public virtual FileEntity GetById(string id, IOFileEncodingType type)
		{
			return _repository.GetById(id,type);
		}

		public virtual FileEntity GetById(string id, IOFileEncodingType type, string format)
		{
			return _repository.GetById(id, type, format);
		}

		public virtual FileEntity GetById(string id, IOFileEncodingType type, IODataStringFormat format)
		{
			return _repository.GetById(id, type, format);
		}

		public virtual Task<FileEntity> GetByIdAsync(string id)
		{
			return Task.FromResult(GetById(id));
		}

		public virtual Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type)
		{
			return Task.FromResult(GetById(id,type));
		}

		public virtual Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type, string format)
		{
			return Task.FromResult(GetById(id, type,format));
		}

		public virtual Task<FileEntity> GetByIdAsync(string id, IOFileEncodingType type, IODataStringFormat format)
		{
			return Task.FromResult(GetById(id, type, format));
		}

		public virtual FileEntity Update(FileEntity entity)
		{
			return _repository.Update(entity);
		}

		public virtual Task<FileEntity> UpdateAsync(FileEntity entity)
		{
			return Task.FromResult(Update(entity));
		}
	}
}
