using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{

    public enum CuisineType
    {
        None,
        Mexican,
        Italian,
        Indian
    }

    public class Restaurant //: IValidatableObject kun je gebruiken voor meer complexe validaties
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }


    }
}
