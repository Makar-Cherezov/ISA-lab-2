using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class Справочник
{
    public int Код { get; set; }

    public string УровеньВладенияИя { get; set; }

    public virtual ICollection<Студенты> Студентыs { get; set; } = new List<Студенты>();
}
