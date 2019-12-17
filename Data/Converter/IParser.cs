﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPessoas.Data.Converter
{
    interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> originList);
    }
}
