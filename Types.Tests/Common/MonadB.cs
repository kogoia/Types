﻿using Types.Core.Monads;
using Types.Tests.Common;

namespace Types.Tests
{
    public class MonadB : IEither<B, Error>.M<MonadB>
    {
        public MonadB() : base((Error)null)
        {
        }

        public MonadB(B value) : base(value)
        {
        }

        public MonadB(Error value) : base(value)
        {
        }
    }
}
