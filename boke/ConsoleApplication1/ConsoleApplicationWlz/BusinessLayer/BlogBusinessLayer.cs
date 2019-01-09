using ConsoleApplication1.DataAccessLayer;
using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.BusinessLayer
{
   public class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);

                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }
        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
  }

