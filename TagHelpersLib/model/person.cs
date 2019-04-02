using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TagHelpersLib.model
{
    public class person
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
    }
}
