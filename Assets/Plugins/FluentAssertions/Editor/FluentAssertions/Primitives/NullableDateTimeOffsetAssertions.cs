using System;
using System.Diagnostics;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
    /// <summary>
    /// Contains a number of methods to assert that a nullable <see cref="DateTimeOffset"/> is in the expected state.
    /// </summary>
    /// <remarks>
    /// You can use the <see cref="FluentAssertions.Extensions.FluentDateTimeExtensions"/>
    /// for a more fluent way of specifying a <see cref="DateTime"/>.
    /// </remarks>
    [DebuggerNonUserCode]
    public class NullableDateTimeOffsetAssertions : DateTimeOffsetAssertions
    {
        public NullableDateTimeOffsetAssertions(DateTimeOffset? expected)
            : base(expected)
        {
        }

        /// <summary>
        /// Asserts that a nullable <see cref="DateTimeOffset"/> value is not <c>null</c>.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because"/>.
        /// </param>
        public AndConstraint<NullableDateTimeOffsetAssertions> HaveValue(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:variable} to have a value{reason}, but found {0}", Subject);

            return new AndConstraint<NullableDateTimeOffsetAssertions>(this);
        }

        /// <summary>
        /// Asserts that a nullable <see cref="DateTimeOffset"/> value is not <c>null</c>.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because"/>.
        /// </param>
        public AndConstraint<NullableDateTimeOffsetAssertions> NotBeNull(string because = "", params object[] becauseArgs)
        {
            return HaveValue(because, becauseArgs);
        }

        /// <summary>
        /// Asserts that a nullable <see cref="DateTimeOffset"/> value is <c>null</c>.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because"/>.
        /// </param>
        public AndConstraint<NullableDateTimeOffsetAssertions> NotHaveValue(string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Did not expect {context:variable} to have a value{reason}, but found {0}", Subject);

            return new AndConstraint<NullableDateTimeOffsetAssertions>(this);
        }

        /// <summary>
        /// Asserts that a nullable <see cref="DateTimeOffset"/> value is <c>null</c>.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because"/>.
        /// </param>
        public AndConstraint<NullableDateTimeOffsetAssertions> BeNull(string because = "",
            params object[] becauseArgs)
        {
            return NotHaveValue(because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the value is equal to the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<DateTimeOffsetAssertions> Be(DateTimeOffset? expected, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject == expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:the date and time} to be {0}{reason}, but it was {1}.", expected, Subject);

            return new AndConstraint<DateTimeOffsetAssertions>(this);
        }
    }
}
