using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.Either;
using Types.Core.Union;
using Types.Core.Union.Kind1;
using Types.Tests.Common;
using static Types.Core.Either.Functor.Functor;
using static Types.Core.Either.Monad.Monad;

namespace Types.Tests
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void Either_Bind_with_result_and_error()
        {
            Assert
                .AreEqual(
                    new Number(27 + 3).ToString(),
                    new Either<Number, ErrorA>(
                        new Number(27)
                    )
                    .Bind(
                        a => new Either<Number, ErrorA>(
                                  new Number(a.Value + 3)
                             )
                    )
                    .Match(
                        (sum) => sum.ToString(),
                        (e) => e.Message
                    )
                );

            Assert
                .AreEqual(
                    "Error",
                    new Either<Number, ErrorA>(
                        new ErrorA("Error")
                    )
                    .Bind(
                        a => new Either<Number, ErrorA>(
                                  new Number(a.Value + 3)
                             )
                    )
                    .Match(
                        (sum) => sum.ToString(),
                        (e) => e.Message
                    )
                );

            Assert
                .AreEqual(
                    "Error",
                    new Either<Number, ErrorA>(
                        new ErrorA("Error")
                    )
                    .Fmap(number => new Number(number.Value + 3))
                    .Match(
                        (sum) => sum.ToString(),
                        (e) => e.Message
                    )
                );
        }
    }
}
