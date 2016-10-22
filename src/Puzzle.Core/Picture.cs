using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puzzle.Core.Interface;
using System.Collections.Generic;

namespace Puzzle.Core
{
    public class Picture :IPicture
    {
        public void SavePicture(){

        }

        public List<string> GetPicture(){
               var stringList=new List<string>();
               stringList.Add("me");
               stringList.Add("you");

               return stringList;

        }
    }
}
