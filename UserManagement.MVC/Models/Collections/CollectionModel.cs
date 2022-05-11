using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models.Collections
{
    public class CollectionModel
    {
        public string Id { get; set; }
        public string Name { get; set; }    
        public string Descr { get; set; }   
        public string UserID { get; set; }
        //public List<CollectionItemModel> CollectionItems { get; set; }
    }
}
