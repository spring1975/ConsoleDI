using System.Collections.Generic;
using DTO;

namespace EFLogicService.Interfaces
{
    public interface IWidgetService
    {
        IEnumerable<WidgetDTO> GetWidgets();

        WidgetDTO AddWidget(string name);
    }
}