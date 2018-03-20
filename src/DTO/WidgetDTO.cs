using System;

namespace DTO
{
    //TODO: Create T4 to auto generate these from Entities
    public class WidgetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ManufacturedDate { get; set; }
    }
}
