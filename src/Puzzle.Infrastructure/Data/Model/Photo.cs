using System;
using MySQL.Data.EntityFrameworkCore.Extensions; 

namespace Puzzle.Infrastructure.Model {

    public class Photo
    {
        public Photo(){

        }
        public long PhotoID{get;set;}

        public long CustomerID{get;set;}

        public string PhotoStorageID{get;set;}
    }

}

