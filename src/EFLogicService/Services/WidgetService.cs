using System;
using System.Collections.Generic;
using System.Linq;
using DataFramework;
using DataFramework.Entities;
using DTO;
using EFLogicService.Interfaces;

namespace EFLogicService.Services
{
    public class WidgetService : IWidgetService
    {
        private readonly EF6DBContext _context;

        public WidgetService(EF6DBContext context)
        {
            _context = context;
        }

        public IEnumerable<WidgetDTO> GetWidgets()
        {
            var widgets = _context.Widgets.Select(AsDto);

            return widgets;
        }

        private static WidgetDTO AsDto(Widget widget)
        {
            return new WidgetDTO
            {
                Name = widget.Name,
                ManufacturedDate = widget.ManufacturedDate
            };
        }

        public WidgetDTO AddWidget(string name)
        {
            var widget = new Widget
            {
                Name = name,
                ManufacturedDate = DateTimeOffset.UtcNow
            };

            _context.Widgets.Add(widget);
            _context.SaveChanges();

            var widgetDto = new WidgetDTO
            {
                Name = widget.Name,
                ManufacturedDate = widget.ManufacturedDate
            };

            
            return widgetDto;
        }
    }
}
