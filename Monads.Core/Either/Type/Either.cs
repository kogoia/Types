﻿using System;
using Qweex.Unions;

namespace Monads.Core.Either.Type
{
    public class Either<TLeft, TRight> : TEither<TLeft, TRight>.P<Either<TLeft, TRight>>
    {
        public Either(TLeft t0) : base(t0)
        {
        }

        public Either(TRight t1) : base(t1)
        {
        }
    }

    public class Either<TLeft, TInput, TResult>
        : TEither<TLeft>.Func<TInput, TResult>
    {
        public Either(Func<TInput, TResult> func)
            : this(new F<TInput, TResult>(func))
        {
                
        }
        public Either(Func<TUnion<TLeft, IFunc<TInput, TResult>>> factory) : base(factory)
        {
        }

        public Either(TLeft value) : base(value)
        {
        }

        public Either(IFunc<TInput, TResult> value) : base(value)
        {
        }
    }
}