using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class СтудентыВГруппах
{
    public Guid IdСтудента { get; set; }

    public Guid IdГруппы { get; set; }

    public int КодФормыОплаты { get; set; }

    public virtual Группы IdГруппыNavigation { get; set; }

    public virtual Студенты IdСтудентаNavigation { get; set; }

    public virtual ICollection<ЗачетнаяВедомость> ЗачетнаяВедомостьs { get; set; } = new List<ЗачетнаяВедомость>();

    public virtual ФормыОплаты КодФормыОплатыNavigation { get; set; }
}
