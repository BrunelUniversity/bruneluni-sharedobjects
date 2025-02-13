﻿using Aidan.Common.Core.Attributes;
using Aidan.Common.Core.Enum;

namespace BrunelUni.NebulousObjects.Core.Interfaces.Contract;

[ Service( Scope = ServiceLifetimeEnum.Singleton ) ]
public interface INebulousList<T> : IList<T>
{
    void ReplaceFirstOccurance( Func<T, bool> predicate, T replacement );
}