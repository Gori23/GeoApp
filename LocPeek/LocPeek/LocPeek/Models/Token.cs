using System;
using System.Collections.Generic;
using System.Text;

namespace LocPeek.Models
{
    public class Token
    {
        public Token()
        {
        }

        public int Id { get; set; }
        public String AccesToken { get; set; }
        public string ErrrorDescription { get; set; }
        public DateTime ExpirDate { get; set; }
    }
}
