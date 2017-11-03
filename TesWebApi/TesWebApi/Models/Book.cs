using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesWebApi.Models
{
    public class Book
    {
        [ValidateBookTitleAttribute]
        public string Title { get; set; }
    }
}