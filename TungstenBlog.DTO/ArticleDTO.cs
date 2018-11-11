using System;
using System.Collections.Generic;
using System.Text;

namespace TungstenBlog.DTO
{
    public class ArticleDTO
    {
        public string Title { get; set; }
        
        public string Guid { get; set; }
        
        public string PubDate { get; set; }

        public string Creator { get; set; }

        public List<string> Categories { get; set; }

        public string Description { get; set; }

        public EnclosureDTO Enclosure { get; set; }
    }
}
