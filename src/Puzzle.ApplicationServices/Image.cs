using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle.ApplicationServices
{
    public class Image
    {
        public long CustomerId{get;set;}

        public Guid ImageId{get;set;}

        public DateTime  CreateDate{get;set;}

        public long CreateUserId{get;set;}
    }
}
