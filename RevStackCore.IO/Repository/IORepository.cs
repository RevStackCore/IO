using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;


namespace RevStackCore.IO
{
	public class IORepository : IIORepository
	{
		private readonly IODbContext _dbContext;
		public IORepository(IODbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public FileEntity Add(FileEntity entity)
		{
			return _dbContext.Add(entity);
		}

		public void Delete(FileEntity entity)
		{
			_dbContext.Delete(entity.Path);
		}

		public IQueryable<FileEntity> Find(Expression<Func<FileEntity, bool>> predicate)
		{
			return _dbContext.Get().AsQueryable().Where(predicate);
		}

		public IEnumerable<FileEntity> Get()
		{
			return _dbContext.Get();
		}

		public IEnumerable<FileEntity> Get(IOFileEncodingType type)
		{
			return _dbContext.Get(type);
		}

		public IEnumerable<FileEntity> Get(string path, string searchPattern, SearchOption searchOption)
		{
			return _dbContext.Get(path,searchPattern,searchOption);
		}

		public FileEntity GetById(string id)
		{
			return _dbContext.GetById(id);
		}

		public FileEntity GetById(string id, IOFileEncodingType type)
		{
			return _dbContext.GetById(id,type);
		}

		public FileEntity GetById(string id, IOFileEncodingType type, string format)
		{
			return _dbContext.GetById(id, type, format);
		}

		public FileEntity GetById(string id, IOFileEncodingType type, IODataStringFormat format)
		{
			return _dbContext.GetById(id, type, format);
		}

		public FileEntity Update(FileEntity entity)
		{
			return _dbContext.Update(entity);
		}
	}
}
