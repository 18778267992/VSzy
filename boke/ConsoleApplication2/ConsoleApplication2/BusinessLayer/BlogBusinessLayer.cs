using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.DataAccessLayer;
using ConsoleApplication2.Model;

namespace ConsoleApplication2.BusinessLayer
{
    class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);

                db.SaveChanges();
            }
        }
    }
}
