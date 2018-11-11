using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TungstenBlog.DTO;

namespace TungstenBlog.Web.Models
{
    public class Article
    {
        public string Title { get; set; }

        public string Guid { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PubDate { get; set; }

        public string Creator { get; set; }

        public List<string> Categories { get; set; }

        public string Description { get; set; }

        public EnclosureDTO Enclosure { get; set; }
    }
}