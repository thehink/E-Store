using EStore.Data;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> Filter(string query, int categoryId)
        {

            if (string.IsNullOrEmpty(query))
            {
                query = "";
            }

            var queryArr = query.Replace("  ", " ").Split(' ');

            string regexStr = "";

            foreach(var term in queryArr)
            {
                regexStr += $"{Regex.Escape(term)}|";
            }

            regexStr = regexStr.Remove(regexStr.Length - 1);

            Regex regex = new Regex($"^(.+)?({regexStr})(.+)?$", RegexOptions.IgnoreCase);

            return this._context
                .Include(s => s.Category)
                .Where(
                product => product.Public == true &&
                   (string.IsNullOrEmpty(query) || 
                    regex.IsMatch(product.Category.Name) ||
                    regex.IsMatch(product.Name)) &&
                (categoryId == 0 || product.Category.Id == categoryId)
              );
        }

        public override Product Find(int id)
        {
            return this._context.Include("Category").First(p => p.Id == id);
        }

    }
}
