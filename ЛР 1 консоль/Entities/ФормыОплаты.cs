using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class ФормыОплаты
{
    public int КодФормыОплаты { get; set; }

    public string Наименование { get; set; }

    public virtual ICollection<СтудентыВГруппах> СтудентыВГруппахs { get; set; } = new List<СтудентыВГруппах>();
}
