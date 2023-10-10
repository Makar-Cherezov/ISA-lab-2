using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class ФормыОбучения
{
    public int КодФормыОбучения { get; set; }

    public string Наименование { get; set; }

    public virtual ICollection<Группы> Группыs { get; set; } = new List<Группы>();
}
