﻿using BrunelUni.NebulousObjects.Core.Dtos;
using BrunelUni.NebulousObjects.Core.Enums;
using BrunelUni.NebulousObjects.Tests.NebulousCollectionTests;
using NSubstitute;
using NUnit.Framework;

namespace BrunelUni.NebulousObjects.Tests.WebTests;

public class When_Shared_Lock_Is_Aquired : Given_A_NebulousManager
{
    private int _index;

    protected override void When( )
    {
        _index = 0;
        SUT.EnterItemSharedLock<Person>( _index );
    }

    [ Test ]
    public void Then_Lock_Operation_Is_Sent( )
    {
        MockNebulousClient.Received( 1 ).Send( Arg.Any<OperationDto>( ) );
        MockNebulousClient.Received( ).Send( Arg.Is<OperationDto>( o =>
            o.DataType == typeof( Person ) && o.Operation == OperationEnum.EnterSharedLock && o.Index == _index ) );
    }
}