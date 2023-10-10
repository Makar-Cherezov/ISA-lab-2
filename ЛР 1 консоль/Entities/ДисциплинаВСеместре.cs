using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class ДисциплинаВСеместре
{
    public Guid IdДисциплиныВСеместре { get; set; }

    public Guid IdЛектора { get; set; }

    public Guid IdГруппы { get; set; }

    public string КодДисциплины { get; set; }

    public int НомерСеместраОбучения { get; set; }

    public int КоличествоЧасовВНеделю { get; set; }

    public int КодФормыКонтроля { get; set; }

    public virtual Группы IdГруппыNavigation { get; set; }

    public virtual Преподаватели IdЛектораNavigation { get; set; }

    public virtual ICollection<ЗачетнаяВедомость> ЗачетнаяВедомостьs { get; set; } = new List<ЗачетнаяВедомость>();

    public virtual Дисциплины КодДисциплиныNavigation { get; set; }

    public virtual ФормыКонтроля КодФормыКонтроляNavigation { get; set; }
}
