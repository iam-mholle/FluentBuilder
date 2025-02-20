using FluentBuilderGenerator.Helpers;
using FluentBuilderGenerator.Models;
using FluentBuilderGenerator.Types;

namespace FluentBuilderGenerator.FileGenerators;

// ReSharper disable once InconsistentNaming
internal class IEnumerableBuilderGenerator : IFileGenerator
{
    private readonly string _assemblyName;
    private readonly FileDataType _dataType;
    private readonly bool _supportsNullable;
    private readonly string _className;
    private readonly string _genericType;
    private readonly string _toArray;

    public IEnumerableBuilderGenerator(string assemblyName, FileDataType dataType, bool supportsNullable)
    {
        _assemblyName = assemblyName;
        _dataType = dataType;
        _supportsNullable = supportsNullable;
        _className = dataType.ToString();

        (_genericType, _toArray) = IEnumerableBuilderHelper.GetGenericTypeAndToArray(dataType);
    }

    public FileData GenerateFile()
    {
        return new FileData
        (
            _dataType,
            $"FluentBuilder.{_className}.g.cs",
            $@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by https://github.com/StefH/FluentBuilder.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

{(_supportsNullable ? "#nullable enable" : string.Empty)}
using System;
using System.Collections.Generic;

namespace {_assemblyName}.FluentBuilder
{{
    public partial class {_className}<T> : Builder<{_genericType}>
    {{
        private readonly Lazy<List<T>> _list = new Lazy<List<T>>(() => new List<T>());

        public {_className}<T> Add(T item) => Add(() => item);
        public {_className}<T> Add(Func<T> func)
        {{
            _list.Value.Add(func());

            return this;
        }}

        public override {_genericType} Build(bool useObjectInitializer = true)
        {{
            if (Object?.IsValueCreated != true)
            {{
                Object = new Lazy<{_genericType}>(() =>
                {{
                    return _list.Value{_toArray};
                }});
            }}

            PostBuild(Object.Value);

            return Object.Value;
        }}
    }}
}}
{(_supportsNullable ? "#nullable disable" : string.Empty)}"
        );
    }
}