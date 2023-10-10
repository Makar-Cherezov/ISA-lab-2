using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class ФормыКонтроля
{
    public int КодФормыКонтроля { get; set; }

    public string Наименование { get; set; }

    public virtual ICollection<ДисциплинаВСеместре> ДисциплинаВСеместреs { get; set; } = new List<ДисциплинаВСеместре>();
}
