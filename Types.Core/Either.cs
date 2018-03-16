using System;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.Monads
{
    public class Either<T0, T1> : IEither<T0, T1>.M<Either<T0, T1>>
        where T0 : class
        where T1 : class
    {
        public Either() : base((T0)null)
        {

        }
        public Either(T0 value) : base(value)
        {
        }

        public Either(T1 value) : base(value)
        {
        }
    }
    public class IEither<T0, T1>
        where T0 : class
        where T1 : class
    {

        public abstract class M<M0> :
            IUnion<T0, T1>,
            IFunctor<Either<T0, T1>, T0, T1>, 
            IMonad<M0, T0, T1>
            where M0 : IMonad<M0, T0, T1>, new()

        {
            private readonly AUnion<T0, T1> _union;
            public M(T0 value)
            {
                _union = new AUnion<T0, T1>(value);
            }
            public M(T1 value)
            {
                _union = new AUnion<T0, T1>(value);
            }
            public object Value()
            {
                return _union.Value();
            }

            public M1 Bind<M1, T2>(Func<T0, IMonad<M1, T2, T1>> m)
                where M1 : IMonad<M1, T2, T1>, new()
                where T2 : class
            {
                    return (M1)this.Match(m, (e) => new M1().Retrun(e));
            }

            public M0 Retrun(T0 value)
            {
                return new Factory<M0, T0>(this, value).Instance();
            }
  
            public M0 Retrun(T1 value)
            {
                return new Factory<M0, T1>(this, value).Instance();
            }

            public Either<T0, T1> RetrunF(T0 value)
            {
                return new Factory<Either<T0, T1>, T0>(this, value).Instance();
            }

            public Either<T0, T1> RetrunF(T1 value)
            {
                return new Factory<Either<T0, T1>, T1>(this, value).Instance();
            }
        }
    }

    public class Factory<TResult, TInput>
    {
        private readonly object _self;
        private readonly TInput _value;

        public Factory(object self, TInput value)
        {
            _self = self;
            _value = value;
        }
        public TResult Instance()
        {
            return (TResult)_self
                    .GetType()
                    .GetConstructor(new[] { typeof(TInput) })
                    .Invoke(new object[] { _value });
        } 
    }
}
