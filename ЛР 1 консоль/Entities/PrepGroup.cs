using System;
using System.Collections.Generic;

namespace ЛР_1_консоль.Entities;

public partial class PrepGroup
{
    public Guid IdПреподавателя { get; set; }

    public string Фамилия { get; set; }

    public Guid IdГруппы { get; set; }

    public string Наименование { get; set; }

    public int ГодПоступления { get; set; }
}
