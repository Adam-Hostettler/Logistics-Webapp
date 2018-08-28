using System.Collections.Generic;
using System.Data;

namespace OrderProcess.Data.AdoNet
{
    public abstract class Repository<TEntity> where TEntity : new()
    {
        protected IAdoNetContext _context;

        public Repository(IAdoNetContext context)
        {
            _context = context;
        }

        public AdoNetContext Context { get; }

        public IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                var items = new List<TEntity>();
                while (reader.Read())
                {
                    var item = new TEntity();
                    Map(reader, item);
                    items.Add(item);
                }

                return items;
            }
        }

        public abstract void Map(IDataRecord record, TEntity entity);
    }
}