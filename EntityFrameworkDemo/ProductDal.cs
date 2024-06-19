using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EntityFrameworkDemo
{
    class ProductDal
    {
        public List<Product> GetALL()
        {
            using(ETradeContext context=new ETradeContext())
            {
                return context.Products.ToList();
            }
        }
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //1.kullanım
                //context.Products.Add(product);

                //2. kullanım
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
