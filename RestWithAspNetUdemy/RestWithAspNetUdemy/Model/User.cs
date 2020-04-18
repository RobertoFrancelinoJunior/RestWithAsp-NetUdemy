using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string AccessKey { get; set; }
    }
}
