using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class TestModel
    {
        [Required]
        [StringLength(6, MinimumLength = 3)]
        [Display(Name = "User Name")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed")]
        public string Name { get; set; }

        public DateTime Date { get; set; }
        public String Time { get; set; }
    }

    public class TestModels
    {

        public TestModels()
        {
            _dataList.Add(new TestModel
            {
                Name = "Kalle",
                Date = DateTime.Now,
                Time = "10:20",
            });
        }

        public List<TestModel> _dataList = new List<TestModel>();

    }
}