using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class ЗачетнаяВедомость
{
    public Guid IdСтудента { get; set; }

    public Guid IdГруппы { get; set; }

    public Guid IdДисциплиныВСеместре { get; set; }

    public DateTime ДатаСдачи { get; set; }

    public int Балл { get; set; }

    public int Отметка { get; set; }

    public string Литера { get; set; }

    public virtual СтудентыВГруппах Id { get; set; }

    public virtual ДисциплинаВСеместре IdДисциплиныВСеместреNavigation { get; set; }
}
