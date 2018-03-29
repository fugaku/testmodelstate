using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestModelState.Models
{
    public class MyModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Start: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Required]
        [DisplayName("End: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
    }
}
