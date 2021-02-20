using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace DestineySoccerAcademy.Models
{
    public class Activities
    {
        // General properties  
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        // Time based properties  
        public DateTime? CreateTime { get; set; }

        // Other properties and settings may include UserID, RoleID etc.  
    }

}  
