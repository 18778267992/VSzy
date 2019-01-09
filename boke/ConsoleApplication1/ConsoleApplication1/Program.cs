using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.BusinessLayer;
using ConsoleApplication1.DataAccessLayer;

namespace ConsoleApplication1
{
     class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            //QueryBlog();
            //Updata();
            //QueryBlog();
            Addpost();
            Delete();

            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        static void createBlog() ////输入新的博客
        {
            Console.WriteLine("请输入一个博客");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
            
        }
        static void Updata() /////修改博客
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个要修改博客id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id); 
            Console.Write("请输入修改后新的博客名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        

        static void QueryBlog()  //显示所有博客数据
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var query = bbl.Query();
            Console.WriteLine("所有数据库中到博客");
            foreach(var item in query)
            {
                Console.WriteLine(item.BlogId + ""+item .Name );
              
            }
          
        }
        static void Delete()   //删除一个博客
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入需要删除的一个博客");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);

        }
       static void Addpost()
        {
            QueryBlog();//显示所有博客数据
            //int blogId = GetBlogId();
           /* DispaltPosts(blogId);*///输入博客id显示帖子id
           /* PostBy(blogId);*///新增帖子
            /*DeletePost();*///删除帖子
            //Updata1();//修改帖子
            QueryForTitle();//查询帖子
        }

        static int GetBlogId()   //输入博客的ID显示名字
        {
            Console.WriteLine("请输入想要显示的id");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
        static void DispaltPosts(int blogId) //输入博客的ID显示数据库帖子的内容
        {
            Console.WriteLine(blogId + "的帖子列表");
            List<Post> list = null;
            using (var db=new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                list = blog.Posts.ToList();
            }
          foreach(var item in list)
            {
                Console.WriteLine(item.Blog.BlogId + "--" + item.Title);
            }
        }
        static void PostBy(int blogId)/////输入帖子和帖子内容
        {
            Console.WriteLine("请输入一个帖子的名字");
            string title = Console.ReadLine();
            Console.WriteLine("请输入一个内容到帖子");
            string content = Console.ReadLine();

            Post post = new Post();
            post.BlogId = blogId;
            post.Title = title;
            post.Content = content;

            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.pAdd(post);
        }
        static void DeletePost()   //删除一个帖子
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入需要删除的一个帖子");
            int   id =int  .Parse(Console.ReadLine());
            Post post = bbl.Query1(id); 
            bbl.DeletePost(post);
             
        }
        static void Updata1() /////修改帖子
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个要修改帖子id");
            int id = int.Parse(Console.ReadLine());
           Post post = bbl.Query1(id);
            Console.Write("请输入修改后新的帖子名字");
            string name = Console.ReadLine();
            
            bbl.Update1(post );
        }
        static void QueryPost()  //显示所有帖子数据
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var query = bbl.Query();
            Console.WriteLine("所有数据库中到博客");
            foreach (var item in query)
            {
                Console.WriteLine(item.BlogId + "" + item.Name);

            }

        }
        static void QueryForTitle()

        {
            Console.WriteLine("请输入将要查找到博客名称");
            string name = Console.ReadLine();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var query = bbl.QueryForTitle(name);
            foreach (var item in query )
            {
                Console.WriteLine(item.Title + "" + item.Content);
            }
        }

    }
}
