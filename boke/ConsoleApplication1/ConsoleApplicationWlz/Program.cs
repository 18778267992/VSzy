using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.BusinessLayer;
using ConsoleApplication1.Model;

namespace ConsoleApplicationWlz
{
    class Program
    {
        static void Main(string[] args)
        {
            createBlog();
           
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        static void Updata()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个名字id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            Console.Write("请输入新的班级名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        static void createBlog()
        {
            Console.WriteLine("请输入一个班级");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);

        }
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var query = bbl.Query();
            Console.WriteLine("所有名字中到班级");
            foreach (var item in query)
            {
                Console.WriteLine(item.BlogId + "" + item.Name);

            }

        }
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入一个班级");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
     
  
  
