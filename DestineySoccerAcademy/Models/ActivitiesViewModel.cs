using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DestineySoccerAcademy.Models
{
    public class ActivitiesViewModel
    {
        [Required, StringLength(1000)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}