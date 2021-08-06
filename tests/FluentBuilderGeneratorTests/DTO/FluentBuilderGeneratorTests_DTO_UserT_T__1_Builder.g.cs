//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by https://github.com/StefH/FluentBuilder.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable
using System;
using FluentBuilder;
using FluentBuilderGeneratorTests.DTO;

namespace FluentBuilder
{
    public partial class UserTBuilder<T> : Builder<UserT<T>> where T : struct
    {
        private Lazy<T> _tValue = new Lazy<T>(() => default(T));
        public UserTBuilder<T> WithTValue(T value) => WithTValue(() => value);
        public UserTBuilder<T> WithTValue(Func<T> func)
        {
            _tValue = new Lazy<T>(func);
            return this;
        }
        public UserTBuilder<T> WithoutTValue() => WithTValue(() => default(T));


        public override UserT<T> Build()
        {
            if (Object?.IsValueCreated != true)
            {
                Object = new Lazy<UserT<T>>(() => new UserT<T>
                {
                    TValue = _tValue.Value
                });
            }

            PostBuild(Object.Value);

            return Object.Value;
        }

        public static UserT<T> Default() => new UserT<T>();

    }
}
#nullable disable