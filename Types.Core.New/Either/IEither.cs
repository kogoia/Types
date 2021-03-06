﻿using Types.Core.New.Union;

namespace Types.Core.New.Either
{
    public interface IEither<TParent, TLeft, TRight> :
        IUnion<TLeft, TRight>,
        TMonad<TRight>.THead<TLeft>.IParent<TParent>,
        TFunctor<TRight>.THead<TLeft>.IParent<Either<TLeft, TRight>>
        where TRight : class
        where TLeft : class
    {
    }
}
