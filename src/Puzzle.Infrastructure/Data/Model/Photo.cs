using System;
using MySQL.Data.EntityFrameworkCore.Extensions; 

namespace Puzzle.Infrastructure.Data.Model 
{
    public class Photo
    {
        public Photo(){

        }
        public long PhotoID {get; set;}

        public long UserId {get;set;}

        public string StorageId {get;set;}

        public DateTime CreateDate {get;set;}
    }

}

