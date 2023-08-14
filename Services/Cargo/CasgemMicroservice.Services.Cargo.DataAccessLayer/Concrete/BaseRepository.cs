using CasgemMicroservice.Services.Cargo.DataAccessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete
{
	public class BaseRepository<T> : IGenericDal<T> where T : class
	{

		public void Delete(T entity)
		{
			using (var context = new CargoContext())
			{
				var addedEntity = context.Entry(entity);//entityleri eşleştiriyorum
				addedEntity.State = EntityState.Deleted;//silme işlemi olduğunu belirtiyorum
				context.SaveChanges();//kaydediyorum
			}
			
		}

		public T GetById(int id)
		{
			using var context = new CargoContext();
			var entity = context.Entry(id);
			return context.Set<T>().Find(entity);

		}

		public List<T> GetList()
		{
			using var context=new CargoContext();
			return context.Set<T>().ToList();
		}

		public void Insert(T entity)
		{
			using (var context = new CargoContext())
			{
				var addedEntity = context.Entry(entity);//entityleri eşleştiriyorum
				addedEntity.State = EntityState.Added;//ekleme işlemi olduğunu belirtiyorum
				context.SaveChanges();//kaydediyorum
			}
		}

		public void Update(T entity)
		{
			using (var context = new CargoContext())
			{
				var addedEntity = context.Entry(entity);//entityleri eşleştiriyorum
				addedEntity.State = EntityState.Modified;//güncelleme işlemi olduğunu belirtiyorum
				context.SaveChanges();//kaydediyorum
			}
		}
	}
}
