using System.ComponentModel.DataAnnotations;

namespace PizzaTest.Models
{
    public class OrderPizza
    {
        [Key]
      public  int Id { get; set; }
       public int NumberOrder { get; set;}
       public int MassOrder { get; set; }
       public string AreaOrder {  get; set; }
        DateTime dateTime { get; set; }
    }
}
