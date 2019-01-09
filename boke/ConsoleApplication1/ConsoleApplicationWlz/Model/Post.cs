using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
public  class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; } ///相当于数据库外码
        public virtual Blog Blog { get; set; }///导航属性--目的是通过博客对象访问对应到一组帖子 

    }
}
