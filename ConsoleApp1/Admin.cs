using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Admin
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public List<Post> Posts;
        public List<User> Users;
        public Admin() { }
        public Admin(string id, string username, string gmail, string password, List<Post> posts)
        {
            Id = id;
            Username = username;
            Gmail = gmail;
            Password = password;
            Posts = posts;
        }
        public Post SearchPostId(string id)
        {
            foreach (var post in Posts)
            {
                if (post.Id == id)
                {
                    return post;
                }
            }
            return null;
        }
        
    }
}
