﻿using System;
using System.Collections.Generic;
using Qweex.Unions;

namespace Monads.Core.List.Type
{
    public class ListM<T> : TList<T>.P<ListM<T>>
    {
        public ListM(params T[] elems)
            :this(new List<T>(elems))
        {}
        public ListM(Func<TUnion<EmptyList, IEnumerable<T>>> factory) : base(factory)
        {
        }

        public ListM() : this(new EmptyList()) {}

        public ListM(EmptyList value) : base(value)
        {
        }

        public ListM(IEnumerable<T> value) : base(value)
        {
        }
    }
}