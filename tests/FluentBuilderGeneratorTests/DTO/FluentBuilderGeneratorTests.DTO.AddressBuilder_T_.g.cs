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
using System.Collections;
using System.Collections.Generic;
using FluentBuilderGeneratorTests.FluentBuilder;
using FluentBuilderGeneratorTests.DTO;

namespace FluentBuilderGeneratorTests.DTO
{
    public partial class AddressBuilder<T> : Builder<FluentBuilderGeneratorTests.DTO.Address<T>> where T : struct
    {
        private bool _streetIsSet;
        private Lazy<T> _street = new Lazy<T>(() => default(T));
        public AddressBuilder<T> WithStreet(T value) => WithStreet(() => value);
        public AddressBuilder<T> WithStreet(Func<T> func)
        {
            _street = new Lazy<T>(func);
            _streetIsSet = true;
            return this;
        }
        public AddressBuilder<T> WithoutStreet()
        {
            WithStreet(() => default(T));
            _streetIsSet = false;
            return this;
        }


        public override Address<T> Build(bool useObjectInitializer = true)
        {
            if (Object?.IsValueCreated != true)
            {
                Object = new Lazy<Address<T>>(() =>
                {
                    if (useObjectInitializer)
                    {
                        return new Address<T>
                        {
                            Street = _street.Value
                        };
                    }

                    var instance = new Address<T>();
                    if (_streetIsSet) { instance.Street = _street.Value; }
                    return instance;
                });
            }

            PostBuild(Object.Value);

            return Object.Value;
        }

        public static Address<T> Default() => new Address<T>();

    }
}
#nullable disable