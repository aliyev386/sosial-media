using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Post
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public uint LikeCount { get; set; }
        public uint ViewCount { get; set; }
        public HashSet<string> LikedUsers { get; set; } = new HashSet<string>();
        public Post(string id, string content, DateTime creationDateTime, uint likeCount, uint viewCount)
        {
            Id = id;
            Content = content;
            CreationDateTime = creationDateTime;
            LikeCount = likeCount;
            ViewCount = viewCount;
        }
        public void ShowPost()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Content: {Content}");
            Console.WriteLine($"Creation time: {CreationDateTime}");
            Console.WriteLine($"Like count: {LikeCount}");
            Console.WriteLine($"View count: {ViewCount}");
            Console.WriteLine("#-------------------------------------------------#");
        }
        
    }
}
