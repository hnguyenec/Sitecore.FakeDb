﻿namespace Sitecore.FakeDb.Tests.Data.Engines.DataCommands
{
  using System;
  using System.Reflection;
  using FluentAssertions;
  using Sitecore.FakeDb.Data.Engines;
  using Sitecore.FakeDb.Data.Engines.DataCommands;
  using Sitecore.Reflection;
  using Xunit;

  public class CommonCommandTest
  {
    [Theory]
    [InlineDefaultAutoData(typeof(AddFromTemplateCommand))]
    [InlineDefaultAutoData(typeof(AddVersionCommand))]
    [InlineDefaultAutoData(typeof(CopyItemCommand))]
    [InlineDefaultAutoData(typeof(CreateItemCommand))]
    [InlineDefaultAutoData(typeof(DeleteItemCommand))]
    [InlineDefaultAutoData(typeof(GetChildrenCommand))]
    [InlineDefaultAutoData(typeof(GetItemCommand))]
    [InlineDefaultAutoData(typeof(GetVersionsCommand))]
    [InlineDefaultAutoData(typeof(MoveItemCommand))]
    [InlineDefaultAutoData(typeof(RemoveVersionCommand))]
    [InlineDefaultAutoData(typeof(SaveItemCommand))]
    public void DoExecuteThrowsNotSupportedException(Type command, DataStorage dataStorage)
    {
      var sut = ReflectionUtil.CreateObject(command, new object[] { dataStorage });

      Action action = () => ReflectionUtil.CallMethod(sut, "CreateInstance");

      action.ShouldThrow<TargetInvocationException>().WithInnerException<NotSupportedException>();
    }
  }
}