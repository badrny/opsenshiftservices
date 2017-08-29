
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioWebServicesCore.Model
{
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; set; }
        public string Label { get; set; }
        public IList<BookType> Types { get; set; }
    }
    public class BookType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; set; }
        public long TypeID { get; set; }
        public long BookID { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
       [JsonIgnore]
        public Type Type { get; set; }
    }
    public class Book : IMedia
    {
     
        public enum BookFormat
        {
            Poche,Broché,numérique
        
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverSrc { get; set; }
        public string Note { get; set; }
        public IList<BookType> Types { get; set; }
        public BookFormat Format { get; set; }
        public bool IsRead { get; set ; }
        public DateTime Date { get; set; }
        public Book(){
            IsRead = false;
            Note = "";
        }
    }

 
}
