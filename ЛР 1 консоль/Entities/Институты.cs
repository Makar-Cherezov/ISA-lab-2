using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class Институты
{
    public Guid IdИнститута { get; set; }

    public string Наименование { get; set; }

    public virtual ICollection<Группы> Группыs { get; set; } = new List<Группы>();

    public virtual ICollection<Преподаватели> Преподавателиs { get; set; } = new List<Преподаватели>();
}
